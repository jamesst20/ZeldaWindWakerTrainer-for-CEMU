using System.Collections.Generic;

namespace ZeldaWindWakerTrainer
{
    internal class GameItems
    {
        public static GameItems Instance { get; } = new GameItems();

        private GameItems() { }

        public static IEnumerable<Item> GetAllItems()
        {
            return Item.Instances;
        }

        public static Item? GetItemById(int id)
        {
            foreach(Item item in GetAllItems())
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public readonly Item JoyPendant = new Item("Joy pendant", 31);
        public readonly Item Telescope = new Item("Telescope", 32);
        public readonly Item TingleBottle = new Item("Tingle Bottle", 33);
        public readonly Item PictoBoxCamera = new Item("Picto Box (Camera)", 35);
        public readonly Item SpoilsBag = new Item("Spoils Bag", 36);
        public readonly Item GrapplingHook = new Item("Grappling Hook", 37);
        public readonly Item DeluxePictoBox = new Item("Deluxe Picto Box", 38);
        public readonly Item HeroBowNormal = new Item("Hero's Bow (Normal)", 39);
        public readonly Item IronBoots = new Item("Iron Boots", 41);
        public readonly Item MagicArmor = new Item("Magic Armor", 42);
        public readonly Item BaitBag = new Item("Bait Bag", 44);
        public readonly Item Boomerang = new Item("Boomerang", 45);
        public readonly Item Hookshot = new Item("Hookshot", 47);
        public readonly Item DeliveryBag = new Item("Delivery Bag", 48);
        public readonly Item Bomb = new Item("Bomb", 49);
        public readonly Item SkullHammer = new Item("Skull Hammer", 51);
        public readonly Item DekuLeaf = new Item("Deku Leaf", 52);
        public readonly Item HeroBowIceFire = new Item("Hero's Bow (Ice & Fire)", 53);
        public readonly Item HeroBowIceFireLight = new Item("Hero's Bow (Ice & Fire & Light)", 54);
        public readonly Item SkullNecklace = new Item("Skull Necklace", 69);
        public readonly Item BokoBabaSeed = new Item("Boko Baba Seed", 70);
        public readonly Item GoldenFeather = new Item("Golden Feather", 71);
        public readonly Item KnightCrest = new Item("Knight's Crest", 72);
        public readonly Item RedChuJelly = new Item("Red Chu Jelly", 73);
        public readonly Item GreenChuJelly = new Item("Green Chu Jelly", 74);
        public readonly Item BlueChuJelly = new Item("Blue Chu Jelly", 75);
        public readonly Item EmptyBottle = new Item("Empty Bottle", 80);
        public readonly Item RedPotion = new Item("Red Potion", 81);
        public readonly Item GreenPotion = new Item("Green Potion", 82);
        public readonly Item BluePotion = new Item("Blue Potion", 83);
        public readonly Item ElixirSoupHalf = new Item("Elixir Soup (1/2)", 84);
        public readonly Item ElixirSoup = new Item("Elixir Soup", 85);
        public readonly Item Water = new Item("Water", 86);
        public readonly Item Fairy = new Item("Fairy", 87);
        public readonly Item ForestFirefly = new Item("Forest Firefly", 88);
        public readonly Item ForestWater = new Item("Forest Water", 89);
        public readonly Item AllPurposeBait = new Item("All-Purpose Bait", 130);
        public readonly Item HyoiPear = new Item("Hyoi Pear", 131);
        public readonly Item TownFlower = new Item("Town Flower", 140);
        public readonly Item SeaFlower = new Item("Sea Flower", 141);
        public readonly Item ExoticFlower = new Item("Exotic Flower", 142);
        public readonly Item HeroFlag = new Item("Hero's Flag", 143);
        public readonly Item BigCatchFlag = new Item("Big Catch Flag", 144);
        public readonly Item BigSaleFlag = new Item("Big Sale Flag", 145);
        public readonly Item Pinwheel = new Item("Pinwheel", 146);
        public readonly Item SickleMoonFlag = new Item("Sickle Moon Flag", 147);
        public readonly Item SkullTowerIdol = new Item("Skull Tower Idol", 148);
        public readonly Item FountainIdol = new Item("Fountain Idol", 149);
        public readonly Item PostmanStatue = new Item("Postman Statue", 150);
        public readonly Item ShopGuruStatue = new Item("Shop Guru Statue", 151);
        public readonly Item FatherLetter = new Item("Father's Letter", 152);
        public readonly Item NoteToMom = new Item("Note to Mom", 153);
        public readonly Item MaggieLetter = new Item("Maggie's Letter", 154);
        public readonly Item MoblinLetter = new Item("Moblin's Letter", 155);
        public readonly Item CabanaDeed = new Item("Cabana Deed", 156);
        public readonly Item ComplimentaryId = new Item("Complimentary ID", 157);
        public readonly Item FillUpCoupon = new Item("Fill-up Coupon", 158);
    }
}
