using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MCraftingTree
{
    public class Context : DbContext
    {
        public DbSet<Items> Items { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Furnace> Furnace { get; set; }
        public DbSet<MobDrops> MobDrops { get; set; }
        public DbSet<Brewing> Brewing { get; set; }
        public DbSet<CraftingTable> CraftingTable { get; set; }

        public Context()
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }
    }

    public class Items
    {
        [Key, StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [NotMapped]
        public BitmapImage BMImage { get; set; }
    }

    public class Types
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
        [Required, StringLength(150)]
        public Items Item { get; set; }
    }

    public class Furnace
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [Required]
        public Items OutputSlot { get; set; }
        public Items InputSlot { get; set; }
    }

    public class MobDrops
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [StringLength(50)]
        public string MobName { get; set; }
        [Range(0,100)]
        public double DropChance { get; set; } // Percent chances set as: 1% -> 1
        [Required]
        public Items Drops { get; set; }
    }

    public class Brewing
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [Required]
        public Items OutputSlot { get; set; }
        public Items IngredientSlot { get; set; }
    }

    public class CraftingTable
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        public Items Slot11 { get; set; }
        public Items Slot12 { get; set; }
        public Items Slot13 { get; set; }
        public Items Slot21 { get; set; }
        public Items Slot22 { get; set; }
        public Items Slot23 { get; set; }
        public Items Slot31 { get; set; }
        public Items Slot32 { get; set; }
        public Items Slot33 { get; set; }

        [Required]
        public Items OutputSlot { get; set; }
        public uint OutputAmount { get; set; }
    }

    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            List<Items> defaultItems = new List<Items>();
            List<MobDrops> defaultMobDrops = new List<MobDrops>();
            List<Types> defaultTypes = new List<Types>();
            List<CraftingTable> defaultTable = new List<CraftingTable>();
            List<Brewing> defaultBrewing = new List<Brewing>();
            List<Furnace> defaultFurnace = new List<Furnace>();

            //defaultItems.Add(new Items() { ID="minecraft:", Name="", ImagePath="ImageResources/Items/"});
            //defaultMobDrops.Add(new MobDrops() { ID=Guid.NewGuid().ToString(), DropChance= , Drops=, MobName=""});
            //defaultTypes.Add(new Types() { ID=Guid.NewGuid().ToString(), Item=, Type=""});
            //defaultTable.Add(new CraftingTable() { ID= Guid.NewGuid().ToString(), OutputAmount=, OutputSlot=, Slot11=, Slot12=, Slot13=, Slot21=, Slot22=, Slot23=, Slot31=, Slot32=, Slot33=});
            //defaultBrewing.Add(new Brewing() { ID=Guid.NewGuid().ToString(), IngredientSlot=, OutputSlot=});
            //defaultFurnace.Add(new Furnace() { ID=Guid.NewGuid().ToString(), InputSlot=, OutputSlot=});

            defaultItems.Add(new Items() { ID = "minecraft:acacia_boat", Name = "Acacia Boat", ImagePath = "ImageResources/Items/acacia_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_chest_boat", Name = "Acacia Chest Boat", ImagePath = "ImageResources/Items/acacia_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_door", Name = "Acacia Door", ImagePath = "ImageResources/Items/acacia_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_leaves", Name = "Acacia Leaves", ImagePath = "ImageResources/Items/acacia_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_log", Name = "Acacia Log", ImagePath = "ImageResources/Items/acacia_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_planks", Name = "Acacia Planks", ImagePath = "ImageResources/Items/acacia_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_sapling", Name = "Acacia Sapling", ImagePath = "ImageResources/Items/acacia_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_sign", Name = "Acacia Sign", ImagePath = "ImageResources/Items/acacia_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft:acacia_trapdoor", Name = "Acacia Trapdoor", ImagePath = "ImageResources/Items/acacia_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft:activator_rail", Name = "Activator Rail", ImagePath = "ImageResources/Items/activator_rail.png" });

            context.Items.AddRange(defaultItems);
            context.MobDrops.AddRange(defaultMobDrops);
            context.Types.AddRange(defaultTypes);
            context.CraftingTable.AddRange(defaultTable);
            context.Brewing.AddRange(defaultBrewing);
            context.Furnace.AddRange(defaultFurnace);

            base.Seed(context);
        }
    }
}
