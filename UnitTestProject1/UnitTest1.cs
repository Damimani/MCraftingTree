using MCraftingTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NewBitmapImageUriSourceTest()
        {
            string path = "/ImageResources/Items/acacia_boat.png";
            string expectedPath = "file:///C:/Users/danit/Desktop/MCraftingTree/UnitTestProject1/bin/Debug/ImageResources/Items/acacia_boat.png";
            
            BitmapImage bmi = MCraftingTree.MainWindow.NewBitmapImage(path);

            Assert.AreEqual(expectedPath, bmi.UriSource.ToString());
        }

        [TestMethod]
        public void CheckForRecipesTest()
        {
            List<Items> expectedResult = new List<Items>();
            Items item = new Items() { ID = "minecraft:iron_ore", Name= "Iron Block", ImagePath="/ImageResources/Items/iron_ore.png"};

            List<Items> result = MCraftingTree.MainWindow.CheckForRecipes(item);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
