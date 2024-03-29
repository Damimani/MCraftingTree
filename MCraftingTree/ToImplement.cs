﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static MCraftingTree.ToImplement;
using System.Runtime.InteropServices.ComTypes;

namespace MCraftingTree
{
    internal class ToImplement
    {
        public class Item2
        {
            [JsonExtensionData]
            public IDictionary<string, JToken> item { get; set; }
        }

        public class Item
        {
            [JsonConverter(typeof(ArrayOrObjectConverter<Item2>)), JsonExtensionData]
            public IDictionary<string, JToken> item { get; set; }
        }

        public class Result
        {
            [JsonProperty("count")]
            public int count { get; set; }
            [JsonProperty("item")]
            public string item { get; set; }
        }

        public class Root
        {
            [JsonProperty("type")]
            public string type { get; set; }
            [JsonProperty("category")]
            public string category { get; set; }
            [JsonProperty("group")]
            public string group { get; set; }
            [JsonConverter(typeof(ArrayOrObjectConverter<Item>))]
            public List<Item> key { get; set; }
            [JsonConverter(typeof(ArrayOrObjectConverter<Item>))]
            public List<Item> ingredients { get; set; }
            [JsonProperty("pattern")]
            public List<string> pattern { get; set; }
            [JsonProperty("result")]
            public Result result { get; set; }
        }

        class ArrayOrObjectConverter<T> : JsonConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                var token = JToken.Load(reader);
                return token.Type == JTokenType.Array
                        ? token.ToObject<List<T>>()
                        : new List<T> { token.ToObject<T>() };
            }

            public override bool CanConvert(Type objectType)
                => objectType == typeof(List<T>);

            public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
                => throw new NotImplementedException();
        }

        public static void Create_CraftingTable()
        {
            using (StreamWriter sw = File.CreateText("C:\\users\\danit\\fos.txt"))
            {
                List<string> addList = new List<string>();
                foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "/recipes", "*.json"))
                {
                    string type = string.Empty;
                    List<Item> key = new List<Item>();
                    List<string> keySymbols = new List<string>();
                    List<Item> ingredients = new List<Item>();
                    List<string> pattern = new List<string>();
                    List<string> itemPattern = new List<string>();
                    string result = string.Empty;
                    int resultAmount = 1;
                    string addLine;
                    Root root = new Root();

                    using (StreamReader r = File.OpenText(file))
                    {
                        Root json = JsonConvert.DeserializeObject<Root>(r.ReadToEnd());
                        root = json;
                    }

                    type = root.type;
                    key = root.key;
                    pattern = root.pattern;
                    result = root.result.item;
                    if (root.result.count > 1)
                    {
                        resultAmount = root.result.count;
                    }
                    ingredients = root.ingredients;

                    if (key != null)
                    {
                        List<string> keyitems = new List<string>();
                        List<JToken> keyvalues = new List<JToken>();
                        for (int i = 0; i < key[0].item.Count; i++)
                        {
                            keyitems = key[0].item.Keys.ToList();
                            keyvalues = key[0].item.Values.ToList();

                            string value = keyvalues[i].First.ToString();
                            if (value.StartsWith("\"tag\":"))
                            {
                                value = value.Substring(18);
                            }
                            else if (value.StartsWith("\"item\":"))
                            {
                                value = value.Substring(19);
                            }
                            value = value.Remove(value.Length - 1);
                            keySymbols.Add(keyitems[i] + ";" + value);
                        }
                    }

                    if (pattern != null)
                    {
                        int patterncount = pattern.Count;
                        for (int i = 0; i < pattern.Count; i++)
                        {
                            string patternLine = pattern[i];
                            if (patterncount < 3)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    itemPattern.Add("-1");
                                }
                                if (patterncount < 2)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        itemPattern.Add("-1");
                                    }
                                    patterncount++;
                                }
                                patterncount++;
                            }
                            int patternLineLenght = patternLine.Length;
                            if (patternLineLenght == 1)
                            {
                                itemPattern.Add("-1");
                                patternLineLenght++;
                            }
                            for (int j = 0; j < patternLine.Length; j++)
                            {
                                char patternSymbol = patternLine[j];
                                string itm = string.Empty;
                                if (patternSymbol == ' ')
                                {
                                    itemPattern.Add("-1");
                                }
                                for (int k = 0; k < keySymbols.Count; k++)
                                {
                                    string[] split = keySymbols[k].Split(';');
                                    char[] symbol = split[0].ToCharArray();
                                    string itemID = split[1];
                                    if (patternSymbol == symbol[0])
                                    {
                                        if (itemID.Contains("wooden"))
                                        {
                                            itemID = itemID.Substring(6);
                                            itemID = "oak" + itemID;
                                        }
                                        if (itemID.EndsWith("s"))
                                        {
                                            itemID = itemID.Remove(itemID.Length - 1);
                                        }

                                        var itemList = MainWindow.ctx.Items.Where(b => b.ID.Contains(itemID)).ToList();
                                        if (itemList.Count > 0)
                                        {
                                            itm = itemList[0].ID;
                                        }
                                        itemPattern.Add(itm);
                                    }
                                }
                            }
                            if (patternLineLenght < 3)
                            {
                                itemPattern.Add("-1");
                                patternLineLenght++;
                            }
                        }
                    }

                    if (ingredients != null)
                    {
                        List<string> keyitems = new List<string>();

                        for (int i = 0; i < ingredients.Count; i++)
                        {
                            string value = string.Empty;
                            value = (string)ingredients[i].item.Values.ToList()[0];
                            itemPattern.Add(value);
                        }
                        for (int i = ingredients.Count; i < 10; i++)
                        {
                            itemPattern.Add("-1");
                        }
                    }
                    var xd = itemPattern;
                    string fos = file;
                    addLine = $"defaultTable.Add(new CraftingTable() {{ ID = Guid.NewGuid().ToString(), OutputAmount = {resultAmount}, " +
                            $"OutputSlot = defaultItems.Single(b => b.ID == \"{result}\"), " +
                            $"Slot11 = defaultItems.Single(b => b.ID == \"{itemPattern[0]}\"), " + 
                            $"Slot12 = defaultItems.Single(b => b.ID == \"{itemPattern[1]}\"), " +
                            $"Slot13 = defaultItems.Single(b => b.ID == \"{itemPattern[2]}\"), " +
                            $"Slot21 = defaultItems.Single(b => b.ID == \"{itemPattern[3]}\"), " +
                            $"Slot22 = defaultItems.Single(b => b.ID == \"{itemPattern[4]}\"), " +
                            $"Slot23 = defaultItems.Single(b => b.ID == \"{itemPattern[5]}\"), " +
                            $"Slot31 = defaultItems.Single(b => b.ID == \"{itemPattern[6]}\"), " +
                            $"Slot32 = defaultItems.Single(b => b.ID == \"{itemPattern[7]}\"), " +
                            $"Slot33 = defaultItems.Single(b => b.ID == \"{itemPattern[8]}\")}});";
                    addList.Add(addLine);
                }
                foreach (var item in addList)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public class Types
        {
            public List<string> values { get; set; }
        }

        public static void Create_Type()
        {
            using (StreamWriter sw = File.CreateText("C:\\users\\danit\\types.txt"))
            {
                List<string> addList = new List<string>();
                List<string> addList2 = new List<string>();
                foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "/tags", "*.json"))
                {
                    Types type = new Types();
                    using (StreamReader r = File.OpenText(file))
                    {
                        Types json = JsonConvert.DeserializeObject<Types>(r.ReadToEnd());
                        type = json;
                    }

                    List<string> values = type.values;
                    string filename = file.Remove(file.Length - 5);
                    filename = filename.Substring(74);

                    for (int i = 0; i < values.Count; i++)
                    {
                        string value = values[i];
                        string addLine = string.Empty;
                        string addLine2 = string.Empty;
                        if (value.StartsWith("#"))
                        {
                            value= value.Substring(1);
                            var types = MainWindow.ctx.Types.Where(b => b.Type.Contains(value)).ToList();
                            for (int j = 0; j < types.Count; j++)
                            {
                                addLine2 = "defaultTypes.Add(new Types() { ID=Guid.NewGuid().ToString(), " +
                                    $"Item=defaultItems.Single(b => b.ID == \"{types[i].Item.ID}\"), " +
                                    $"Type=\"{filename}\"}});";
                                addList2.Add(addLine2);
                            }
                        }
                        else
                        {
                            addLine = "defaultTypes.Add(new Types() { ID=Guid.NewGuid().ToString(), " +
                                $"Item=defaultItems.Single(b => b.ID == \"{value}\"), " +
                                $"Type=\"{filename}\"}});";
                            addList.Add(addLine);
                        }
                    }
                }
                foreach (var item in addList)
                {
                    sw.WriteLine(item);
                }
                foreach (var item in addList2)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static void CreateFile()
        {
            using (StreamWriter sw = File.CreateText("C:\\users\\danit\\fos.txt"))
            {
                foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "/ImageResources/Items", "*.png"))
                {
                    string filename = Path.GetFileName(file);
                    string secondaryImagePath = "ImageResources/Items/" + filename;
                    string itemnamePre = filename.Remove(filename.Length - 4);
                    string[] nameArray = itemnamePre.Split('_');
                    string szar = string.Empty;
                    for (int i = 0; i < nameArray.Length; i++)
                    {
                        string fos = nameArray[i];
                        TextInfo txtinf = new CultureInfo("en-US", false).TextInfo;
                        szar = szar + txtinf.ToTitleCase(fos);
                        if (i != nameArray.Length - 1)
                        {
                            szar += " ";
                        }
                    }
                    string filesAdd = $"defaultItems.Add(new Items() {{ ID=\"minecraft:{itemnamePre}\", " +
                        $"Name=\"{ szar}\", " +
                        $"ImagePath=\"/{secondaryImagePath}\"}});";
                    sw.WriteLine(filesAdd);
                }
            }

        }
    }
}
