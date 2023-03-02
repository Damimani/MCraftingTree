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
            Database.SetInitializer(new ContextInitializer());
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
        [NotMapped]
        public string Type { get; set; }
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

            defaultItems.Add(new Items() { ID = "minecraft: acacia_boat", Name = "Acacia Boat", ImagePath = "/ImageResources/Items/acacia_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_chest_boat", Name = "Acacia Chest Boat", ImagePath = "/ImageResources/Items/acacia_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_door", Name = "Acacia Door", ImagePath = "/ImageResources/Items/acacia_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_leaves", Name = "Acacia Leaves", ImagePath = "/ImageResources/Items/acacia_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_log", Name = "Acacia Log", ImagePath = "/ImageResources/Items/acacia_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_planks", Name = "Acacia Planks", ImagePath = "/ImageResources/Items/acacia_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_sapling", Name = "Acacia Sapling", ImagePath = "/ImageResources/Items/acacia_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_sign", Name = "Acacia Sign", ImagePath = "/ImageResources/Items/acacia_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: acacia_trapdoor", Name = "Acacia Trapdoor", ImagePath = "/ImageResources/Items/acacia_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: activator_rail", Name = "Activator Rail", ImagePath = "/ImageResources/Items/activator_rail.png" });
            defaultItems.Add(new Items() { ID = "minecraft: allium", Name = "Allium", ImagePath = "/ImageResources/Items/allium.png" });
            defaultItems.Add(new Items() { ID = "minecraft: amethyst_block", Name = "Amethyst Block", ImagePath = "/ImageResources/Items/amethyst_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: amethyst_cluster", Name = "Amethyst Cluster", ImagePath = "/ImageResources/Items/amethyst_cluster.png" });
            defaultItems.Add(new Items() { ID = "minecraft: amethyst_shard", Name = "Amethyst Shard", ImagePath = "/ImageResources/Items/amethyst_shard.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ancient_debris", Name = "Ancient Debris", ImagePath = "/ImageResources/Items/ancient_debris.png" });
            defaultItems.Add(new Items() { ID = "minecraft: andesite", Name = "Andesite", ImagePath = "/ImageResources/Items/andesite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: anvil", Name = "Anvil", ImagePath = "/ImageResources/Items/anvil.png" });
            defaultItems.Add(new Items() { ID = "minecraft: apple", Name = "Apple", ImagePath = "/ImageResources/Items/apple.png" });
            defaultItems.Add(new Items() { ID = "minecraft: armor_stand", Name = "Armor Stand", ImagePath = "/ImageResources/Items/armor_stand.png" });
            defaultItems.Add(new Items() { ID = "minecraft: arrow", Name = "Arrow", ImagePath = "/ImageResources/Items/arrow.png" });
            defaultItems.Add(new Items() { ID = "minecraft: axolotl_bucket", Name = "Axolotl Bucket", ImagePath = "/ImageResources/Items/axolotl_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: azalea_leaves", Name = "Azalea Leaves", ImagePath = "/ImageResources/Items/azalea_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: azalea_plant", Name = "Azalea Plant", ImagePath = "/ImageResources/Items/azalea_plant.png" });
            defaultItems.Add(new Items() { ID = "minecraft: azure_bluet", Name = "Azure Bluet", ImagePath = "/ImageResources/Items/azure_bluet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: baked_potato", Name = "Baked Potato", ImagePath = "/ImageResources/Items/baked_potato.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bamboo", Name = "Bamboo", ImagePath = "/ImageResources/Items/bamboo.png" });
            defaultItems.Add(new Items() { ID = "minecraft: barrel", Name = "Barrel", ImagePath = "/ImageResources/Items/barrel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: basalt", Name = "Basalt", ImagePath = "/ImageResources/Items/basalt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beacon", Name = "Beacon", ImagePath = "/ImageResources/Items/beacon.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bedrock", Name = "Bedrock", ImagePath = "/ImageResources/Items/bedrock.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beef", Name = "Beef", ImagePath = "/ImageResources/Items/beef.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beehive", Name = "Beehive", ImagePath = "/ImageResources/Items/beehive.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beetroot", Name = "Beetroot", ImagePath = "/ImageResources/Items/beetroot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beetroot_seeds", Name = "Beetroot Seeds", ImagePath = "/ImageResources/Items/beetroot_seeds.png" });
            defaultItems.Add(new Items() { ID = "minecraft: beetroot_soup", Name = "Beetroot Soup", ImagePath = "/ImageResources/Items/beetroot_soup.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bee_nest", Name = "Bee Nest", ImagePath = "/ImageResources/Items/bee_nest.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bell", Name = "Bell", ImagePath = "/ImageResources/Items/bell.png" });
            defaultItems.Add(new Items() { ID = "minecraft: big_dripleaf", Name = "Big Dripleaf", ImagePath = "/ImageResources/Items/big_dripleaf.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_boat", Name = "Birch Boat", ImagePath = "/ImageResources/Items/birch_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_chest_boat", Name = "Birch Chest Boat", ImagePath = "/ImageResources/Items/birch_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_door", Name = "Birch Door", ImagePath = "/ImageResources/Items/birch_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_leaves", Name = "Birch Leaves", ImagePath = "/ImageResources/Items/birch_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_log", Name = "Birch Log", ImagePath = "/ImageResources/Items/birch_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_planks", Name = "Birch Planks", ImagePath = "/ImageResources/Items/birch_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_sapling", Name = "Birch Sapling", ImagePath = "/ImageResources/Items/birch_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_sign", Name = "Birch Sign", ImagePath = "/ImageResources/Items/birch_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: birch_trapdoor", Name = "Birch Trapdoor", ImagePath = "/ImageResources/Items/birch_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blackstone", Name = "Blackstone", ImagePath = "/ImageResources/Items/blackstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_candle", Name = "Black Candle", ImagePath = "/ImageResources/Items/black_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_concrete", Name = "Black Concrete", ImagePath = "/ImageResources/Items/black_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_concrete_powder", Name = "Black Concrete Powder", ImagePath = "/ImageResources/Items/black_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_dye", Name = "Black Dye", ImagePath = "/ImageResources/Items/black_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_glazed_terracotta", Name = "Black Glazed Terracotta", ImagePath = "/ImageResources/Items/black_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_shulker_box", Name = "Black Shulker Box", ImagePath = "/ImageResources/Items/black_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_stained_glass", Name = "Black Stained Glass", ImagePath = "/ImageResources/Items/black_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_terracotta", Name = "Black Terracotta", ImagePath = "/ImageResources/Items/black_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: black_wool", Name = "Black Wool", ImagePath = "/ImageResources/Items/black_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blast_furnace", Name = "Blast Furnace", ImagePath = "/ImageResources/Items/blast_furnace.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blaze_powder", Name = "Blaze Powder", ImagePath = "/ImageResources/Items/blaze_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blaze_rod", Name = "Blaze Rod", ImagePath = "/ImageResources/Items/blaze_rod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_candle", Name = "Blue Candle", ImagePath = "/ImageResources/Items/blue_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_concrete", Name = "Blue Concrete", ImagePath = "/ImageResources/Items/blue_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_concrete_powder", Name = "Blue Concrete Powder", ImagePath = "/ImageResources/Items/blue_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_dye", Name = "Blue Dye", ImagePath = "/ImageResources/Items/blue_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_glazed_terracotta", Name = "Blue Glazed Terracotta", ImagePath = "/ImageResources/Items/blue_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_ice", Name = "Blue Ice", ImagePath = "/ImageResources/Items/blue_ice.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_orchid", Name = "Blue Orchid", ImagePath = "/ImageResources/Items/blue_orchid.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_shulker_box", Name = "Blue Shulker Box", ImagePath = "/ImageResources/Items/blue_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_stained_glass", Name = "Blue Stained Glass", ImagePath = "/ImageResources/Items/blue_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_terracotta", Name = "Blue Terracotta", ImagePath = "/ImageResources/Items/blue_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: blue_wool", Name = "Blue Wool", ImagePath = "/ImageResources/Items/blue_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bone", Name = "Bone", ImagePath = "/ImageResources/Items/bone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bone_block", Name = "Bone Block", ImagePath = "/ImageResources/Items/bone_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bone_meal", Name = "Bone Meal", ImagePath = "/ImageResources/Items/bone_meal.png" });
            defaultItems.Add(new Items() { ID = "minecraft: book", Name = "Book", ImagePath = "/ImageResources/Items/book.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bookshelf", Name = "Bookshelf", ImagePath = "/ImageResources/Items/bookshelf.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bow", Name = "Bow", ImagePath = "/ImageResources/Items/bow.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bowl", Name = "Bowl", ImagePath = "/ImageResources/Items/bowl.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brain_coral", Name = "Brain Coral", ImagePath = "/ImageResources/Items/brain_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brain_coral_block", Name = "Brain Coral Block", ImagePath = "/ImageResources/Items/brain_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brain_coral_fan", Name = "Brain Coral Fan", ImagePath = "/ImageResources/Items/brain_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bread", Name = "Bread", ImagePath = "/ImageResources/Items/bread.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brewing_stand", Name = "Brewing Stand", ImagePath = "/ImageResources/Items/brewing_stand.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brick", Name = "Brick", ImagePath = "/ImageResources/Items/brick.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bricks", Name = "Bricks", ImagePath = "/ImageResources/Items/bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_candle", Name = "Brown Candle", ImagePath = "/ImageResources/Items/brown_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_concrete", Name = "Brown Concrete", ImagePath = "/ImageResources/Items/brown_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_concrete_powder", Name = "Brown Concrete Powder", ImagePath = "/ImageResources/Items/brown_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_dye", Name = "Brown Dye", ImagePath = "/ImageResources/Items/brown_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_glazed_terracotta", Name = "Brown Glazed Terracotta", ImagePath = "/ImageResources/Items/brown_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_mushroom", Name = "Brown Mushroom", ImagePath = "/ImageResources/Items/brown_mushroom.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_mushroom_block", Name = "Brown Mushroom Block", ImagePath = "/ImageResources/Items/brown_mushroom_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_shulker_box", Name = "Brown Shulker Box", ImagePath = "/ImageResources/Items/brown_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_stained_glass", Name = "Brown Stained Glass", ImagePath = "/ImageResources/Items/brown_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_terracotta", Name = "Brown Terracotta", ImagePath = "/ImageResources/Items/brown_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: brown_wool", Name = "Brown Wool", ImagePath = "/ImageResources/Items/brown_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bubble_coral", Name = "Bubble Coral", ImagePath = "/ImageResources/Items/bubble_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bubble_coral_block", Name = "Bubble Coral Block", ImagePath = "/ImageResources/Items/bubble_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bubble_coral_fan", Name = "Bubble Coral Fan", ImagePath = "/ImageResources/Items/bubble_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bucket", Name = "Bucket", ImagePath = "/ImageResources/Items/bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: budding_amethyst", Name = "Budding Amethyst", ImagePath = "/ImageResources/Items/budding_amethyst.png" });
            defaultItems.Add(new Items() { ID = "minecraft: bundle", Name = "Bundle", ImagePath = "/ImageResources/Items/bundle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cactus", Name = "Cactus", ImagePath = "/ImageResources/Items/cactus.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cake", Name = "Cake", ImagePath = "/ImageResources/Items/cake.png" });
            defaultItems.Add(new Items() { ID = "minecraft: calcite", Name = "Calcite", ImagePath = "/ImageResources/Items/calcite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: campfire", Name = "Campfire", ImagePath = "/ImageResources/Items/campfire.png" });
            defaultItems.Add(new Items() { ID = "minecraft: candle", Name = "Candle", ImagePath = "/ImageResources/Items/candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: carrot", Name = "Carrot", ImagePath = "/ImageResources/Items/carrot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: carrot_on_a_stick", Name = "Carrot On A Stick", ImagePath = "/ImageResources/Items/carrot_on_a_stick.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cartography_table", Name = "Cartography Table", ImagePath = "/ImageResources/Items/cartography_table.png" });
            defaultItems.Add(new Items() { ID = "minecraft: carved_pumpkin", Name = "Carved Pumpkin", ImagePath = "/ImageResources/Items/carved_pumpkin.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cauldron", Name = "Cauldron", ImagePath = "/ImageResources/Items/cauldron.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chain", Name = "Chain", ImagePath = "/ImageResources/Items/chain.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chainmail_boots", Name = "Chainmail Boots", ImagePath = "/ImageResources/Items/chainmail_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chainmail_chestplate", Name = "Chainmail Chestplate", ImagePath = "/ImageResources/Items/chainmail_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chainmail_helmet", Name = "Chainmail Helmet", ImagePath = "/ImageResources/Items/chainmail_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chainmail_leggings", Name = "Chainmail Leggings", ImagePath = "/ImageResources/Items/chainmail_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: charcoal", Name = "Charcoal", ImagePath = "/ImageResources/Items/charcoal.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chest_minecart", Name = "Chest Minecart", ImagePath = "/ImageResources/Items/chest_minecart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chicken", Name = "Chicken", ImagePath = "/ImageResources/Items/chicken.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_deepslate", Name = "Chiseled Deepslate", ImagePath = "/ImageResources/Items/chiseled_deepslate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_nether_bricks", Name = "Chiseled Nether Bricks", ImagePath = "/ImageResources/Items/chiseled_nether_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_polished_blackstone", Name = "Chiseled Polished Blackstone", ImagePath = "/ImageResources/Items/chiseled_polished_blackstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_quartz_block", Name = "Chiseled Quartz Block", ImagePath = "/ImageResources/Items/chiseled_quartz_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_red_sandstone", Name = "Chiseled Red Sandstone", ImagePath = "/ImageResources/Items/chiseled_red_sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_sandstone", Name = "Chiseled Sandstone", ImagePath = "/ImageResources/Items/chiseled_sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chiseled_stone_bricks", Name = "Chiseled Stone Bricks", ImagePath = "/ImageResources/Items/chiseled_stone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chorus_flower", Name = "Chorus Flower", ImagePath = "/ImageResources/Items/chorus_flower.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chorus_fruit", Name = "Chorus Fruit", ImagePath = "/ImageResources/Items/chorus_fruit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: chorus_plant", Name = "Chorus Plant", ImagePath = "/ImageResources/Items/chorus_plant.png" });
            defaultItems.Add(new Items() { ID = "minecraft: clay", Name = "Clay", ImagePath = "/ImageResources/Items/clay.png" });
            defaultItems.Add(new Items() { ID = "minecraft: clay_ball", Name = "Clay Ball", ImagePath = "/ImageResources/Items/clay_ball.png" });
            defaultItems.Add(new Items() { ID = "minecraft: clock", Name = "Clock", ImagePath = "/ImageResources/Items/clock.png" });
            defaultItems.Add(new Items() { ID = "minecraft: coal", Name = "Coal", ImagePath = "/ImageResources/Items/coal.png" });
            defaultItems.Add(new Items() { ID = "minecraft: coal_block", Name = "Coal Block", ImagePath = "/ImageResources/Items/coal_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: coal_ore", Name = "Coal Ore", ImagePath = "/ImageResources/Items/coal_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: coarse_dirt", Name = "Coarse Dirt", ImagePath = "/ImageResources/Items/coarse_dirt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cobbled_deepslate", Name = "Cobbled Deepslate", ImagePath = "/ImageResources/Items/cobbled_deepslate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cobblestone", Name = "Cobblestone", ImagePath = "/ImageResources/Items/cobblestone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cobweb", Name = "Cobweb", ImagePath = "/ImageResources/Items/cobweb.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cocoa_beans", Name = "Cocoa Beans", ImagePath = "/ImageResources/Items/cocoa_beans.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cod", Name = "Cod", ImagePath = "/ImageResources/Items/cod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cod_bucket", Name = "Cod Bucket", ImagePath = "/ImageResources/Items/cod_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: comparator", Name = "Comparator", ImagePath = "/ImageResources/Items/comparator.png" });
            defaultItems.Add(new Items() { ID = "minecraft: compass", Name = "Compass", ImagePath = "/ImageResources/Items/compass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: composter", Name = "Composter", ImagePath = "/ImageResources/Items/composter.png" });
            defaultItems.Add(new Items() { ID = "minecraft: conduit", Name = "Conduit", ImagePath = "/ImageResources/Items/conduit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_beef", Name = "Cooked Beef", ImagePath = "/ImageResources/Items/cooked_beef.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_chicken", Name = "Cooked Chicken", ImagePath = "/ImageResources/Items/cooked_chicken.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_cod", Name = "Cooked Cod", ImagePath = "/ImageResources/Items/cooked_cod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_mutton", Name = "Cooked Mutton", ImagePath = "/ImageResources/Items/cooked_mutton.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_porkchop", Name = "Cooked Porkchop", ImagePath = "/ImageResources/Items/cooked_porkchop.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_rabbit", Name = "Cooked Rabbit", ImagePath = "/ImageResources/Items/cooked_rabbit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cooked_salmon", Name = "Cooked Salmon", ImagePath = "/ImageResources/Items/cooked_salmon.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cookie", Name = "Cookie", ImagePath = "/ImageResources/Items/cookie.png" });
            defaultItems.Add(new Items() { ID = "minecraft: copper_block", Name = "Copper Block", ImagePath = "/ImageResources/Items/copper_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: copper_ingot", Name = "Copper Ingot", ImagePath = "/ImageResources/Items/copper_ingot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: copper_ore", Name = "Copper Ore", ImagePath = "/ImageResources/Items/copper_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cornflower", Name = "Cornflower", ImagePath = "/ImageResources/Items/cornflower.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cracked_deepslate_bricks", Name = "Cracked Deepslate Bricks", ImagePath = "/ImageResources/Items/cracked_deepslate_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cracked_deepslate_tiles", Name = "Cracked Deepslate Tiles", ImagePath = "/ImageResources/Items/cracked_deepslate_tiles.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cracked_nether_bricks", Name = "Cracked Nether Bricks", ImagePath = "/ImageResources/Items/cracked_nether_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cracked_polished_blackstone_bricks", Name = "Cracked Polished Blackstone Bricks", ImagePath = "/ImageResources/Items/cracked_polished_blackstone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cracked_stone_bricks", Name = "Cracked Stone Bricks", ImagePath = "/ImageResources/Items/cracked_stone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crafting_table", Name = "Crafting Table", ImagePath = "/ImageResources/Items/crafting_table.png" });
            defaultItems.Add(new Items() { ID = "minecraft: creeper_banner_pattern", Name = "Creeper Banner Pattern", ImagePath = "/ImageResources/Items/creeper_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_door", Name = "Crimson Door", ImagePath = "/ImageResources/Items/crimson_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_fungus", Name = "Crimson Fungus", ImagePath = "/ImageResources/Items/crimson_fungus.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_nylium", Name = "Crimson Nylium", ImagePath = "/ImageResources/Items/crimson_nylium.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_planks", Name = "Crimson Planks", ImagePath = "/ImageResources/Items/crimson_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_roots", Name = "Crimson Roots", ImagePath = "/ImageResources/Items/crimson_roots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_roots_pot", Name = "Crimson Roots Pot", ImagePath = "/ImageResources/Items/crimson_roots_pot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_sign", Name = "Crimson Sign", ImagePath = "/ImageResources/Items/crimson_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_stem", Name = "Crimson Stem", ImagePath = "/ImageResources/Items/crimson_stem.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crimson_trapdoor", Name = "Crimson Trapdoor", ImagePath = "/ImageResources/Items/crimson_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crossbow_standby", Name = "Crossbow Standby", ImagePath = "/ImageResources/Items/crossbow_standby.png" });
            defaultItems.Add(new Items() { ID = "minecraft: crying_obsidian", Name = "Crying Obsidian", ImagePath = "/ImageResources/Items/crying_obsidian.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cut_copper", Name = "Cut Copper", ImagePath = "/ImageResources/Items/cut_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cut_red_sandstone", Name = "Cut Red Sandstone", ImagePath = "/ImageResources/Items/cut_red_sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cut_sandstone", Name = "Cut Sandstone", ImagePath = "/ImageResources/Items/cut_sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_candle", Name = "Cyan Candle", ImagePath = "/ImageResources/Items/cyan_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_concrete", Name = "Cyan Concrete", ImagePath = "/ImageResources/Items/cyan_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_concrete_powder", Name = "Cyan Concrete Powder", ImagePath = "/ImageResources/Items/cyan_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_dye", Name = "Cyan Dye", ImagePath = "/ImageResources/Items/cyan_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_glazed_terracotta", Name = "Cyan Glazed Terracotta", ImagePath = "/ImageResources/Items/cyan_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_shulker_box", Name = "Cyan Shulker Box", ImagePath = "/ImageResources/Items/cyan_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_stained_glass", Name = "Cyan Stained Glass", ImagePath = "/ImageResources/Items/cyan_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_terracotta", Name = "Cyan Terracotta", ImagePath = "/ImageResources/Items/cyan_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: cyan_wool", Name = "Cyan Wool", ImagePath = "/ImageResources/Items/cyan_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dandelion", Name = "Dandelion", ImagePath = "/ImageResources/Items/dandelion.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_boat", Name = "Dark Oak Boat", ImagePath = "/ImageResources/Items/dark_oak_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_chest_boat", Name = "Dark Oak Chest Boat", ImagePath = "/ImageResources/Items/dark_oak_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_door", Name = "Dark Oak Door", ImagePath = "/ImageResources/Items/dark_oak_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_leaves", Name = "Dark Oak Leaves", ImagePath = "/ImageResources/Items/dark_oak_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_log", Name = "Dark Oak Log", ImagePath = "/ImageResources/Items/dark_oak_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_planks", Name = "Dark Oak Planks", ImagePath = "/ImageResources/Items/dark_oak_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_sapling", Name = "Dark Oak Sapling", ImagePath = "/ImageResources/Items/dark_oak_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_sign", Name = "Dark Oak Sign", ImagePath = "/ImageResources/Items/dark_oak_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_oak_trapdoor", Name = "Dark Oak Trapdoor", ImagePath = "/ImageResources/Items/dark_oak_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dark_prismarine", Name = "Dark Prismarine", ImagePath = "/ImageResources/Items/dark_prismarine.png" });
            defaultItems.Add(new Items() { ID = "minecraft: daylight_detector", Name = "Daylight Detector", ImagePath = "/ImageResources/Items/daylight_detector.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_brain_coral", Name = "Dead Brain Coral", ImagePath = "/ImageResources/Items/dead_brain_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_brain_coral_block", Name = "Dead Brain Coral Block", ImagePath = "/ImageResources/Items/dead_brain_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_brain_coral_fan", Name = "Dead Brain Coral Fan", ImagePath = "/ImageResources/Items/dead_brain_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_bubble_coral", Name = "Dead Bubble Coral", ImagePath = "/ImageResources/Items/dead_bubble_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_bubble_coral_block", Name = "Dead Bubble Coral Block", ImagePath = "/ImageResources/Items/dead_bubble_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_bubble_coral_fan", Name = "Dead Bubble Coral Fan", ImagePath = "/ImageResources/Items/dead_bubble_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_bush", Name = "Dead Bush", ImagePath = "/ImageResources/Items/dead_bush.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_fire_coral", Name = "Dead Fire Coral", ImagePath = "/ImageResources/Items/dead_fire_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_fire_coral_block", Name = "Dead Fire Coral Block", ImagePath = "/ImageResources/Items/dead_fire_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_fire_coral_fan", Name = "Dead Fire Coral Fan", ImagePath = "/ImageResources/Items/dead_fire_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_horn_coral", Name = "Dead Horn Coral", ImagePath = "/ImageResources/Items/dead_horn_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_horn_coral_block", Name = "Dead Horn Coral Block", ImagePath = "/ImageResources/Items/dead_horn_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_horn_coral_fan", Name = "Dead Horn Coral Fan", ImagePath = "/ImageResources/Items/dead_horn_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_tube_coral", Name = "Dead Tube Coral", ImagePath = "/ImageResources/Items/dead_tube_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_tube_coral_block", Name = "Dead Tube Coral Block", ImagePath = "/ImageResources/Items/dead_tube_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dead_tube_coral_fan", Name = "Dead Tube Coral Fan", ImagePath = "/ImageResources/Items/dead_tube_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate", Name = "Deepslate", ImagePath = "/ImageResources/Items/deepslate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_bricks", Name = "Deepslate Bricks", ImagePath = "/ImageResources/Items/deepslate_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_coal_ore", Name = "Deepslate Coal Ore", ImagePath = "/ImageResources/Items/deepslate_coal_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_copper_ore", Name = "Deepslate Copper Ore", ImagePath = "/ImageResources/Items/deepslate_copper_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_diamond_ore", Name = "Deepslate Diamond Ore", ImagePath = "/ImageResources/Items/deepslate_diamond_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_emerald_ore", Name = "Deepslate Emerald Ore", ImagePath = "/ImageResources/Items/deepslate_emerald_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_gold_ore", Name = "Deepslate Gold Ore", ImagePath = "/ImageResources/Items/deepslate_gold_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_iron_ore", Name = "Deepslate Iron Ore", ImagePath = "/ImageResources/Items/deepslate_iron_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_lapis_ore", Name = "Deepslate Lapis Ore", ImagePath = "/ImageResources/Items/deepslate_lapis_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_redstone_ore", Name = "Deepslate Redstone Ore", ImagePath = "/ImageResources/Items/deepslate_redstone_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: deepslate_tiles", Name = "Deepslate Tiles", ImagePath = "/ImageResources/Items/deepslate_tiles.png" });
            defaultItems.Add(new Items() { ID = "minecraft: detector_rail", Name = "Detector Rail", ImagePath = "/ImageResources/Items/detector_rail.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond", Name = "Diamond", ImagePath = "/ImageResources/Items/diamond.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_axe", Name = "Diamond Axe", ImagePath = "/ImageResources/Items/diamond_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_block", Name = "Diamond Block", ImagePath = "/ImageResources/Items/diamond_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_boots", Name = "Diamond Boots", ImagePath = "/ImageResources/Items/diamond_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_chestplate", Name = "Diamond Chestplate", ImagePath = "/ImageResources/Items/diamond_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_helmet", Name = "Diamond Helmet", ImagePath = "/ImageResources/Items/diamond_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_hoe", Name = "Diamond Hoe", ImagePath = "/ImageResources/Items/diamond_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_horse_armor", Name = "Diamond Horse Armor", ImagePath = "/ImageResources/Items/diamond_horse_armor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_leggings", Name = "Diamond Leggings", ImagePath = "/ImageResources/Items/diamond_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_ore", Name = "Diamond Ore", ImagePath = "/ImageResources/Items/diamond_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_pickaxe", Name = "Diamond Pickaxe", ImagePath = "/ImageResources/Items/diamond_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_shovel", Name = "Diamond Shovel", ImagePath = "/ImageResources/Items/diamond_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diamond_sword", Name = "Diamond Sword", ImagePath = "/ImageResources/Items/diamond_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: diorite", Name = "Diorite", ImagePath = "/ImageResources/Items/diorite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dirt", Name = "Dirt", ImagePath = "/ImageResources/Items/dirt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: disc_fragment_5", Name = "Disc Fragment 5", ImagePath = "/ImageResources/Items/disc_fragment_5.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dispenser", Name = "Dispenser", ImagePath = "/ImageResources/Items/dispenser.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dragon_breath", Name = "Dragon Breath", ImagePath = "/ImageResources/Items/dragon_breath.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dragon_egg", Name = "Dragon Egg", ImagePath = "/ImageResources/Items/dragon_egg.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dried_kelp", Name = "Dried Kelp", ImagePath = "/ImageResources/Items/dried_kelp.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dripstone_block", Name = "Dripstone Block", ImagePath = "/ImageResources/Items/dripstone_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: dropper", Name = "Dropper", ImagePath = "/ImageResources/Items/dropper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: echo_shard", Name = "Echo Shard", ImagePath = "/ImageResources/Items/echo_shard.png" });
            defaultItems.Add(new Items() { ID = "minecraft: egg", Name = "Egg", ImagePath = "/ImageResources/Items/egg.png" });
            defaultItems.Add(new Items() { ID = "minecraft: elytra", Name = "Elytra", ImagePath = "/ImageResources/Items/elytra.png" });
            defaultItems.Add(new Items() { ID = "minecraft: emerald", Name = "Emerald", ImagePath = "/ImageResources/Items/emerald.png" });
            defaultItems.Add(new Items() { ID = "minecraft: emerald_block", Name = "Emerald Block", ImagePath = "/ImageResources/Items/emerald_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: emerald_ore", Name = "Emerald Ore", ImagePath = "/ImageResources/Items/emerald_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: enchanted_book", Name = "Enchanted Book", ImagePath = "/ImageResources/Items/enchanted_book.png" });
            defaultItems.Add(new Items() { ID = "minecraft: enchanting_table", Name = "Enchanting Table", ImagePath = "/ImageResources/Items/enchanting_table.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ender_eye", Name = "Ender Eye", ImagePath = "/ImageResources/Items/ender_eye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ender_pearl", Name = "Ender Pearl", ImagePath = "/ImageResources/Items/ender_pearl.png" });
            defaultItems.Add(new Items() { ID = "minecraft: end_crystal", Name = "End Crystal", ImagePath = "/ImageResources/Items/end_crystal.png" });
            defaultItems.Add(new Items() { ID = "minecraft: end_portal_frame", Name = "End Portal Frame", ImagePath = "/ImageResources/Items/end_portal_frame.png" });
            defaultItems.Add(new Items() { ID = "minecraft: end_rod", Name = "End Rod", ImagePath = "/ImageResources/Items/end_rod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: end_stone", Name = "End Stone", ImagePath = "/ImageResources/Items/end_stone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: end_stone_bricks", Name = "End Stone Bricks", ImagePath = "/ImageResources/Items/end_stone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: experience_bottle", Name = "Experience Bottle", ImagePath = "/ImageResources/Items/experience_bottle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: exposed_copper", Name = "Exposed Copper", ImagePath = "/ImageResources/Items/exposed_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: exposed_cut_copper", Name = "Exposed Cut Copper", ImagePath = "/ImageResources/Items/exposed_cut_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: feather", Name = "Feather", ImagePath = "/ImageResources/Items/feather.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fermented_spider_eye", Name = "Fermented Spider Eye", ImagePath = "/ImageResources/Items/fermented_spider_eye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fern", Name = "Fern", ImagePath = "/ImageResources/Items/fern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: filled_map", Name = "Filled Map", ImagePath = "/ImageResources/Items/filled_map.png" });
            defaultItems.Add(new Items() { ID = "minecraft: firework_rocket", Name = "Firework Rocket", ImagePath = "/ImageResources/Items/firework_rocket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: firework_star", Name = "Firework Star", ImagePath = "/ImageResources/Items/firework_star.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fire_charge", Name = "Fire Charge", ImagePath = "/ImageResources/Items/fire_charge.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fire_coral", Name = "Fire Coral", ImagePath = "/ImageResources/Items/fire_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fire_coral_block", Name = "Fire Coral Block", ImagePath = "/ImageResources/Items/fire_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fire_coral_fan", Name = "Fire Coral Fan", ImagePath = "/ImageResources/Items/fire_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fishing_rod", Name = "Fishing Rod", ImagePath = "/ImageResources/Items/fishing_rod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: fletching_table", Name = "Fletching Table", ImagePath = "/ImageResources/Items/fletching_table.png" });
            defaultItems.Add(new Items() { ID = "minecraft: flint", Name = "Flint", ImagePath = "/ImageResources/Items/flint.png" });
            defaultItems.Add(new Items() { ID = "minecraft: flint_and_steel", Name = "Flint And Steel", ImagePath = "/ImageResources/Items/flint_and_steel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: flowering_azalea", Name = "Flowering Azalea", ImagePath = "/ImageResources/Items/flowering_azalea.png" });
            defaultItems.Add(new Items() { ID = "minecraft: flower_banner_pattern", Name = "Flower Banner Pattern", ImagePath = "/ImageResources/Items/flower_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: flower_pot", Name = "Flower Pot", ImagePath = "/ImageResources/Items/flower_pot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: frosted_ice_0", Name = "Frosted Ice 0", ImagePath = "/ImageResources/Items/frosted_ice_0.png" });
            defaultItems.Add(new Items() { ID = "minecraft: furnace", Name = "Furnace", ImagePath = "/ImageResources/Items/furnace.png" });
            defaultItems.Add(new Items() { ID = "minecraft: furnace_minecart", Name = "Furnace Minecart", ImagePath = "/ImageResources/Items/furnace_minecart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ghast_tear", Name = "Ghast Tear", ImagePath = "/ImageResources/Items/ghast_tear.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gilded_blackstone", Name = "Gilded Blackstone", ImagePath = "/ImageResources/Items/gilded_blackstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glass", Name = "Glass", ImagePath = "/ImageResources/Items/glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glass_bottle", Name = "Glass Bottle", ImagePath = "/ImageResources/Items/glass_bottle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glistering_melon_slice", Name = "Glistering Melon Slice", ImagePath = "/ImageResources/Items/glistering_melon_slice.png" });
            defaultItems.Add(new Items() { ID = "minecraft: globe_banner_pattern", Name = "Globe Banner Pattern", ImagePath = "/ImageResources/Items/globe_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glowstone", Name = "Glowstone", ImagePath = "/ImageResources/Items/glowstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glowstone_dust", Name = "Glowstone Dust", ImagePath = "/ImageResources/Items/glowstone_dust.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glow_berries", Name = "Glow Berries", ImagePath = "/ImageResources/Items/glow_berries.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glow_ink_sac", Name = "Glow Ink Sac", ImagePath = "/ImageResources/Items/glow_ink_sac.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glow_item_frame", Name = "Glow Item Frame", ImagePath = "/ImageResources/Items/glow_item_frame.png" });
            defaultItems.Add(new Items() { ID = "minecraft: glow_lichen", Name = "Glow Lichen", ImagePath = "/ImageResources/Items/glow_lichen.png" });
            defaultItems.Add(new Items() { ID = "minecraft: goat_horn", Name = "Goat Horn", ImagePath = "/ImageResources/Items/goat_horn.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_apple", Name = "Golden Apple", ImagePath = "/ImageResources/Items/golden_apple.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_axe", Name = "Golden Axe", ImagePath = "/ImageResources/Items/golden_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_boots", Name = "Golden Boots", ImagePath = "/ImageResources/Items/golden_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_carrot", Name = "Golden Carrot", ImagePath = "/ImageResources/Items/golden_carrot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_chestplate", Name = "Golden Chestplate", ImagePath = "/ImageResources/Items/golden_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_helmet", Name = "Golden Helmet", ImagePath = "/ImageResources/Items/golden_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_hoe", Name = "Golden Hoe", ImagePath = "/ImageResources/Items/golden_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_horse_armor", Name = "Golden Horse Armor", ImagePath = "/ImageResources/Items/golden_horse_armor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_leggings", Name = "Golden Leggings", ImagePath = "/ImageResources/Items/golden_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_pickaxe", Name = "Golden Pickaxe", ImagePath = "/ImageResources/Items/golden_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_shovel", Name = "Golden Shovel", ImagePath = "/ImageResources/Items/golden_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: golden_sword", Name = "Golden Sword", ImagePath = "/ImageResources/Items/golden_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gold_block", Name = "Gold Block", ImagePath = "/ImageResources/Items/gold_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gold_ingot", Name = "Gold Ingot", ImagePath = "/ImageResources/Items/gold_ingot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gold_nugget", Name = "Gold Nugget", ImagePath = "/ImageResources/Items/gold_nugget.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gold_ore", Name = "Gold Ore", ImagePath = "/ImageResources/Items/gold_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: granite", Name = "Granite", ImagePath = "/ImageResources/Items/granite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: grass", Name = "Grass", ImagePath = "/ImageResources/Items/grass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: grass_block", Name = "Grass Block", ImagePath = "/ImageResources/Items/grass_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gravel", Name = "Gravel", ImagePath = "/ImageResources/Items/gravel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_candle", Name = "Gray Candle", ImagePath = "/ImageResources/Items/gray_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_candle_lit", Name = "Gray Candle Lit", ImagePath = "/ImageResources/Items/gray_candle_lit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_concrete", Name = "Gray Concrete", ImagePath = "/ImageResources/Items/gray_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_concrete_powder", Name = "Gray Concrete Powder", ImagePath = "/ImageResources/Items/gray_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_dye", Name = "Gray Dye", ImagePath = "/ImageResources/Items/gray_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_glazed_terracotta", Name = "Gray Glazed Terracotta", ImagePath = "/ImageResources/Items/gray_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_shulker_box", Name = "Gray Shulker Box", ImagePath = "/ImageResources/Items/gray_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_stained_glass", Name = "Gray Stained Glass", ImagePath = "/ImageResources/Items/gray_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_terracotta", Name = "Gray Terracotta", ImagePath = "/ImageResources/Items/gray_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gray_wool", Name = "Gray Wool", ImagePath = "/ImageResources/Items/gray_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_candle", Name = "Green Candle", ImagePath = "/ImageResources/Items/green_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_concrete", Name = "Green Concrete", ImagePath = "/ImageResources/Items/green_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_concrete_powder", Name = "Green Concrete Powder", ImagePath = "/ImageResources/Items/green_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_dye", Name = "Green Dye", ImagePath = "/ImageResources/Items/green_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_glazed_terracotta", Name = "Green Glazed Terracotta", ImagePath = "/ImageResources/Items/green_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_shulker_box", Name = "Green Shulker Box", ImagePath = "/ImageResources/Items/green_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_stained_glass", Name = "Green Stained Glass", ImagePath = "/ImageResources/Items/green_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_terracotta", Name = "Green Terracotta", ImagePath = "/ImageResources/Items/green_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: green_wool", Name = "Green Wool", ImagePath = "/ImageResources/Items/green_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: grindstone", Name = "Grindstone", ImagePath = "/ImageResources/Items/grindstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: gunpowder", Name = "Gunpowder", ImagePath = "/ImageResources/Items/gunpowder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: hanging_roots", Name = "Hanging Roots", ImagePath = "/ImageResources/Items/hanging_roots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: hay_block", Name = "Hay Block", ImagePath = "/ImageResources/Items/hay_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: heart_of_the_sea", Name = "Heart Of The Sea", ImagePath = "/ImageResources/Items/heart_of_the_sea.png" });
            defaultItems.Add(new Items() { ID = "minecraft: honeycomb", Name = "Honeycomb", ImagePath = "/ImageResources/Items/honeycomb.png" });
            defaultItems.Add(new Items() { ID = "minecraft: honeycomb_block", Name = "Honeycomb Block", ImagePath = "/ImageResources/Items/honeycomb_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: honey_block", Name = "Honey Block", ImagePath = "/ImageResources/Items/honey_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: honey_bottle", Name = "Honey Bottle", ImagePath = "/ImageResources/Items/honey_bottle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: hopper", Name = "Hopper", ImagePath = "/ImageResources/Items/hopper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: hopper_minecart", Name = "Hopper Minecart", ImagePath = "/ImageResources/Items/hopper_minecart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: horn_coral", Name = "Horn Coral", ImagePath = "/ImageResources/Items/horn_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: horn_coral_block", Name = "Horn Coral Block", ImagePath = "/ImageResources/Items/horn_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: horn_coral_fan", Name = "Horn Coral Fan", ImagePath = "/ImageResources/Items/horn_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ice", Name = "Ice", ImagePath = "/ImageResources/Items/ice.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ink_sac", Name = "Ink Sac", ImagePath = "/ImageResources/Items/ink_sac.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_axe", Name = "Iron Axe", ImagePath = "/ImageResources/Items/iron_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_bars", Name = "Iron Bars", ImagePath = "/ImageResources/Items/iron_bars.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_block", Name = "Iron Block", ImagePath = "/ImageResources/Items/iron_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_boots", Name = "Iron Boots", ImagePath = "/ImageResources/Items/iron_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_chestplate", Name = "Iron Chestplate", ImagePath = "/ImageResources/Items/iron_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_door", Name = "Iron Door", ImagePath = "/ImageResources/Items/iron_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_helmet", Name = "Iron Helmet", ImagePath = "/ImageResources/Items/iron_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_hoe", Name = "Iron Hoe", ImagePath = "/ImageResources/Items/iron_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_horse_armor", Name = "Iron Horse Armor", ImagePath = "/ImageResources/Items/iron_horse_armor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_ingot", Name = "Iron Ingot", ImagePath = "/ImageResources/Items/iron_ingot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_leggings", Name = "Iron Leggings", ImagePath = "/ImageResources/Items/iron_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_nugget", Name = "Iron Nugget", ImagePath = "/ImageResources/Items/iron_nugget.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_ore", Name = "Iron Ore", ImagePath = "/ImageResources/Items/iron_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_pickaxe", Name = "Iron Pickaxe", ImagePath = "/ImageResources/Items/iron_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_shovel", Name = "Iron Shovel", ImagePath = "/ImageResources/Items/iron_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_sword", Name = "Iron Sword", ImagePath = "/ImageResources/Items/iron_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: iron_trapdoor", Name = "Iron Trapdoor", ImagePath = "/ImageResources/Items/iron_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: item_frame", Name = "Item Frame", ImagePath = "/ImageResources/Items/item_frame.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jack_o_lantern", Name = "Jack O Lantern", ImagePath = "/ImageResources/Items/jack_o_lantern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jukebox", Name = "Jukebox", ImagePath = "/ImageResources/Items/jukebox.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_boat", Name = "Jungle Boat", ImagePath = "/ImageResources/Items/jungle_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_chest_boat", Name = "Jungle Chest Boat", ImagePath = "/ImageResources/Items/jungle_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_door", Name = "Jungle Door", ImagePath = "/ImageResources/Items/jungle_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_leaves", Name = "Jungle Leaves", ImagePath = "/ImageResources/Items/jungle_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_log", Name = "Jungle Log", ImagePath = "/ImageResources/Items/jungle_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_planks", Name = "Jungle Planks", ImagePath = "/ImageResources/Items/jungle_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_sapling", Name = "Jungle Sapling", ImagePath = "/ImageResources/Items/jungle_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_sign", Name = "Jungle Sign", ImagePath = "/ImageResources/Items/jungle_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: jungle_trapdoor", Name = "Jungle Trapdoor", ImagePath = "/ImageResources/Items/jungle_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: kelp", Name = "Kelp", ImagePath = "/ImageResources/Items/kelp.png" });
            defaultItems.Add(new Items() { ID = "minecraft: knowledge_book", Name = "Knowledge Book", ImagePath = "/ImageResources/Items/knowledge_book.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ladder", Name = "Ladder", ImagePath = "/ImageResources/Items/ladder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lantern", Name = "Lantern", ImagePath = "/ImageResources/Items/lantern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lapis_block", Name = "Lapis Block", ImagePath = "/ImageResources/Items/lapis_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lapis_lazuli", Name = "Lapis Lazuli", ImagePath = "/ImageResources/Items/lapis_lazuli.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lapis_ore", Name = "Lapis Ore", ImagePath = "/ImageResources/Items/lapis_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: large_amethyst_bud", Name = "Large Amethyst Bud", ImagePath = "/ImageResources/Items/large_amethyst_bud.png" });
            defaultItems.Add(new Items() { ID = "minecraft: large_fern", Name = "Large Fern", ImagePath = "/ImageResources/Items/large_fern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lava_bucket", Name = "Lava Bucket", ImagePath = "/ImageResources/Items/lava_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lead", Name = "Lead", ImagePath = "/ImageResources/Items/lead.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather", Name = "Leather", ImagePath = "/ImageResources/Items/leather.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_boots", Name = "Leather Boots", ImagePath = "/ImageResources/Items/leather_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_chestplate", Name = "Leather Chestplate", ImagePath = "/ImageResources/Items/leather_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_helmet", Name = "Leather Helmet", ImagePath = "/ImageResources/Items/leather_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_horse_armor", Name = "Leather Horse Armor", ImagePath = "/ImageResources/Items/leather_horse_armor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_leggings", Name = "Leather Leggings", ImagePath = "/ImageResources/Items/leather_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: leather_leggings_overlay", Name = "Leather Leggings Overlay", ImagePath = "/ImageResources/Items/leather_leggings_overlay.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lectern", Name = "Lectern", ImagePath = "/ImageResources/Items/lectern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lever", Name = "Lever", ImagePath = "/ImageResources/Items/lever.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lightning_rod", Name = "Lightning Rod", ImagePath = "/ImageResources/Items/lightning_rod.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_candle", Name = "Light Blue Candle", ImagePath = "/ImageResources/Items/light_blue_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_concrete", Name = "Light Blue Concrete", ImagePath = "/ImageResources/Items/light_blue_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_concrete_powder", Name = "Light Blue Concrete Powder", ImagePath = "/ImageResources/Items/light_blue_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_dye", Name = "Light Blue Dye", ImagePath = "/ImageResources/Items/light_blue_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_glazed_terracotta", Name = "Light Blue Glazed Terracotta", ImagePath = "/ImageResources/Items/light_blue_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_shulker_box", Name = "Light Blue Shulker Box", ImagePath = "/ImageResources/Items/light_blue_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_stained_glass", Name = "Light Blue Stained Glass", ImagePath = "/ImageResources/Items/light_blue_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_terracotta", Name = "Light Blue Terracotta", ImagePath = "/ImageResources/Items/light_blue_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_blue_wool", Name = "Light Blue Wool", ImagePath = "/ImageResources/Items/light_blue_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_candle", Name = "Light Gray Candle", ImagePath = "/ImageResources/Items/light_gray_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_concrete", Name = "Light Gray Concrete", ImagePath = "/ImageResources/Items/light_gray_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_concrete_powder", Name = "Light Gray Concrete Powder", ImagePath = "/ImageResources/Items/light_gray_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_dye", Name = "Light Gray Dye", ImagePath = "/ImageResources/Items/light_gray_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_glazed_terracotta", Name = "Light Gray Glazed Terracotta", ImagePath = "/ImageResources/Items/light_gray_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_shulker_box", Name = "Light Gray Shulker Box", ImagePath = "/ImageResources/Items/light_gray_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_stained_glass", Name = "Light Gray Stained Glass", ImagePath = "/ImageResources/Items/light_gray_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_terracotta", Name = "Light Gray Terracotta", ImagePath = "/ImageResources/Items/light_gray_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: light_gray_wool", Name = "Light Gray Wool", ImagePath = "/ImageResources/Items/light_gray_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lilac", Name = "Lilac", ImagePath = "/ImageResources/Items/lilac.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lily_of_the_valley", Name = "Lily Of The Valley", ImagePath = "/ImageResources/Items/lily_of_the_valley.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lily_pad", Name = "Lily Pad", ImagePath = "/ImageResources/Items/lily_pad.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_candle", Name = "Lime Candle", ImagePath = "/ImageResources/Items/lime_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_concrete", Name = "Lime Concrete", ImagePath = "/ImageResources/Items/lime_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_concrete_powder", Name = "Lime Concrete Powder", ImagePath = "/ImageResources/Items/lime_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_dye", Name = "Lime Dye", ImagePath = "/ImageResources/Items/lime_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_glazed_terracotta", Name = "Lime Glazed Terracotta", ImagePath = "/ImageResources/Items/lime_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_shulker_box", Name = "Lime Shulker Box", ImagePath = "/ImageResources/Items/lime_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_stained_glass", Name = "Lime Stained Glass", ImagePath = "/ImageResources/Items/lime_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_terracotta", Name = "Lime Terracotta", ImagePath = "/ImageResources/Items/lime_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lime_wool", Name = "Lime Wool", ImagePath = "/ImageResources/Items/lime_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lingering_potion", Name = "Lingering Potion", ImagePath = "/ImageResources/Items/lingering_potion.png" });
            defaultItems.Add(new Items() { ID = "minecraft: lodestone", Name = "Lodestone", ImagePath = "/ImageResources/Items/lodestone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: loom", Name = "Loom", ImagePath = "/ImageResources/Items/loom.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_candle", Name = "Magenta Candle", ImagePath = "/ImageResources/Items/magenta_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_concrete", Name = "Magenta Concrete", ImagePath = "/ImageResources/Items/magenta_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_concrete_powder", Name = "Magenta Concrete Powder", ImagePath = "/ImageResources/Items/magenta_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_dye", Name = "Magenta Dye", ImagePath = "/ImageResources/Items/magenta_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_glazed_terracotta", Name = "Magenta Glazed Terracotta", ImagePath = "/ImageResources/Items/magenta_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_shulker_box", Name = "Magenta Shulker Box", ImagePath = "/ImageResources/Items/magenta_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_stained_glass", Name = "Magenta Stained Glass", ImagePath = "/ImageResources/Items/magenta_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_terracotta", Name = "Magenta Terracotta", ImagePath = "/ImageResources/Items/magenta_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magenta_wool", Name = "Magenta Wool", ImagePath = "/ImageResources/Items/magenta_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magma", Name = "Magma", ImagePath = "/ImageResources/Items/magma.png" });
            defaultItems.Add(new Items() { ID = "minecraft: magma_cream", Name = "Magma Cream", ImagePath = "/ImageResources/Items/magma_cream.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_boat", Name = "Mangrove Boat", ImagePath = "/ImageResources/Items/mangrove_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_chest_boat", Name = "Mangrove Chest Boat", ImagePath = "/ImageResources/Items/mangrove_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_door", Name = "Mangrove Door", ImagePath = "/ImageResources/Items/mangrove_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_leaves", Name = "Mangrove Leaves", ImagePath = "/ImageResources/Items/mangrove_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_log", Name = "Mangrove Log", ImagePath = "/ImageResources/Items/mangrove_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_planks", Name = "Mangrove Planks", ImagePath = "/ImageResources/Items/mangrove_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_propagule", Name = "Mangrove Propagule", ImagePath = "/ImageResources/Items/mangrove_propagule.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_roots", Name = "Mangrove Roots", ImagePath = "/ImageResources/Items/mangrove_roots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_sign", Name = "Mangrove Sign", ImagePath = "/ImageResources/Items/mangrove_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mangrove_trapdoor", Name = "Mangrove Trapdoor", ImagePath = "/ImageResources/Items/mangrove_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: map", Name = "Map", ImagePath = "/ImageResources/Items/map.png" });
            defaultItems.Add(new Items() { ID = "minecraft: melon", Name = "Melon", ImagePath = "/ImageResources/Items/melon.png" });
            defaultItems.Add(new Items() { ID = "minecraft: melon_seeds", Name = "Melon Seeds", ImagePath = "/ImageResources/Items/melon_seeds.png" });
            defaultItems.Add(new Items() { ID = "minecraft: melon_slice", Name = "Melon Slice", ImagePath = "/ImageResources/Items/melon_slice.png" });
            defaultItems.Add(new Items() { ID = "minecraft: milk_bucket", Name = "Milk Bucket", ImagePath = "/ImageResources/Items/milk_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: minecart", Name = "Minecart", ImagePath = "/ImageResources/Items/minecart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mojang_banner_pattern", Name = "Mojang Banner Pattern", ImagePath = "/ImageResources/Items/mojang_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mossy_cobblestone", Name = "Mossy Cobblestone", ImagePath = "/ImageResources/Items/mossy_cobblestone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mossy_stone_bricks", Name = "Mossy Stone Bricks", ImagePath = "/ImageResources/Items/mossy_stone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: moss_block", Name = "Moss Block", ImagePath = "/ImageResources/Items/moss_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mud", Name = "Mud", ImagePath = "/ImageResources/Items/mud.png" });
            defaultItems.Add(new Items() { ID = "minecraft: muddy_mangrove_roots", Name = "Muddy Mangrove Roots", ImagePath = "/ImageResources/Items/muddy_mangrove_roots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mud_bricks", Name = "Mud Bricks", ImagePath = "/ImageResources/Items/mud_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mushroom_stem", Name = "Mushroom Stem", ImagePath = "/ImageResources/Items/mushroom_stem.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mushroom_stew", Name = "Mushroom Stew", ImagePath = "/ImageResources/Items/mushroom_stew.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_11", Name = "Music Disc 11", ImagePath = "/ImageResources/Items/music_disc_11.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_13", Name = "Music Disc 13", ImagePath = "/ImageResources/Items/music_disc_13.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_5", Name = "Music Disc 5", ImagePath = "/ImageResources/Items/music_disc_5.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_blocks", Name = "Music Disc Blocks", ImagePath = "/ImageResources/Items/music_disc_blocks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_cat", Name = "Music Disc Cat", ImagePath = "/ImageResources/Items/music_disc_cat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_chirp", Name = "Music Disc Chirp", ImagePath = "/ImageResources/Items/music_disc_chirp.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_far", Name = "Music Disc Far", ImagePath = "/ImageResources/Items/music_disc_far.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_mall", Name = "Music Disc Mall", ImagePath = "/ImageResources/Items/music_disc_mall.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_mellohi", Name = "Music Disc Mellohi", ImagePath = "/ImageResources/Items/music_disc_mellohi.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_otherside", Name = "Music Disc Otherside", ImagePath = "/ImageResources/Items/music_disc_otherside.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_pigstep", Name = "Music Disc Pigstep", ImagePath = "/ImageResources/Items/music_disc_pigstep.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_stal", Name = "Music Disc Stal", ImagePath = "/ImageResources/Items/music_disc_stal.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_strad", Name = "Music Disc Strad", ImagePath = "/ImageResources/Items/music_disc_strad.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_wait", Name = "Music Disc Wait", ImagePath = "/ImageResources/Items/music_disc_wait.png" });
            defaultItems.Add(new Items() { ID = "minecraft: music_disc_ward", Name = "Music Disc Ward", ImagePath = "/ImageResources/Items/music_disc_ward.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mutton", Name = "Mutton", ImagePath = "/ImageResources/Items/mutton.png" });
            defaultItems.Add(new Items() { ID = "minecraft: mycelium", Name = "Mycelium", ImagePath = "/ImageResources/Items/mycelium.png" });
            defaultItems.Add(new Items() { ID = "minecraft: name_tag", Name = "Name Tag", ImagePath = "/ImageResources/Items/name_tag.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nautilus_shell", Name = "Nautilus Shell", ImagePath = "/ImageResources/Items/nautilus_shell.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_axe", Name = "Netherite Axe", ImagePath = "/ImageResources/Items/netherite_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_block", Name = "Netherite Block", ImagePath = "/ImageResources/Items/netherite_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_boots", Name = "Netherite Boots", ImagePath = "/ImageResources/Items/netherite_boots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_chestplate", Name = "Netherite Chestplate", ImagePath = "/ImageResources/Items/netherite_chestplate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_helmet", Name = "Netherite Helmet", ImagePath = "/ImageResources/Items/netherite_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_hoe", Name = "Netherite Hoe", ImagePath = "/ImageResources/Items/netherite_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_ingot", Name = "Netherite Ingot", ImagePath = "/ImageResources/Items/netherite_ingot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_leggings", Name = "Netherite Leggings", ImagePath = "/ImageResources/Items/netherite_leggings.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_pickaxe", Name = "Netherite Pickaxe", ImagePath = "/ImageResources/Items/netherite_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_scrap", Name = "Netherite Scrap", ImagePath = "/ImageResources/Items/netherite_scrap.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_shovel", Name = "Netherite Shovel", ImagePath = "/ImageResources/Items/netherite_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherite_sword", Name = "Netherite Sword", ImagePath = "/ImageResources/Items/netherite_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: netherrack", Name = "Netherrack", ImagePath = "/ImageResources/Items/netherrack.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_brick", Name = "Nether Brick", ImagePath = "/ImageResources/Items/nether_brick.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_bricks", Name = "Nether Bricks", ImagePath = "/ImageResources/Items/nether_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_gold_ore", Name = "Nether Gold Ore", ImagePath = "/ImageResources/Items/nether_gold_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_quartz_ore", Name = "Nether Quartz Ore", ImagePath = "/ImageResources/Items/nether_quartz_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_sprouts", Name = "Nether Sprouts", ImagePath = "/ImageResources/Items/nether_sprouts.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_star", Name = "Nether Star", ImagePath = "/ImageResources/Items/nether_star.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_wart", Name = "Nether Wart", ImagePath = "/ImageResources/Items/nether_wart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: nether_wart_block", Name = "Nether Wart Block", ImagePath = "/ImageResources/Items/nether_wart_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: note_block", Name = "Note Block", ImagePath = "/ImageResources/Items/note_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_boat", Name = "Oak Boat", ImagePath = "/ImageResources/Items/oak_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_chest_boat", Name = "Oak Chest Boat", ImagePath = "/ImageResources/Items/oak_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_door", Name = "Oak Door", ImagePath = "/ImageResources/Items/oak_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_leaves", Name = "Oak Leaves", ImagePath = "/ImageResources/Items/oak_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_log", Name = "Oak Log", ImagePath = "/ImageResources/Items/oak_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_planks", Name = "Oak Planks", ImagePath = "/ImageResources/Items/oak_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_sapling", Name = "Oak Sapling", ImagePath = "/ImageResources/Items/oak_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_sign", Name = "Oak Sign", ImagePath = "/ImageResources/Items/oak_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oak_trapdoor", Name = "Oak Trapdoor", ImagePath = "/ImageResources/Items/oak_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: observer", Name = "Observer", ImagePath = "/ImageResources/Items/observer.png" });
            defaultItems.Add(new Items() { ID = "minecraft: obsidian", Name = "Obsidian", ImagePath = "/ImageResources/Items/obsidian.png" });
            defaultItems.Add(new Items() { ID = "minecraft: ochre_froglight", Name = "Ochre Froglight", ImagePath = "/ImageResources/Items/ochre_froglight.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_candle", Name = "Orange Candle", ImagePath = "/ImageResources/Items/orange_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_concrete", Name = "Orange Concrete", ImagePath = "/ImageResources/Items/orange_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_concrete_powder", Name = "Orange Concrete Powder", ImagePath = "/ImageResources/Items/orange_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_dye", Name = "Orange Dye", ImagePath = "/ImageResources/Items/orange_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_glazed_terracotta", Name = "Orange Glazed Terracotta", ImagePath = "/ImageResources/Items/orange_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_shulker_box", Name = "Orange Shulker Box", ImagePath = "/ImageResources/Items/orange_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_stained_glass", Name = "Orange Stained Glass", ImagePath = "/ImageResources/Items/orange_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_terracotta", Name = "Orange Terracotta", ImagePath = "/ImageResources/Items/orange_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_tulip", Name = "Orange Tulip", ImagePath = "/ImageResources/Items/orange_tulip.png" });
            defaultItems.Add(new Items() { ID = "minecraft: orange_wool", Name = "Orange Wool", ImagePath = "/ImageResources/Items/orange_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oxeye_daisy", Name = "Oxeye Daisy", ImagePath = "/ImageResources/Items/oxeye_daisy.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oxidized_copper", Name = "Oxidized Copper", ImagePath = "/ImageResources/Items/oxidized_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: oxidized_cut_copper", Name = "Oxidized Cut Copper", ImagePath = "/ImageResources/Items/oxidized_cut_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: packed_ice", Name = "Packed Ice", ImagePath = "/ImageResources/Items/packed_ice.png" });
            defaultItems.Add(new Items() { ID = "minecraft: packed_mud", Name = "Packed Mud", ImagePath = "/ImageResources/Items/packed_mud.png" });
            defaultItems.Add(new Items() { ID = "minecraft: painting", Name = "Painting", ImagePath = "/ImageResources/Items/painting.png" });
            defaultItems.Add(new Items() { ID = "minecraft: paper", Name = "Paper", ImagePath = "/ImageResources/Items/paper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pearlescent_froglight", Name = "Pearlescent Froglight", ImagePath = "/ImageResources/Items/pearlescent_froglight.png" });
            defaultItems.Add(new Items() { ID = "minecraft: peony", Name = "Peony", ImagePath = "/ImageResources/Items/peony.png" });
            defaultItems.Add(new Items() { ID = "minecraft: phantom_membrane", Name = "Phantom Membrane", ImagePath = "/ImageResources/Items/phantom_membrane.png" });
            defaultItems.Add(new Items() { ID = "minecraft: piglin_banner_pattern", Name = "Piglin Banner Pattern", ImagePath = "/ImageResources/Items/piglin_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_candle", Name = "Pink Candle", ImagePath = "/ImageResources/Items/pink_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_concrete", Name = "Pink Concrete", ImagePath = "/ImageResources/Items/pink_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_concrete_powder", Name = "Pink Concrete Powder", ImagePath = "/ImageResources/Items/pink_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_dye", Name = "Pink Dye", ImagePath = "/ImageResources/Items/pink_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_glazed_terracotta", Name = "Pink Glazed Terracotta", ImagePath = "/ImageResources/Items/pink_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_shulker_box", Name = "Pink Shulker Box", ImagePath = "/ImageResources/Items/pink_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_stained_glass", Name = "Pink Stained Glass", ImagePath = "/ImageResources/Items/pink_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_terracotta", Name = "Pink Terracotta", ImagePath = "/ImageResources/Items/pink_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_tulip", Name = "Pink Tulip", ImagePath = "/ImageResources/Items/pink_tulip.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pink_wool", Name = "Pink Wool", ImagePath = "/ImageResources/Items/pink_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: piston", Name = "Piston", ImagePath = "/ImageResources/Items/piston.png" });
            defaultItems.Add(new Items() { ID = "minecraft: podzol", Name = "Podzol", ImagePath = "/ImageResources/Items/podzol.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pointed_dripstone_down_tip", Name = "Pointed Dripstone Down Tip", ImagePath = "/ImageResources/Items/pointed_dripstone_down_tip.png" });
            defaultItems.Add(new Items() { ID = "minecraft: poisonous_potato", Name = "Poisonous Potato", ImagePath = "/ImageResources/Items/poisonous_potato.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_andesite", Name = "Polished Andesite", ImagePath = "/ImageResources/Items/polished_andesite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_basalt", Name = "Polished Basalt", ImagePath = "/ImageResources/Items/polished_basalt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_blackstone", Name = "Polished Blackstone", ImagePath = "/ImageResources/Items/polished_blackstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_blackstone_bricks", Name = "Polished Blackstone Bricks", ImagePath = "/ImageResources/Items/polished_blackstone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_deepslate", Name = "Polished Deepslate", ImagePath = "/ImageResources/Items/polished_deepslate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_diorite", Name = "Polished Diorite", ImagePath = "/ImageResources/Items/polished_diorite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: polished_granite", Name = "Polished Granite", ImagePath = "/ImageResources/Items/polished_granite.png" });
            defaultItems.Add(new Items() { ID = "minecraft: popped_chorus_fruit", Name = "Popped Chorus Fruit", ImagePath = "/ImageResources/Items/popped_chorus_fruit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: poppy", Name = "Poppy", ImagePath = "/ImageResources/Items/poppy.png" });
            defaultItems.Add(new Items() { ID = "minecraft: porkchop", Name = "Porkchop", ImagePath = "/ImageResources/Items/porkchop.png" });
            defaultItems.Add(new Items() { ID = "minecraft: potato", Name = "Potato", ImagePath = "/ImageResources/Items/potato.png" });
            defaultItems.Add(new Items() { ID = "minecraft: potion", Name = "Potion", ImagePath = "/ImageResources/Items/potion.png" });
            defaultItems.Add(new Items() { ID = "minecraft: powder_snow_bucket", Name = "Powder Snow Bucket", ImagePath = "/ImageResources/Items/powder_snow_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: powered_rail", Name = "Powered Rail", ImagePath = "/ImageResources/Items/powered_rail.png" });
            defaultItems.Add(new Items() { ID = "minecraft: prismarine", Name = "Prismarine", ImagePath = "/ImageResources/Items/prismarine.png" });
            defaultItems.Add(new Items() { ID = "minecraft: prismarine_bricks", Name = "Prismarine Bricks", ImagePath = "/ImageResources/Items/prismarine_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: prismarine_crystals", Name = "Prismarine Crystals", ImagePath = "/ImageResources/Items/prismarine_crystals.png" });
            defaultItems.Add(new Items() { ID = "minecraft: prismarine_shard", Name = "Prismarine Shard", ImagePath = "/ImageResources/Items/prismarine_shard.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pufferfish", Name = "Pufferfish", ImagePath = "/ImageResources/Items/pufferfish.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pufferfish_bucket", Name = "Pufferfish Bucket", ImagePath = "/ImageResources/Items/pufferfish_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pumpkin", Name = "Pumpkin", ImagePath = "/ImageResources/Items/pumpkin.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pumpkin_pie", Name = "Pumpkin Pie", ImagePath = "/ImageResources/Items/pumpkin_pie.png" });
            defaultItems.Add(new Items() { ID = "minecraft: pumpkin_seeds", Name = "Pumpkin Seeds", ImagePath = "/ImageResources/Items/pumpkin_seeds.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_candle", Name = "Purple Candle", ImagePath = "/ImageResources/Items/purple_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_concrete", Name = "Purple Concrete", ImagePath = "/ImageResources/Items/purple_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_concrete_powder", Name = "Purple Concrete Powder", ImagePath = "/ImageResources/Items/purple_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_dye", Name = "Purple Dye", ImagePath = "/ImageResources/Items/purple_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_glazed_terracotta", Name = "Purple Glazed Terracotta", ImagePath = "/ImageResources/Items/purple_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_shulker_box", Name = "Purple Shulker Box", ImagePath = "/ImageResources/Items/purple_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_stained_glass", Name = "Purple Stained Glass", ImagePath = "/ImageResources/Items/purple_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_terracotta", Name = "Purple Terracotta", ImagePath = "/ImageResources/Items/purple_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purple_wool", Name = "Purple Wool", ImagePath = "/ImageResources/Items/purple_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purpur_block", Name = "Purpur Block", ImagePath = "/ImageResources/Items/purpur_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: purpur_pillar", Name = "Purpur Pillar", ImagePath = "/ImageResources/Items/purpur_pillar.png" });
            defaultItems.Add(new Items() { ID = "minecraft: quartz", Name = "Quartz", ImagePath = "/ImageResources/Items/quartz.png" });
            defaultItems.Add(new Items() { ID = "minecraft: quartz_block", Name = "Quartz Block", ImagePath = "/ImageResources/Items/quartz_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: quartz_bricks", Name = "Quartz Bricks", ImagePath = "/ImageResources/Items/quartz_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: quartz_pillar", Name = "Quartz Pillar", ImagePath = "/ImageResources/Items/quartz_pillar.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rabbit", Name = "Rabbit", ImagePath = "/ImageResources/Items/rabbit.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rabbit_foot", Name = "Rabbit Foot", ImagePath = "/ImageResources/Items/rabbit_foot.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rabbit_hide", Name = "Rabbit Hide", ImagePath = "/ImageResources/Items/rabbit_hide.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rabbit_stew", Name = "Rabbit Stew", ImagePath = "/ImageResources/Items/rabbit_stew.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rail", Name = "Rail", ImagePath = "/ImageResources/Items/rail.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_copper", Name = "Raw Copper", ImagePath = "/ImageResources/Items/raw_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_copper_block", Name = "Raw Copper Block", ImagePath = "/ImageResources/Items/raw_copper_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_gold", Name = "Raw Gold", ImagePath = "/ImageResources/Items/raw_gold.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_gold_block", Name = "Raw Gold Block", ImagePath = "/ImageResources/Items/raw_gold_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_iron", Name = "Raw Iron", ImagePath = "/ImageResources/Items/raw_iron.png" });
            defaultItems.Add(new Items() { ID = "minecraft: raw_iron_block", Name = "Raw Iron Block", ImagePath = "/ImageResources/Items/raw_iron_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: recovery_compass", Name = "Recovery Compass", ImagePath = "/ImageResources/Items/recovery_compass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: redstone", Name = "Redstone", ImagePath = "/ImageResources/Items/redstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: redstone_block", Name = "Redstone Block", ImagePath = "/ImageResources/Items/redstone_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: redstone_lamp", Name = "Redstone Lamp", ImagePath = "/ImageResources/Items/redstone_lamp.png" });
            defaultItems.Add(new Items() { ID = "minecraft: redstone_ore", Name = "Redstone Ore", ImagePath = "/ImageResources/Items/redstone_ore.png" });
            defaultItems.Add(new Items() { ID = "minecraft: redstone_torch", Name = "Redstone Torch", ImagePath = "/ImageResources/Items/redstone_torch.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_candle", Name = "Red Candle", ImagePath = "/ImageResources/Items/red_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_concrete", Name = "Red Concrete", ImagePath = "/ImageResources/Items/red_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_concrete_powder", Name = "Red Concrete Powder", ImagePath = "/ImageResources/Items/red_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_dye", Name = "Red Dye", ImagePath = "/ImageResources/Items/red_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_glazed_terracotta", Name = "Red Glazed Terracotta", ImagePath = "/ImageResources/Items/red_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_mushroom", Name = "Red Mushroom", ImagePath = "/ImageResources/Items/red_mushroom.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_mushroom_block", Name = "Red Mushroom Block", ImagePath = "/ImageResources/Items/red_mushroom_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_nether_bricks", Name = "Red Nether Bricks", ImagePath = "/ImageResources/Items/red_nether_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_sand", Name = "Red Sand", ImagePath = "/ImageResources/Items/red_sand.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_sandstone", Name = "Red Sandstone", ImagePath = "/ImageResources/Items/red_sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_shulker_box", Name = "Red Shulker Box", ImagePath = "/ImageResources/Items/red_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_stained_glass", Name = "Red Stained Glass", ImagePath = "/ImageResources/Items/red_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_terracotta", Name = "Red Terracotta", ImagePath = "/ImageResources/Items/red_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_tulip", Name = "Red Tulip", ImagePath = "/ImageResources/Items/red_tulip.png" });
            defaultItems.Add(new Items() { ID = "minecraft: red_wool", Name = "Red Wool", ImagePath = "/ImageResources/Items/red_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: reinforced_deepslate", Name = "Reinforced Deepslate", ImagePath = "/ImageResources/Items/reinforced_deepslate.png" });
            defaultItems.Add(new Items() { ID = "minecraft: repeater", Name = "Repeater", ImagePath = "/ImageResources/Items/repeater.png" });
            defaultItems.Add(new Items() { ID = "minecraft: respawn_anchor", Name = "Respawn Anchor", ImagePath = "/ImageResources/Items/respawn_anchor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rooted_dirt", Name = "Rooted Dirt", ImagePath = "/ImageResources/Items/rooted_dirt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rose_bush", Name = "Rose Bush", ImagePath = "/ImageResources/Items/rose_bush.png" });
            defaultItems.Add(new Items() { ID = "minecraft: rotten_flesh", Name = "Rotten Flesh", ImagePath = "/ImageResources/Items/rotten_flesh.png" });
            defaultItems.Add(new Items() { ID = "minecraft: saddle", Name = "Saddle", ImagePath = "/ImageResources/Items/saddle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: salmon", Name = "Salmon", ImagePath = "/ImageResources/Items/salmon.png" });
            defaultItems.Add(new Items() { ID = "minecraft: salmon_bucket", Name = "Salmon Bucket", ImagePath = "/ImageResources/Items/salmon_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sand", Name = "Sand", ImagePath = "/ImageResources/Items/sand.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sandstone", Name = "Sandstone", ImagePath = "/ImageResources/Items/sandstone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: scaffolding", Name = "Scaffolding", ImagePath = "/ImageResources/Items/scaffolding.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sculk", Name = "Sculk", ImagePath = "/ImageResources/Items/sculk.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sculk_catalyst", Name = "Sculk Catalyst", ImagePath = "/ImageResources/Items/sculk_catalyst.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sculk_sensor", Name = "Sculk Sensor", ImagePath = "/ImageResources/Items/sculk_sensor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sculk_shrieker", Name = "Sculk Shrieker", ImagePath = "/ImageResources/Items/sculk_shrieker.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sculk_vein", Name = "Sculk Vein", ImagePath = "/ImageResources/Items/sculk_vein.png" });
            defaultItems.Add(new Items() { ID = "minecraft: scute", Name = "Scute", ImagePath = "/ImageResources/Items/scute.png" });
            defaultItems.Add(new Items() { ID = "minecraft: seagrass", Name = "Seagrass", ImagePath = "/ImageResources/Items/seagrass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sea_lantern", Name = "Sea Lantern", ImagePath = "/ImageResources/Items/sea_lantern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sea_pickle", Name = "Sea Pickle", ImagePath = "/ImageResources/Items/sea_pickle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: shears", Name = "Shears", ImagePath = "/ImageResources/Items/shears.png" });
            defaultItems.Add(new Items() { ID = "minecraft: shroomlight", Name = "Shroomlight", ImagePath = "/ImageResources/Items/shroomlight.png" });
            defaultItems.Add(new Items() { ID = "minecraft: shulker_box", Name = "Shulker Box", ImagePath = "/ImageResources/Items/shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: shulker_shell", Name = "Shulker Shell", ImagePath = "/ImageResources/Items/shulker_shell.png" });
            defaultItems.Add(new Items() { ID = "minecraft: skull_banner_pattern", Name = "Skull Banner Pattern", ImagePath = "/ImageResources/Items/skull_banner_pattern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: slime_ball", Name = "Slime Ball", ImagePath = "/ImageResources/Items/slime_ball.png" });
            defaultItems.Add(new Items() { ID = "minecraft: slime_block", Name = "Slime Block", ImagePath = "/ImageResources/Items/slime_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: small_dripleaf", Name = "Small Dripleaf", ImagePath = "/ImageResources/Items/small_dripleaf.png" });
            defaultItems.Add(new Items() { ID = "minecraft: smithing_table", Name = "Smithing Table", ImagePath = "/ImageResources/Items/smithing_table.png" });
            defaultItems.Add(new Items() { ID = "minecraft: smoker", Name = "Smoker", ImagePath = "/ImageResources/Items/smoker.png" });
            defaultItems.Add(new Items() { ID = "minecraft: smooth_basalt", Name = "Smooth Basalt", ImagePath = "/ImageResources/Items/smooth_basalt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: smooth_stone", Name = "Smooth Stone", ImagePath = "/ImageResources/Items/smooth_stone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: smooth_stone_slab", Name = "Smooth Stone Slab", ImagePath = "/ImageResources/Items/smooth_stone_slab.png" });
            defaultItems.Add(new Items() { ID = "minecraft: snow", Name = "Snow", ImagePath = "/ImageResources/Items/snow.png" });
            defaultItems.Add(new Items() { ID = "minecraft: snowball", Name = "Snowball", ImagePath = "/ImageResources/Items/snowball.png" });
            defaultItems.Add(new Items() { ID = "minecraft: soul_campfire", Name = "Soul Campfire", ImagePath = "/ImageResources/Items/soul_campfire.png" });
            defaultItems.Add(new Items() { ID = "minecraft: soul_lantern", Name = "Soul Lantern", ImagePath = "/ImageResources/Items/soul_lantern.png" });
            defaultItems.Add(new Items() { ID = "minecraft: soul_sand", Name = "Soul Sand", ImagePath = "/ImageResources/Items/soul_sand.png" });
            defaultItems.Add(new Items() { ID = "minecraft: soul_soil", Name = "Soul Soil", ImagePath = "/ImageResources/Items/soul_soil.png" });
            defaultItems.Add(new Items() { ID = "minecraft: soul_torch", Name = "Soul Torch", ImagePath = "/ImageResources/Items/soul_torch.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spawner", Name = "Spawner", ImagePath = "/ImageResources/Items/spawner.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spawn_egg", Name = "Spawn Egg", ImagePath = "/ImageResources/Items/spawn_egg.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spectral_arrow", Name = "Spectral Arrow", ImagePath = "/ImageResources/Items/spectral_arrow.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spider_eye", Name = "Spider Eye", ImagePath = "/ImageResources/Items/spider_eye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: splash_potion", Name = "Splash Potion", ImagePath = "/ImageResources/Items/splash_potion.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sponge", Name = "Sponge", ImagePath = "/ImageResources/Items/sponge.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spore_blossom", Name = "Spore Blossom", ImagePath = "/ImageResources/Items/spore_blossom.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_boat", Name = "Spruce Boat", ImagePath = "/ImageResources/Items/spruce_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_chest_boat", Name = "Spruce Chest Boat", ImagePath = "/ImageResources/Items/spruce_chest_boat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_door", Name = "Spruce Door", ImagePath = "/ImageResources/Items/spruce_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_leaves", Name = "Spruce Leaves", ImagePath = "/ImageResources/Items/spruce_leaves.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_log", Name = "Spruce Log", ImagePath = "/ImageResources/Items/spruce_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_planks", Name = "Spruce Planks", ImagePath = "/ImageResources/Items/spruce_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_sapling", Name = "Spruce Sapling", ImagePath = "/ImageResources/Items/spruce_sapling.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_sign", Name = "Spruce Sign", ImagePath = "/ImageResources/Items/spruce_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spruce_trapdoor", Name = "Spruce Trapdoor", ImagePath = "/ImageResources/Items/spruce_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: spyglass", Name = "Spyglass", ImagePath = "/ImageResources/Items/spyglass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stick", Name = "Stick", ImagePath = "/ImageResources/Items/stick.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone", Name = "Stone", ImagePath = "/ImageResources/Items/stone.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stonecutter", Name = "Stonecutter", ImagePath = "/ImageResources/Items/stonecutter.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_axe", Name = "Stone Axe", ImagePath = "/ImageResources/Items/stone_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_bricks", Name = "Stone Bricks", ImagePath = "/ImageResources/Items/stone_bricks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_hoe", Name = "Stone Hoe", ImagePath = "/ImageResources/Items/stone_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_pickaxe", Name = "Stone Pickaxe", ImagePath = "/ImageResources/Items/stone_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_shovel", Name = "Stone Shovel", ImagePath = "/ImageResources/Items/stone_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stone_sword", Name = "Stone Sword", ImagePath = "/ImageResources/Items/stone_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: string", Name = "String", ImagePath = "/ImageResources/Items/string.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_acacia_log", Name = "Stripped Acacia Log", ImagePath = "/ImageResources/Items/stripped_acacia_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_birch_log", Name = "Stripped Birch Log", ImagePath = "/ImageResources/Items/stripped_birch_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_crimson_stem", Name = "Stripped Crimson Stem", ImagePath = "/ImageResources/Items/stripped_crimson_stem.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_dark_oak_log", Name = "Stripped Dark Oak Log", ImagePath = "/ImageResources/Items/stripped_dark_oak_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_jungle_log", Name = "Stripped Jungle Log", ImagePath = "/ImageResources/Items/stripped_jungle_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_mangrove_log", Name = "Stripped Mangrove Log", ImagePath = "/ImageResources/Items/stripped_mangrove_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_oak_log", Name = "Stripped Oak Log", ImagePath = "/ImageResources/Items/stripped_oak_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_spruce_log", Name = "Stripped Spruce Log", ImagePath = "/ImageResources/Items/stripped_spruce_log.png" });
            defaultItems.Add(new Items() { ID = "minecraft: stripped_warped_stem", Name = "Stripped Warped Stem", ImagePath = "/ImageResources/Items/stripped_warped_stem.png" });
            defaultItems.Add(new Items() { ID = "minecraft: structure_block", Name = "Structure Block", ImagePath = "/ImageResources/Items/structure_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sugar", Name = "Sugar", ImagePath = "/ImageResources/Items/sugar.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sugar_cane", Name = "Sugar Cane", ImagePath = "/ImageResources/Items/sugar_cane.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sunflower", Name = "Sunflower", ImagePath = "/ImageResources/Items/sunflower.png" });
            defaultItems.Add(new Items() { ID = "minecraft: suspicious_stew", Name = "Suspicious Stew", ImagePath = "/ImageResources/Items/suspicious_stew.png" });
            defaultItems.Add(new Items() { ID = "minecraft: sweet_berries", Name = "Sweet Berries", ImagePath = "/ImageResources/Items/sweet_berries.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tadpole_bucket", Name = "Tadpole Bucket", ImagePath = "/ImageResources/Items/tadpole_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tall_grass", Name = "Tall Grass", ImagePath = "/ImageResources/Items/tall_grass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: target", Name = "Target", ImagePath = "/ImageResources/Items/target.png" });
            defaultItems.Add(new Items() { ID = "minecraft: terracotta", Name = "Terracotta", ImagePath = "/ImageResources/Items/terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tinted_glass", Name = "Tinted Glass", ImagePath = "/ImageResources/Items/tinted_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tipped_arrow", Name = "Tipped Arrow", ImagePath = "/ImageResources/Items/tipped_arrow.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tnt", Name = "Tnt", ImagePath = "/ImageResources/Items/tnt.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tnt_minecart", Name = "Tnt Minecart", ImagePath = "/ImageResources/Items/tnt_minecart.png" });
            defaultItems.Add(new Items() { ID = "minecraft: torch", Name = "Torch", ImagePath = "/ImageResources/Items/torch.png" });
            defaultItems.Add(new Items() { ID = "minecraft: totem_of_undying", Name = "Totem Of Undying", ImagePath = "/ImageResources/Items/totem_of_undying.png" });
            defaultItems.Add(new Items() { ID = "minecraft: trident", Name = "Trident", ImagePath = "/ImageResources/Items/trident.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tripwire_hook", Name = "Tripwire Hook", ImagePath = "/ImageResources/Items/tripwire_hook.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tropical_fish", Name = "Tropical Fish", ImagePath = "/ImageResources/Items/tropical_fish.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tropical_fish_bucket", Name = "Tropical Fish Bucket", ImagePath = "/ImageResources/Items/tropical_fish_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tube_coral", Name = "Tube Coral", ImagePath = "/ImageResources/Items/tube_coral.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tube_coral_block", Name = "Tube Coral Block", ImagePath = "/ImageResources/Items/tube_coral_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tube_coral_fan", Name = "Tube Coral Fan", ImagePath = "/ImageResources/Items/tube_coral_fan.png" });
            defaultItems.Add(new Items() { ID = "minecraft: tuff", Name = "Tuff", ImagePath = "/ImageResources/Items/tuff.png" });
            defaultItems.Add(new Items() { ID = "minecraft: turtle_egg", Name = "Turtle Egg", ImagePath = "/ImageResources/Items/turtle_egg.png" });
            defaultItems.Add(new Items() { ID = "minecraft: turtle_helmet", Name = "Turtle Helmet", ImagePath = "/ImageResources/Items/turtle_helmet.png" });
            defaultItems.Add(new Items() { ID = "minecraft: twisting_vines", Name = "Twisting Vines", ImagePath = "/ImageResources/Items/twisting_vines.png" });
            defaultItems.Add(new Items() { ID = "minecraft: verdant_froglight", Name = "Verdant Froglight", ImagePath = "/ImageResources/Items/verdant_froglight.png" });
            defaultItems.Add(new Items() { ID = "minecraft: vine", Name = "Vine", ImagePath = "/ImageResources/Items/vine.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_door", Name = "Warped Door", ImagePath = "/ImageResources/Items/warped_door.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_fungus", Name = "Warped Fungus", ImagePath = "/ImageResources/Items/warped_fungus.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_fungus_on_a_stick", Name = "Warped Fungus On A Stick", ImagePath = "/ImageResources/Items/warped_fungus_on_a_stick.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_nylium", Name = "Warped Nylium", ImagePath = "/ImageResources/Items/warped_nylium.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_planks", Name = "Warped Planks", ImagePath = "/ImageResources/Items/warped_planks.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_roots", Name = "Warped Roots", ImagePath = "/ImageResources/Items/warped_roots.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_sign", Name = "Warped Sign", ImagePath = "/ImageResources/Items/warped_sign.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_stem", Name = "Warped Stem", ImagePath = "/ImageResources/Items/warped_stem.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_trapdoor", Name = "Warped Trapdoor", ImagePath = "/ImageResources/Items/warped_trapdoor.png" });
            defaultItems.Add(new Items() { ID = "minecraft: warped_wart_block", Name = "Warped Wart Block", ImagePath = "/ImageResources/Items/warped_wart_block.png" });
            defaultItems.Add(new Items() { ID = "minecraft: water_bucket", Name = "Water Bucket", ImagePath = "/ImageResources/Items/water_bucket.png" });
            defaultItems.Add(new Items() { ID = "minecraft: weathered_copper", Name = "Weathered Copper", ImagePath = "/ImageResources/Items/weathered_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: weathered_cut_copper", Name = "Weathered Cut Copper", ImagePath = "/ImageResources/Items/weathered_cut_copper.png" });
            defaultItems.Add(new Items() { ID = "minecraft: weeping_vines", Name = "Weeping Vines", ImagePath = "/ImageResources/Items/weeping_vines.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wet_sponge", Name = "Wet Sponge", ImagePath = "/ImageResources/Items/wet_sponge.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wheat", Name = "Wheat", ImagePath = "/ImageResources/Items/wheat.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wheat_seeds", Name = "Wheat Seeds", ImagePath = "/ImageResources/Items/wheat_seeds.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_candle", Name = "White Candle", ImagePath = "/ImageResources/Items/white_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_concrete", Name = "White Concrete", ImagePath = "/ImageResources/Items/white_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_concrete_powder", Name = "White Concrete Powder", ImagePath = "/ImageResources/Items/white_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_dye", Name = "White Dye", ImagePath = "/ImageResources/Items/white_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_glazed_terracotta", Name = "White Glazed Terracotta", ImagePath = "/ImageResources/Items/white_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_shulker_box", Name = "White Shulker Box", ImagePath = "/ImageResources/Items/white_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_stained_glass", Name = "White Stained Glass", ImagePath = "/ImageResources/Items/white_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_terracotta", Name = "White Terracotta", ImagePath = "/ImageResources/Items/white_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_tulip", Name = "White Tulip", ImagePath = "/ImageResources/Items/white_tulip.png" });
            defaultItems.Add(new Items() { ID = "minecraft: white_wool", Name = "White Wool", ImagePath = "/ImageResources/Items/white_wool.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wither_rose", Name = "Wither Rose", ImagePath = "/ImageResources/Items/wither_rose.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wooden_axe", Name = "Wooden Axe", ImagePath = "/ImageResources/Items/wooden_axe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wooden_hoe", Name = "Wooden Hoe", ImagePath = "/ImageResources/Items/wooden_hoe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wooden_pickaxe", Name = "Wooden Pickaxe", ImagePath = "/ImageResources/Items/wooden_pickaxe.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wooden_shovel", Name = "Wooden Shovel", ImagePath = "/ImageResources/Items/wooden_shovel.png" });
            defaultItems.Add(new Items() { ID = "minecraft: wooden_sword", Name = "Wooden Sword", ImagePath = "/ImageResources/Items/wooden_sword.png" });
            defaultItems.Add(new Items() { ID = "minecraft: writable_book", Name = "Writable Book", ImagePath = "/ImageResources/Items/writable_book.png" });
            defaultItems.Add(new Items() { ID = "minecraft: written_book", Name = "Written Book", ImagePath = "/ImageResources/Items/written_book.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_candle", Name = "Yellow Candle", ImagePath = "/ImageResources/Items/yellow_candle.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_concrete", Name = "Yellow Concrete", ImagePath = "/ImageResources/Items/yellow_concrete.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_concrete_powder", Name = "Yellow Concrete Powder", ImagePath = "/ImageResources/Items/yellow_concrete_powder.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_dye", Name = "Yellow Dye", ImagePath = "/ImageResources/Items/yellow_dye.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_glazed_terracotta", Name = "Yellow Glazed Terracotta", ImagePath = "/ImageResources/Items/yellow_glazed_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_shulker_box", Name = "Yellow Shulker Box", ImagePath = "/ImageResources/Items/yellow_shulker_box.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_stained_glass", Name = "Yellow Stained Glass", ImagePath = "/ImageResources/Items/yellow_stained_glass.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_terracotta", Name = "Yellow Terracotta", ImagePath = "/ImageResources/Items/yellow_terracotta.png" });
            defaultItems.Add(new Items() { ID = "minecraft: yellow_wool", Name = "Yellow Wool", ImagePath = "/ImageResources/Items/yellow_wool.png" });

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
