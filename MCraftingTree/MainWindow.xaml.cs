using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace MCraftingTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
        }

        //makes a new BitmapImage to stop Image.Load() from being called in the Datagrid
        public BitmapImage NewBitmapImage(string path)
        {
            BitmapImage BMImage = new BitmapImage();
            path = Directory.GetCurrentDirectory().ToString() + path;
            BMImage.BeginInit();
            BMImage.CacheOption = BitmapCacheOption.OnLoad;
            BMImage.UriSource = new Uri(path);
            BMImage.EndInit();
            return BMImage;
        }


        public async void LoadItems()
        {
            loadingText.Visibility = Visibility.Visible;
            var items = ctx.Items;
            await Task.Run(() => { 
                if (items != null)
                {
                    itms = items.ToList();
                    for (int i = 0; i < itms.Count; i++)
                    {
                        if (itms[i].ImagePath != null)
                        {
                            Dispatcher.Invoke(() => {
                                itms[i].BMImage = NewBitmapImage(itms[i].ImagePath);
                            });
                        }
                    }
                    Dispatcher.Invoke(() =>
                    {
                        ItemDG.ItemsSource = "";
                        ItemDG.ItemsSource = itms;
                        loadingText.Visibility = Visibility.Hidden;
                    });
                }
            });
        }

        //Filtered search
        public void LoadItems(string search)
        {
            var items = ctx.Items;
            if (items != null)
            {
                itms = new List<Items>();
                List<Items> item = ctx.Items.Where(b => b.Name.Contains(search)).ToList();
                for (int i = 0; i < item.Count; i++)
                {
                    items.Remove(item[i]);
                    itms.Add(item[i]);
                }
                for (int i = 0; i < itms.Count; i++)
                {
                    if (itms[i].ImagePath != null)
                    {
                        itms[i].BMImage = NewBitmapImage(itms[i].ImagePath);
                    }
                }
                ItemDG.ItemsSource = "";
                ItemDG.ItemsSource = itms;
            }
        }

        Context ctx = new Context();
        Items nullItem = new Items() { ID = "-1" };
        List<Items> itms;
        string switchScreen = "Crafting"; 
        string ImagePath = string.Empty;
        string DialogHostKey = string.Empty;

        //Recipe functions
        private void SwitchScreen(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string key = button.Uid;
            switch (key)
            {
                case "Crafting":
                    CraftingWidth.Width = new GridLength(1, GridUnitType.Star);
                    FurnaceWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    BrewingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    switchScreen = "Crafting";
                    break;
                case "Furnace":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(1, GridUnitType.Star);
                    BrewingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    switchScreen = "Furnace";
                    break;
                case "Brewing":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    BrewingWidth.Width = new GridLength(1, GridUnitType.Star);
                    switchScreen = "Brewing";
                    break;
                default:
                    break;
            }
        }

        private void Add_Recipe(object sender, RoutedEventArgs e)
        {
            switch (switchScreen)
            {
                case "Crafting":
                    if (CraftingOutputImg.Uid != null)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < CraftingGrid.Children.Count-2; i++)
                        {
                            string Uid = ImageUidSearch((Border)CraftingGrid.Children[i]);
                            if (Uid != "" && Uid != null)
                            {
                                Items itm = ctx.Items.Single(b => b.ID == Uid);
                                if (itm != null)
                                {
                                    items.Add(itm);
                                }
                                else
                                {
                                    MessageBox.Show("This item does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else if (CraftingGrid.Children[i] is Border)
                            {
                                items.Add(nullItem);
                            }
                        }
                        CraftingTable recipe = new CraftingTable() { ID = Guid.NewGuid().ToString(), OutputAmount = uint.Parse(OutputAmount.Text), 
                            Slot11 = items[0], Slot12 = items[1], Slot13 = items[2], 
                            Slot21 = items[3], Slot22 = items[4], Slot23 = items[5], 
                            Slot31 = items[6], Slot32 = items[7], Slot33 = items[8], 
                            OutputSlot = items[9]};
                        ctx.CraftingTable.Add(recipe);
                        ctx.SaveChanges();
                    }
                    break;
                case "Furnace":
                    if (FurnaceOutputImg.Uid != null)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < FurnaceGrid.Children.Count; i++)
                        {
                            if (FurnaceGrid.Children[i] is Border)
                            {
                                string Uid = ImageUidSearch((Border)FurnaceGrid.Children[i]);
                                if (Uid != "" && Uid != null)
                                {
                                    Items itm = ctx.Items.Single(b => b.ID == Uid);
                                    if (itm != null)
                                    {
                                        items.Add(itm);
                                    }
                                    else
                                    {
                                        MessageBox.Show("This item does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }

                                }
                                else
                                {
                                    items.Add(nullItem);
                                }
                            }
                        }
                        Furnace recipe = new Furnace() { ID = Guid.NewGuid().ToString(), InputSlot = items[0], OutputSlot=items[1]};
                        ctx.Furnace.Add(recipe);
                        ctx.SaveChanges();
                    }
                    break;
                case "Brewing":
                    if (BrewingOutputImg.Uid != null)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < BrewingGrid.Children.Count; i++)
                        {
                            if (BrewingGrid.Children[i] is Border)
                            {
                                string Uid = ImageUidSearch((Border)BrewingGrid.Children[i]);
                                if (Uid != "" && Uid != null)
                                {
                                    Items itm = ctx.Items.Single(b => b.ID == Uid);
                                    if (itm != null)
                                    {
                                        items.Add(itm);
                                    }
                                    else
                                    {
                                        MessageBox.Show("This item does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }

                                }
                                else
                                {
                                    items.Add(nullItem);
                                }
                            }
                        }
                        Brewing recipe = new Brewing() { ID= Guid.NewGuid().ToString(), IngredientSlot = items[0], OutputSlot = items[1] };
                        ctx.Brewing.Add(recipe);
                        ctx.SaveChanges();
                    }
                    break;
                default:
                    break;
            }
        }

        private void Alter_Recipe(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Recipe(object sender, RoutedEventArgs e)
        {

        }

        private void NumberOnly(object sender, TextChangedEventArgs e)
        {
            if (OutputAmount.Text != "")
            {
                try
                {
                    int.Parse(OutputAmount.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please write a natural number in the input.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    OutputAmount.Text = "1";
                }
            }
        }

        private string ImageUidSearch(Border border)
        {
            Border border2 = (Border)border.Child;
            Grid grid = (Grid)border2.Child;
            Grid grid2 = (Grid)grid.Children[1];
            Image img = (Image)grid2.Children[0];
            string Uid = img.Uid;
            return Uid;
        }

        //Item functions
        private void SwitchItem(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string key = button.Uid;
            switch (key)
            {
                case "Tree":
                    TreeWidth.Width = new GridLength(1, GridUnitType.Star);
                    ItemWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    break;
                case "Item":
                    TreeWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    ItemWidth.Width = new GridLength(1, GridUnitType.Star);
                    break;
                default:
                    break;
            }
        }

        private void DialogHost_Button_Prep(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            DialogHostKey = btn.Uid.ToString();
            if (DialogHostKey == "Alter")
            {
                if (ItemDG.SelectedItem != null)
                {
                    var row = (Items)ItemDG.SelectedItem;
                    ItemName.Text = row.Name;
                    PopupImage.Source = NewBitmapImage(row.ImagePath);
                    ImagePath = row.ImagePath;
                }
            }
        }

        private void Add_Or_Alter_Item(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != null)
            {
                switch (DialogHostKey)
                {
                    case "Add":
                        Items item = new Items() { ID = Guid.NewGuid().ToString(), Name = ItemName.Text, ImagePath = ImagePath };
                        try
                        {
                            ctx.Items.Add(item);
                            ctx.SaveChanges();
                            ImagePath = null;
                            ItemName.Text = null;
                            ItemType.Text = null; 
                            PopupImage.Source = null;
                            LoadItems();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An error has occured during upload.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case "Alter":
                        try
                        {
                            var update = (Items)ItemDG.SelectedItem;
                            update.Name = ItemName.Text;
                            if (update.ImagePath != ImagePath)
                            {
                                update.ImagePath = ImagePath;
                            }
                            ctx.SaveChanges();
                            LoadItems();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An error has occured during modification.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Delete_Item(object sender, RoutedEventArgs e)
        {
            var remove = (Items)ItemDG.SelectedItem;
            bool hasMultipleImgs = false;
            var itemImages = ctx.Items.Where(b => b.ImagePath.Contains(remove.ImagePath)).ToList();
            if (itemImages.Count > 1) hasMultipleImgs = true;
            if (!hasMultipleImgs)
            {
                File.Delete(Directory.GetCurrentDirectory() + remove.ImagePath);
            }
            ctx.Items.Remove(remove);
            ctx.SaveChanges();
            LoadItems();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Image Files(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif"
            };
            bool? res = fileDialog.ShowDialog();
            using (Stream stream = fileDialog.OpenFile())
            {
                if (res.HasValue && res.Value)
                {
                    File.Copy(fileDialog.FileName, Path.Combine(Directory.GetCurrentDirectory(), "ImageResources\\Items", fileDialog.SafeFileName), true);
                    ImagePath = "/ImageResources/Items/" + fileDialog.SafeFileName;
                    PopupImage.Source = NewBitmapImage(ImagePath);
                }
                stream.Dispose();
            }
        }

        private void Search_Items_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchBar.Text;
            if (search != String.Empty)
            {
                LoadItems(search);
            }
            else
            {
                LoadItems();
            }
        }

        //Drag and Drop functions
        private void Item_Source(object sender, MouseEventArgs e)
        {
            Image key = (Image)sender;
            if (e.LeftButton == MouseButtonState.Pressed && key != null)
            {
                Items itm = (Items)key.DataContext;
                DragDrop.DoDragDrop(key, new DataObject(DataFormats.Serializable, itm), DragDropEffects.Copy);
            }
        }

        private void Item_Destination(object sender, DragEventArgs e)
        {
            Items data = (Items)e.Data.GetData(DataFormats.Serializable);
            Grid key = (Grid)sender;
            Image img = (Image)key.Children[0];
            img.Source = data.BMImage;
            img.Uid = data.ID;
        }

        private void Remove_Image(object sender, MouseButtonEventArgs e)
        {
            Image key = (Image)sender;
            key.Uid = "";
            key.Source = null;
        }

        private void Load_Recipe(object sender, MouseButtonEventArgs e)
        {
            DataGridCell sdr = (DataGridCell)sender;
            Items itm = (Items)sdr.Content;
            switch (switchScreen)
            {
                case "Crafting":
                    List<CraftingTable> recipes = ctx.CraftingTable.Where(b => b.OutputSlot == itm).ToList();
                    if (recipes.Count > 1)
                    {

                    }
                    else if (recipes.Count == 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("No recipes are associated with this item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Furnace":
                    break;
                case "Brewing":
                    break;
                default:
                    break;
            }
        }

        /*private void Item_Output(object sender, DragEventArgs e) //needs to be repurposed for recipe loading
        {
            Items data = (Items)e.Data.GetData(DataFormats.Serializable);
            Grid grd = (Grid)sender;
            Image img= (Image)grd.Children[0];
            img.Source = data.BMImage;
            img.Uid = data.ID;

            string key = img.Name;

            switch (key)
            {
                case "CraftingOutputImg":
                    List<CraftingTable> recipes = ctx.CraftingTable.Where(b => b.OutputSlot == data).ToList();
                    if (recipes.Count == 1)
                    {
                        CraftingGridImg11.Source = recipes[0].Slot11.BMImage; //there must be a better way to do this
                        CraftingGridImg11.Uid = recipes[0].Slot11.ID;
                        CraftingGridImg12.Source = recipes[0].Slot12.BMImage;
                        CraftingGridImg11.Uid = recipes[0].Slot12.ID;
                        CraftingGridImg13.Source = recipes[0].Slot13.BMImage;
                        CraftingGridImg13.Uid = recipes[0].Slot13.ID;
                        CraftingGridImg21.Source = recipes[0].Slot21.BMImage;
                        CraftingGridImg21.Uid = recipes[0].Slot21.ID;
                        CraftingGridImg22.Source = recipes[0].Slot22.BMImage;
                        CraftingGridImg22.Uid = recipes[0].Slot22.ID;
                        CraftingGridImg23.Source = recipes[0].Slot23.BMImage;
                        CraftingGridImg23.Uid = recipes[0].Slot23.ID;
                        CraftingGridImg31.Source = recipes[0].Slot31.BMImage;
                        CraftingGridImg31.Uid = recipes[0].Slot31.ID;
                        CraftingGridImg32.Source = recipes[0].Slot32.BMImage;
                        CraftingGridImg32.Uid = recipes[0].Slot32.ID;
                        CraftingGridImg33.Source = recipes[0].Slot33.BMImage;
                        CraftingGridImg33.Uid = recipes[0].Slot33.ID;
                    }
                    else if (recipes.Count > 1)
                    {

                    }

                    break;
                case "FurnaceOutputImg":
                    break;
                case "BrewingOutputImg":
                    break;
                default:
                    break;
            }
        }*/
    }
}
