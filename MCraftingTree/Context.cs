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
    internal class Context : DbContext
    {
        public DbSet<Items> Items { get; set; }
        public DbSet<Mobs> Mobs { get; set; }
        public DbSet<Furnace> Furnace { get; set; }
        public DbSet<MobDrops> MobDrops { get; set; }
        public DbSet<Brewing> Brewing { get; set; }
        public DbSet<CraftingTable> CraftingTable { get; set; }
    }

    class Items
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(250)]
        public string ImagePath { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    class Mobs
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    class Furnace
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [Required]
        public Items OutputSlot { get; set; }
        public Items InputSlot { get; set; }
    }

    class MobDrops
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        public Items Drops { get; set; }
        [Range(0,100)]
        public double DropChance { get; set; } // Percent chances set as: 1% -> 1
        [Required]
        public Items MobId { get; set; }
    }

    class Brewing
    {
        [Key, StringLength(36)]
        public string ID { get; set; }

        [Required]
        public Items OutputSlot { get; set; }
        public Items IngredientSlot { get; set; }
    }

    class CraftingTable
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
}
