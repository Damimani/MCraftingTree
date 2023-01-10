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

    }

    class Items
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }



    class Furnace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ICollection<Items> OutputSlot { get; set; }
        public ICollection<Items> ingredientSlot { get; set; }
    }
}
