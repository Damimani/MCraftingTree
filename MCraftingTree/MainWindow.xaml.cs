using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
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
using static MCraftingTree.MainWindow;
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
                    try
                    {
                        itms.Remove(ctx.Items.Single(b => b.ID == "-1"));
                    }
                    catch (Exception){}
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
                    itms.Add(item[i]);
                }
                itms.Remove(ctx.Items.Single(b => b.ID == "-1"));
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

        public static Context ctx = new Context();
        public static Items nullItem = new Items() { ID = "-1", Name="Empty Item" };
        public static List<Items> itms;
        public static string switchScreen = "Crafting"; 
        public static string ImagePath = string.Empty;
        public static string DialogHostKey = string.Empty;
        public static string RecipeID = string.Empty;

        //Recipe functions
        private void SwitchScreen(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string key = button.Uid;
            RecipeID = string.Empty;
            switch (key)
            {
                case "Crafting":
                    CraftingWidth.Width = new GridLength(1, GridUnitType.Star);
                    FurnaceWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    BrewingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    switchScreen = "Crafting";
                    FurnaceInputImg.Source = null;
                    FurnaceInputImg.Uid = String.Empty;
                    FurnaceOutputImg.Source = null;
                    FurnaceOutputImg.Uid = String.Empty;
                    BrewingInputImg.Source = null;
                    BrewingInputImg.Uid = String.Empty;
                    BrewingOutputImg.Source = null;
                    BrewingOutputImg.Uid = String.Empty;

                    break;
                case "Furnace":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(1, GridUnitType.Star);
                    BrewingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    switchScreen = "Furnace";
                    CraftingGridImg11.Source = null;
                    CraftingGridImg11.Uid = string.Empty;
                    CraftingGridImg12.Source = null;
                    CraftingGridImg12.Uid = string.Empty;
                    CraftingGridImg13.Source = null;
                    CraftingGridImg13.Uid = string.Empty;
                    CraftingGridImg21.Source = null;
                    CraftingGridImg21.Uid = string.Empty;
                    CraftingGridImg22.Source = null;
                    CraftingGridImg22.Uid = string.Empty;
                    CraftingGridImg23.Source = null;
                    CraftingGridImg23.Uid = string.Empty;
                    CraftingGridImg31.Source = null;
                    CraftingGridImg31.Uid = string.Empty;
                    CraftingGridImg32.Source = null;
                    CraftingGridImg32.Uid = string.Empty;
                    CraftingGridImg33.Source = null;
                    CraftingGridImg33.Uid = string.Empty;
                    CraftingOutputImg.Source = null;
                    CraftingOutputImg.Uid = String.Empty;
                    BrewingInputImg.Source = null;
                    BrewingInputImg.Uid = String.Empty;
                    BrewingOutputImg.Source = null;
                    BrewingOutputImg.Uid = String.Empty;
                    break;
                case "Brewing":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    BrewingWidth.Width = new GridLength(1, GridUnitType.Star);
                    switchScreen = "Brewing";
                    CraftingGridImg11.Source = null;
                    CraftingGridImg11.Uid = string.Empty;
                    CraftingGridImg12.Source = null;
                    CraftingGridImg12.Uid = string.Empty;
                    CraftingGridImg13.Source = null;
                    CraftingGridImg13.Uid = string.Empty;
                    CraftingGridImg21.Source = null;
                    CraftingGridImg21.Uid = string.Empty;
                    CraftingGridImg22.Source = null;
                    CraftingGridImg22.Uid = string.Empty;
                    CraftingGridImg23.Source = null;
                    CraftingGridImg23.Uid = string.Empty;
                    CraftingGridImg31.Source = null;
                    CraftingGridImg31.Uid = string.Empty;
                    CraftingGridImg32.Source = null;
                    CraftingGridImg32.Uid = string.Empty;
                    CraftingGridImg33.Source = null;
                    CraftingGridImg33.Uid = string.Empty;
                    CraftingOutputImg.Source = null;
                    CraftingOutputImg.Uid = String.Empty;
                    FurnaceInputImg.Source = null;
                    FurnaceInputImg.Uid = String.Empty;
                    FurnaceOutputImg.Source = null;
                    FurnaceOutputImg.Uid = String.Empty;
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
                    if (CraftingOutputImg.Uid != string.Empty)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < CraftingGrid.Children.Count; i++)
                        {
                            if (CraftingGrid.Children[i] is Border border)
                            {
                                string Uid = ImageUidSearch(border);
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
                    if (FurnaceOutputImg.Uid != string.Empty)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < FurnaceGrid.Children.Count; i++)
                        {
                            if (FurnaceGrid.Children[i] is Border border)
                            {
                                string Uid = ImageUidSearch(border);
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
                    if (BrewingOutputImg.Uid != string.Empty)
                    {
                        List<Items> items = new List<Items>();
                        for (int i = 0; i < BrewingGrid.Children.Count; i++)
                        {
                            if (BrewingGrid.Children[i] is Border border)
                            {
                                string Uid = ImageUidSearch(border);
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

        private void Delete_Recipe(object sender, RoutedEventArgs e)
        {
            switch (switchScreen)
            {
                case "Crafting":
                    if (CraftingOutputImg.Uid != string.Empty)
                    {
                        CraftingTable crafting = ctx.CraftingTable.Single(b => b.ID == RecipeID);
                        ctx.CraftingTable.Remove(crafting);
                        ctx.SaveChanges();
                        RecipeID = string.Empty;
                        CraftingGridImg11.Source = null;
                        CraftingGridImg11.Uid = string.Empty;
                        CraftingGridImg12.Source = null;
                        CraftingGridImg12.Uid = string.Empty;
                        CraftingGridImg13.Source = null;
                        CraftingGridImg13.Uid = string.Empty;
                        CraftingGridImg21.Source = null;
                        CraftingGridImg21.Uid = string.Empty;
                        CraftingGridImg22.Source = null;
                        CraftingGridImg22.Uid = string.Empty;
                        CraftingGridImg23.Source = null;
                        CraftingGridImg23.Uid = string.Empty;
                        CraftingGridImg31.Source = null;
                        CraftingGridImg31.Uid = string.Empty;
                        CraftingGridImg32.Source = null;
                        CraftingGridImg32.Uid = string.Empty;
                        CraftingGridImg33.Source = null;
                        CraftingGridImg33.Uid = string.Empty;
                        CraftingOutputImg.Source = null;
                        CraftingOutputImg.Uid = String.Empty;
                    }
                    break;
                case "Furnace":
                    if (FurnaceOutputImg.Uid != string.Empty)
                    {
                        Furnace furnace = ctx.Furnace.Single(b => b.ID == RecipeID);
                        ctx.Furnace.Remove(furnace);
                        ctx.SaveChanges();
                        RecipeID = string.Empty;
                        FurnaceInputImg.Source = null;
                        FurnaceInputImg.Uid = String.Empty;
                        FurnaceOutputImg.Source = null;
                        FurnaceOutputImg.Uid = String.Empty;
                    }
                    break;
                case "Brewing":
                    if (BrewingOutputImg.Uid != string.Empty)
                    {
                        Brewing brewing = ctx.Brewing.Single(b => b.ID == RecipeID);
                        ctx.Brewing.Remove(brewing);
                        ctx.SaveChanges();
                        RecipeID = string.Empty;
                        BrewingInputImg.Source = null;
                        BrewingInputImg.Uid = String.Empty;
                        BrewingOutputImg.Source = null;
                        BrewingOutputImg.Uid = String.Empty;
                    }
                    break;
                default:
                    break;
            }
        }

        private void NumberOnly(object sender, TextChangedEventArgs e)
        {
            if (OutputAmount.Text != "")
            {
                try
                {
                    double.Parse(OutputAmount.Text);
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
                    var rowType = ctx.Types.Single(x => x.Item == row);
                    ItemID.Text = row.ID;
                    ItemName.Text = row.Name;
                    ItemType.Text = rowType.Type;
                    PopupImage.Source = NewBitmapImage(row.ImagePath);
                    ImagePath = row.ImagePath;
                }
            }
        }

        private void MobDropEnable(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool? check = checkBox.IsChecked;
            if (check == true)
            {
                MobDropDisplay.Visibility = Visibility.Visible;
            }
            else
            {
                MobDropDisplay.Visibility = Visibility.Hidden;
            }
        }

        private void Add_Or_Alter_Item(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != "" && ItemID.Text != "")
            {
                switch (DialogHostKey)
                {
                    case "Add":
                        Types type = new Types();
                        MobDrops drop = new MobDrops();
                        Items item = new Items() { ID = ItemID.Text, Name = ItemName.Text };
                        if (ItemType.Text != "")
                        {
                            type = new Types() { ID = Guid.NewGuid().ToString(), Item = item, Type = ItemType.Text };
                        }
                        if (MobName.Text != "" && DropChance.Text != "" && MobDropDisplay.Visibility == Visibility.Visible)
                        {
                            drop = new MobDrops() { ID = Guid.NewGuid().ToString(), DropChance = double.Parse(DropChance.Text), Drops = item, MobName = MobName.Text};
                        }
                        if (ImagePath != string.Empty)
                        {
                            item.ImagePath = ImagePath;
                        }
                        try
                        {
                            ctx.Items.Add(item);
                            if (type.ID != null)
                            {
                                ctx.Types.Add(type);
                            }
                            if (drop.ID != null)
                            {
                                ctx.MobDrops.Add(drop);
                            }
                            ctx.SaveChanges();
                            ImagePath = null;
                            ItemID.Text = null;
                            ItemName.Text = null;
                            ItemType.Text = null; 
                            PopupImage.Source = null;
                            MobName.Text = null;
                            DropChance.Text = null;
                            LoadItems();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An error has occured during upload.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            throw;
                        }
                        break;
                    case "Alter":
                        try
                        {
                            var update = (Items)ItemDG.SelectedItem;
                            var updateType = ctx.Types.Single(b => b.Item == update);
                            update.ID = ItemID.Text;
                            update.Name = ItemName.Text;
                            if (updateType != null)
                            {
                                updateType.Type = ItemType.Text;
                            }
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
            else
            {
                MessageBox.Show("Please define an item ID and an item name!", "Insufficent Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Delete_Item(object sender, RoutedEventArgs e)
        {
            var remove = (Items)ItemDG.SelectedItem;
            if (remove != null)
            {
                var removeType = ctx.Types.Single(b => b.Item == remove);
                bool hasMultipleImgs = false;
                var itemImages = ctx.Items.Where(b => b.ImagePath.Contains(remove.ImagePath)).ToList();
                if (itemImages.Count > 1) hasMultipleImgs = true;
                if (!hasMultipleImgs)
                {
                    File.Delete(Directory.GetCurrentDirectory() + remove.ImagePath);
                }
                ctx.Types.Remove(removeType);
                ctx.Items.Remove(remove);
                ctx.SaveChanges();
                LoadItems();
            }
            else
            {
                MessageBox.Show("Please select an item from the item menu to delete!", "Incorrect Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Image Files(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif"
            };
            bool? res = fileDialog.ShowDialog();
            try
            {
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
            catch (Exception)
            {
                MessageBox.Show("You did not select an image!", "Image Selection Cancelled", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            Image srd = (Image)sender;
            Items itm = ctx.Items.Single(b => b.ID == srd.Uid);
            switch (switchScreen)
            {
                case "Crafting":
                    List<CraftingTable> recipes = ctx.CraftingTable.Where(b => b.OutputSlot.ID == itm.ID).ToList();
                    if (recipes.Count() > 1)
                    {
                        RecipeDG.Visibility = Visibility.Visible;
                        RecipeDGCrafting.Visibility = Visibility.Visible;
                        RecipeDG.ItemsSource = recipes;
                        CraftingButton.IsEnabled = false;
                        FurnaceButton.IsEnabled = false;
                        BrewingButton.IsEnabled = false;
                    }
                    else if (recipes.Count() == 1)
                    {
                        CraftingGridImg11.Source = recipes[0].Slot11.BMImage; //there must be a better way to do this
                        CraftingGridImg11.Uid = recipes[0].Slot11.ID;
                        CraftingGridImg12.Source = recipes[0].Slot12.BMImage;
                        CraftingGridImg12.Uid = recipes[0].Slot12.ID;
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
                        CraftingOutputImg.Source = recipes[0].OutputSlot.BMImage;
                        CraftingOutputImg.Uid = recipes[0].OutputSlot.ID;
                        OutputAmount.Text = recipes[0].OutputAmount.ToString();
                        RecipeID = recipes[0].ID;
                    }
                    else
                    {
                        MessageBox.Show("No recipes are associated with this item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Furnace":
                    List<Furnace> furnace = ctx.Furnace.Where(b => b.OutputSlot.ID == itm.ID).ToList();
                    if (furnace.Count() > 1)
                    {
                        RecipeDG.Visibility = Visibility.Visible;
                        RecipeDGFurnace.Visibility = Visibility.Visible;
                        RecipeDG.ItemsSource = furnace;
                        CraftingButton.IsEnabled = false;
                        FurnaceButton.IsEnabled = false;
                        BrewingButton.IsEnabled = false;
                    }
                    else if (furnace.Count == 1)
                    {
                        FurnaceInputImg.Source = furnace[0].InputSlot.BMImage;
                        FurnaceInputImg.Uid = furnace[0].InputSlot.ID;
                        FurnaceOutputImg.Source = furnace[0].OutputSlot.BMImage;
                        FurnaceOutputImg.Uid = furnace[0].OutputSlot.ID;
                        RecipeID = furnace[0].ID;
                    }
                    else
                    {
                        MessageBox.Show("No recipes are associated with this item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case "Brewing":
                    List<Brewing> brewing = ctx.Brewing.Where(b => b.OutputSlot.ID == itm.ID).ToList();
                    if (brewing.Count() > 1)
                    {
                        RecipeDG.Visibility = Visibility.Visible;
                        RecipeDGBrewing.Visibility = Visibility.Visible;
                        RecipeDG.ItemsSource = brewing;
                        CraftingButton.IsEnabled = false;
                        FurnaceButton.IsEnabled = false;
                        BrewingButton.IsEnabled = false;
                    }
                    else if (brewing.Count == 1)
                    {
                        BrewingInputImg.Source = brewing[0].IngredientSlot.BMImage;
                        BrewingInputImg.Uid = brewing[0].IngredientSlot.ID;
                        BrewingOutputImg.Source = brewing[0].OutputSlot.BMImage;
                        BrewingOutputImg.Uid = brewing[0].OutputSlot.ID;
                        RecipeID = brewing[0].ID;
                    }
                    else
                    {
                        MessageBox.Show("No recipes are associated with this item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                default:
                    break;
            }
        }
        private void RecipeDG_Chosen(object sender, MouseButtonEventArgs e)
        {
            DataGridCell key = (DataGridCell)sender;
            RecipeDG.Visibility = Visibility.Hidden;
            RecipeDGCrafting.Visibility = Visibility.Hidden;
            ContentPresenter cpt = (ContentPresenter)key.Content;
            switch (switchScreen)
            {
                case "Crafting":
                    CraftingTable table = (CraftingTable)cpt.Content;
                    CraftingGridImg11.Source = table.Slot11.BMImage; 
                    CraftingGridImg11.Uid = table.Slot11.ID;
                    CraftingGridImg12.Source = table.Slot12.BMImage;
                    CraftingGridImg12.Uid = table.Slot12.ID;
                    CraftingGridImg13.Source = table.Slot13.BMImage;
                    CraftingGridImg13.Uid = table.Slot13.ID;
                    CraftingGridImg21.Source = table.Slot21.BMImage;
                    CraftingGridImg21.Uid = table.Slot21.ID;
                    CraftingGridImg22.Source = table.Slot22.BMImage;
                    CraftingGridImg22.Uid = table.Slot22.ID;
                    CraftingGridImg23.Source = table.Slot23.BMImage;
                    CraftingGridImg23.Uid = table.Slot23.ID;
                    CraftingGridImg31.Source = table.Slot31.BMImage;
                    CraftingGridImg31.Uid = table.Slot31.ID;
                    CraftingGridImg32.Source = table.Slot32.BMImage;
                    CraftingGridImg32.Uid = table.Slot32.ID;
                    CraftingGridImg33.Source = table.Slot33.BMImage;
                    CraftingGridImg33.Uid = table.Slot33.ID;
                    CraftingOutputImg.Source = table.OutputSlot.BMImage;
                    CraftingOutputImg.Uid = table.OutputSlot.ID;
                    OutputAmount.Text = table.OutputAmount.ToString();
                    RecipeID = table.ID;
                    CraftingButton.IsEnabled = true;
                    FurnaceButton.IsEnabled = true;
                    BrewingButton.IsEnabled = true;
                    break;
                case "Furnace":
                    Furnace furnace = (Furnace)cpt.Content;
                    FurnaceInputImg.Source = furnace.InputSlot.BMImage;
                    FurnaceInputImg.Uid = furnace.InputSlot.ID;
                    FurnaceOutputImg.Source = furnace.OutputSlot.BMImage;
                    FurnaceOutputImg.Uid = furnace.OutputSlot.ID;
                    RecipeID = furnace.ID;
                    CraftingButton.IsEnabled = true;
                    FurnaceButton.IsEnabled = true;
                    BrewingButton.IsEnabled = true;
                    break;
                case "Brewing":
                    Brewing brewing = (Brewing)cpt.Content;
                    BrewingInputImg.Source = brewing.IngredientSlot.BMImage;
                    BrewingInputImg.Uid = brewing.IngredientSlot.ID;
                    BrewingOutputImg.Source = brewing.OutputSlot.BMImage;
                    BrewingOutputImg.Uid = brewing.OutputSlot.ID;
                    RecipeID = brewing.ID;
                    CraftingButton.IsEnabled = true;
                    FurnaceButton.IsEnabled = true;
                    BrewingButton.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }

        //Crafting Tree

        public class CraftingTree
        {
            public BitmapImage BMImage { get; set; }
            public string ID { get; set; }
            public string Name { get; set; }
            public uint OutputAmount { get; set; }
        }

        public List<Items> CheckForRecipes(Items item)
        {
            List<CraftingTable> recipes = ctx.CraftingTable.Where(b => b.OutputSlot.ID == item.ID).ToList();
            List<Items> craftingComponents = new List<Items>();
            if (recipes != null)
            {
                if (recipes[0].Slot11.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot11);
                }
                if (recipes[0].Slot12.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot12);
                }
                if (recipes[0].Slot13.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot13);
                }
                if (recipes[0].Slot21.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot21);
                }
                if (recipes[0].Slot22.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot22);
                }
                if (recipes[0].Slot23.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot23);
                }
                if (recipes[0].Slot31.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot31);
                }
                if (recipes[0].Slot32.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot32);
                }
                if (recipes[0].Slot33.ID != "-1")
                {
                    craftingComponents.Add(recipes[0].Slot33);
                }
            }
            return craftingComponents;
        }

        private void Add_To_Tree(object sender, RoutedEventArgs e)
        {
            List<CraftingTree> craftingTrees= new List<CraftingTree>();
            List<Items> baseMaterials = new List<Items>(); //contains all base materials, to be converted to CraftingTree class
            List<Items> craftingOutputs = new List<Items>(); //contains crafting outputs for the image
            List<Items> tempStorage = new List<Items>(); //stores items that are yet to be processed
            IDictionary<Items, int> counter = new Dictionary<Items, int>(); //counts how many times recipes occur 
            CraftingTree addElement = new CraftingTree();
            if (CraftingOutputImg.Uid != string.Empty)
            {
                List<Items> item = ctx.Items.Where(b => b.ID == CraftingOutputImg.Uid).ToList();
                craftingOutputs.Add(item[0]);

                tempStorage = CheckForRecipes(item[0]);
                for (int i = 0; i < tempStorage.Count; i++)
                {
                    List<Items> addItems = CheckForRecipes(tempStorage[i]);
                    for (int j = 0; j < addItems.Count; j++)
                    {
                        if (CheckForRecipes(addItems[j]) == null)
                        {
                            baseMaterials.Add(addItems[j]);
                        }
                        else if (tempStorage.Contains(addItems[j]))
                        {
                            if (counter.Keys.Contains(addItems[j]))
                            {
                                counter[addItems[j]]++;
                            }
                            else
                            {
                                counter.Add(addItems[j], 1);
                            }
                            if (!baseMaterials.Contains(addItems[j]))
                            {
                                baseMaterials.Add(addItems[j]);
                            }
                            
                        }
                        else
                        {
                            tempStorage.Add(addItems[j]);
                            craftingOutputs.Add(addItems[j]);
                        }
                    }
                }
                Items search = ctx.Items.Where(x => x.ID == "minecraft:iron_ingot").ToList()[0];
                int count = counter.Count;
                MessageBox.Show(tempStorage.Count().ToString());
                
            }
        }
    }
}
