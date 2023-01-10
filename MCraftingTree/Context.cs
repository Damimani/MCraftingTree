using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCraftingTree
{
    internal class Context : DbContext
    {
        DbSet<Items> items { get; set; }
        DbSet<Mobs> mobs { get; set; }
        DbSet<Furnace> furnace { get; set; }
        DbSet<MobDrops> mobDrops { get; set; }
        DbSet<Brewing> brewing { get; set; }
        DbSet<CraftingTable> craftingTable { get; set; }
    }

    class Items
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    class Mobs
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    class Furnace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ICollection<Items> OutputSlot { get; set; }
        public ICollection<Items> InputSlot { get; set; }
    }

    class MobDrops
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Items> Drops { get; set; }
        [Range(0,100)]
        public byte DropChance { get; set; } // Percent chances set as: 1% -> 1
        [Required]
        public ICollection<Mobs> MobId { get; set; }
    }

    class Brewing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ICollection<Items> OutputSlot { get; set; }
        public ICollection<Items> IngredientSlot { get; set; }
    }

    class CraftingTable
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Items> Slot11 { get; set; }
        public ICollection<Items> Slot12 { get; set; }
        public ICollection<Items> Slot13 { get; set; }
        public ICollection<Items> Slot21 { get; set; }
        public ICollection<Items> Slot22 { get; set; }
        public ICollection<Items> Slot23 { get; set; }
        public ICollection<Items> Slot31 { get; set; }
        public ICollection<Items> Slot32 { get; set; }
        public ICollection<Items> Slot33 { get; set; }

        [Required]
        public ICollection<Items> OutputSlot { get; set; }
        public uint OutputAmount { get; set; }
    }
}
