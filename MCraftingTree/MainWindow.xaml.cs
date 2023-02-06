using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            
        }

        string ImageSource = string.Empty;
        public string ImagePath = string.Empty;
        Context ctx = new Context();
        Items itm = new Items();
        Mobs mbs = new Mobs();
        MobDrops mds = new MobDrops();
        Brewing bwg = new Brewing();
        Furnace fnc = new Furnace();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = ctx.Items;
            if (itm != null)
            {
                foreach (var item in items)
                {
                    
                }
            }
        }

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

        private void Add_Item(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != null)
            {
                Items item = new Items() { ID = Guid.NewGuid().ToString(), Name = ItemName.Text, Type = ItemType.Text, ImagePath = ImagePath};
                try
                {
                    ctx.Items.Add(item);
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba történt a föltöltésnél", "Oopsie Woopsie", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
                
            }
        }

        private void Alter_Item(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Item(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Items(object sender, KeyEventArgs e)
        {

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog= new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.png;*.jpg)|*.png;*jpg";
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
