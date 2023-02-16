using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
        //makes a new BitmapImage to stop Image.Load() being a problem and blocking the deletion and modification of already used files
        public BitmapImage NewBitmapImage(string path)
        {
            BitmapImage BMImage = new BitmapImage();
            BMImage.BeginInit();
            BMImage.CacheOption = BitmapCacheOption.OnLoad;
            BMImage.UriSource = new Uri(path);
            BMImage.EndInit();
            return BMImage;
        }

        public void LoadItems()
        {
            var items = ctx.Items;
            if (items != null)
            {
                itms = items.ToList();
                for (int i = 0; i < itms.Count; i++)
                {
                    if (itms[i].ImagePath != null)
                    {
                        if (!itms[i].ImagePath.StartsWith("C:"))
                        {
                            itms[i].ImagePath = Directory.GetCurrentDirectory() + itms[i].ImagePath; //kept adding the current directory to ALL ImagePaths without if
                        }
                        itms[i].BMImage = NewBitmapImage(itms[i].ImagePath);
                    }
                }
                ItemDG.ItemsSource = "";
                ItemDG.ItemsSource = itms;
            }
        }
        public void LoadItems(List<string> search)
        {
            var items = ctx.Items;
            if (items != null)
            {
                itms = new List<Items>();
                foreach (var result in search)
                {
                    List<Items> item = ctx.Items.Where(b => b.Name.StartsWith(result)).ToList();
                    for (int i = 0; i < item.Count; i++)
                    {
                        items.Remove(item[i]);
                        itms.Add(item[i]);
                    }
                }
                for (int i = 0; i < itms.Count; i++)
                {
                    if (itms[i].ImagePath != null)
                    {
                        if (!itms[i].ImagePath.StartsWith("C:"))
                        {
                            itms[i].ImagePath = Directory.GetCurrentDirectory() + itms[i].ImagePath; //kept adding the current directory to ALL ImagePaths without if
                        }
                        itms[i].BMImage = NewBitmapImage(itms[i].ImagePath);
                    }
                }
                ItemDG.ItemsSource = "";
                ItemDG.ItemsSource = itms;
            }
        }

        Context ctx = new Context();
        public string ImagePath = string.Empty;
        string DialogHostKey = string.Empty;
        List<Items> itms;

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
                    break;
                case "Furnace":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(1, GridUnitType.Star);
                    BrewingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    break;
                case "Brewing":
                    CraftingWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    FurnaceWidth.Width = new GridLength(0, GridUnitType.Pixel);
                    BrewingWidth.Width = new GridLength(1, GridUnitType.Star);
                    break;
                default:
                    break;
            }
        }

        private void Add_Recipe(object sender, RoutedEventArgs e)
        {

        }

        private void Alter_Recipe(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Recipe(object sender, RoutedEventArgs e)
        {

        }

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
                    ItemType.Text = row.Type;
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
                        Items item = new Items() { ID = Guid.NewGuid().ToString(), Name = ItemName.Text, Type = ItemType.Text, ImagePath = ImagePath };
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
                            MessageBox.Show("Hiba történt a feltöltésnél ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case "Alter":
                        try
                        {
                            var update = (Items)ItemDG.SelectedItem;
                            update.Name = ItemName.Text;
                            update.Type = ItemType.Text;
                            string currentImage = update.ImagePath.Substring(Directory.GetCurrentDirectory().Length);
                            if (currentImage != ImagePath)
                            {
                                update.ImagePath = ImagePath;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hiba történt a változtatásnál", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (itms[ItemDG.SelectedIndex].ImagePath != Directory.GetCurrentDirectory() && !hasMultipleImgs)
            {
                File.Delete(remove.ImagePath);
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
                    PopupImage.Source = NewBitmapImage(Directory.GetCurrentDirectory() + ImagePath);
                }
                stream.Dispose();
            }
        }

        private void Search_Items_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchBar.Text;
            if (search != String.Empty)
            {
                var itemSearch = ctx.Items.Where(b => b.Name == search).ToList();
                List<string> searchResult = new List<string>();
                for (int i = 0; i < itemSearch.Count; i++)
                {
                    searchResult.Add(itemSearch[i].Name);
                }
                LoadItems(searchResult);
            }
            else
            {
                LoadItems();
            }
        }

        private void Item_Source(object sender, MouseEventArgs e)
        {
            Items itm = (Items)sender;
            if (e.LeftButton == MouseButtonState.Pressed) //itm != null &&
            {
                DragDrop.DoDragDrop(itm.BMImage, itm, DragDropEffects.Copy);
            }
        }

        private void Item_Destination(object sender, DragEventArgs e)
        {
            Items itm = (Items)sender;
            if (itm != null && e.Data.GetDataPresent(typeof(Items)))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }
    }
}
