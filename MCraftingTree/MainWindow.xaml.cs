using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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

        public void LoadItems()
        {
            ItemDG.Items.Clear();
            var items = ctx.Items;
            if (items != null)
            {
                List<Items> itms = null;
                itms = items.ToList();
                for (int i = 0; i < itms.Count; i++)
                {
                    if (!itms[i].ImagePath.StartsWith("C:"))
                    {
                        itms[i].ImagePath = Directory.GetCurrentDirectory() + itms[i].ImagePath; //kept adding the current directory to ALL ImagePaths without if
                    }
                    ItemDG.Items.Add(itms[i]);
                }
            }
        }

        Context ctx = new Context();
        public string ImagePath = string.Empty;
        string DialogHostKey = string.Empty;

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
                    var row = ItemDG.SelectedItem as Items;
                    ItemName.Text = row.Name;
                    ItemType.Text = row.Type;
                    Resources["Image"] = new ImageSourceConverter().ConvertFromString(row.ImagePath) as ImageSource;
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
                            faszfaszfasz.Content = item.ImagePath;
                            ctx.Items.Add(item);
                            ctx.SaveChanges();
                            ImagePath = null;
                            LoadItems();
                            ItemName.Text = null;
                            ItemType.Text = null;
                            Resources["Image"] = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba történt a feltöltésnél " + ex, "Oopsie Woopsie", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba történt a változtatásnál" + ex, "hajaj", MessageBoxButton.OK, MessageBoxImage.Error);
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
            remove.ImagePath = remove.ImagePath.Substring(Directory.GetCurrentDirectory().Length);
            ctx.Items.Remove(remove);
            ctx.SaveChanges();
            LoadItems();
        }

        private void Search_Items(object sender, KeyEventArgs e)
        {

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog= new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";
            bool? res = fileDialog.ShowDialog();
            if (res.HasValue && res.Value)
            {
                File.Copy(fileDialog.FileName, Path.Combine(Directory.GetCurrentDirectory(), "ImageResources\\Items", fileDialog.SafeFileName), true);
                Resources["Image"] = new ImageSourceConverter().ConvertFromString(Directory.GetCurrentDirectory() + "/ImageResources/Items/" + fileDialog.SafeFileName) as ImageSource;
                ImagePath = "/ImageResources/Items/"+fileDialog.SafeFileName;
            }
        }

        
    }
}
