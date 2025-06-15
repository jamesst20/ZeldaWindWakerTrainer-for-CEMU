namespace ZeldaWindWakerTrainer
{
    internal class GameOffsets
    {
        /**
         * Player position
         */
        public static readonly Offset PLAYER_Z = new Offset(0x1046CD4C, 4, MemoryType.BigEndian);
        public static readonly Offset PLAYER_Y = new Offset(0x1046CD4C + 0x04, 4, MemoryType.BigEndian);
        public static readonly Offset PLAYER_X = new Offset(0x1046CD4C - 0x04, 4, MemoryType.BigEndian);
        
        /**
         * In quarters. 3 Heart = 12. Max = 80
         */
        public static readonly Offset MAX_HEALTH = new Offset(0x145B7B80, 2, MemoryType.BigEndian);
        public static readonly Offset HEALTH = new Offset(0x145b7b82, 2, MemoryType.BigEndian);

        public static readonly Offset RUBY_UI = new Offset(0x10474C5E, 2, MemoryType.BigEndian);
        public static readonly Offset RUBY_COUNT = new Offset(0x145B7B84, 2, MemoryType.BigEndian);
        public static readonly Offset MAX_RUBY_COUNT = new Offset(0x145B7B92, 1, MemoryType.BigEndian);

        /**
         * 0 for None
         * 16 for the base bar
         * 32 for max
         */
        public static readonly Offset MAX_STAMINA = new Offset(0x145B7B93, 1, MemoryType.BigEndian);
        public static readonly Offset STAMINA = new Offset(0x145B7B94, 1, MemoryType.BigEndian);
        
        /**
         * Player breath.
         * 0 = No more breath or outside water
         * 900 = Max breath
         */
        public static readonly Offset WATER_BREATH = new Offset(0x10474BFE, 2, MemoryType.BigEndian);
        
        /**
         * ID 1 and ID 2 is used for the Swift (fast) sail and the Wind Waker (music instrument)
         */
        public static readonly Offset INVENTORY_ITEM_ID_0 = new Offset(0x145B7BBC, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_SWIFT_SAIL= new Offset(0x145B7BBD, 1, MemoryType.BigEndian); // ITEM ID = 119
        public static readonly Offset INVENTORY_ITEM_ID_WIND_WAKER = new Offset(0x145B7BBE, 1, MemoryType.BigEndian); // ITEM_ID = 34
        public static readonly Offset INVENTORY_ITEM_ID_3 = new Offset(0x145B7BBF, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_4 = new Offset(0x145B7BC0, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_5 = new Offset(0x145B7BC1, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_6 = new Offset(0x145B7BC2, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_7 = new Offset(0x145B7BC3, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_8 = new Offset(0x145B7BC4, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_9 = new Offset(0x145B7BC5, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_10 = new Offset(0x145B7BC6, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_11 = new Offset(0x145B7BC7, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_12 = new Offset(0x145B7BC8, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_13 = new Offset(0x145B7BC9, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_14 = new Offset(0x145B7BCA, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_15 = new Offset(0x145B7BCB, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_16 = new Offset(0x145B7BCC, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_17 = new Offset(0x145B7BCD, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_18 = new Offset(0x145B7BCE, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_19 = new Offset(0x145B7BCF, 1, MemoryType.BigEndian);
        public static readonly Offset INVENTORY_ITEM_ID_20 = new Offset(0x145B7BD0, 1, MemoryType.BigEndian);

        public static readonly Offset SPOILS_BAG_ITEM_ID_0 = new Offset(0x145B7BF6, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_1 = new Offset(0x145B7BF7, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_2 = new Offset(0x145B7BF8, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_3 = new Offset(0x145B7BF9, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_4 = new Offset(0x145B7BFA, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_5 = new Offset(0x145B7BFB, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_6 = new Offset(0x145B7BFC, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_ID_7 = new Offset(0x145B7BFD, 1, MemoryType.BigEndian);

        /**
         * Ordered in memory order. Indexes match the ITEM_ID indexes. They are not ordered the same
         * way in memory.
         */
        public static readonly Offset SPOILS_BAG_ITEM_QTY_3 = new Offset(0x145B7C1C, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_5 = new Offset(0x145B7C1D, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_2 = new Offset(0x145B7C1E, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_4 = new Offset(0x145B7C1F, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_1 = new Offset(0x145B7C20, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_6 = new Offset(0x145B7C21, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_7 = new Offset(0x145B7C22, 1, MemoryType.BigEndian);
        public static readonly Offset SPOILS_BAG_ITEM_QTY_0 = new Offset(0x145B7C23, 1, MemoryType.BigEndian);


        /**
         * 0 = No sword
         * 1 = Regular sword
         * 3 = Master Sword (No power)
         * 7 = Master Sword (Half power)
         * 15 = Master Sword (With all powers)
         */
        public static readonly Offset SWORD_TYPE = new Offset(0x145B7C34, 1, MemoryType.BigEndian);

        /**
         * 0 = No sheild
         * 1 = Regular wooden shield
         * 3 = Miror shield
         */
        public static readonly Offset SHIELD_TYPE = new Offset(0x145B7C35, 1, MemoryType.BigEndian);

        /**
         * Booleans
         */
        public static readonly Offset STRENGTH_BRACELET = new Offset(0x145B7C36, 1, MemoryType.BigEndian);
        public static readonly Offset PIRATE_CHARM = new Offset(0x145B7C37, 1, MemoryType.BigEndian);
        public static readonly Offset HERO_AMULET = new Offset(0x145B7C38, 1, MemoryType.BigEndian);

        /**
         * Binary mask
         * 255 / 11111111 = All
         */
        public static readonly Offset TRIFORCE_FRAGMENTS = new Offset(0x145B7C3E, 1, MemoryType.BigEndian);

        /**
         * Binary mask
         * 7 / 00000111 = All
         */
        public static readonly Offset PEARLS = new Offset(0x145B7C3F, 1, MemoryType.BigEndian);

        /**
         * Maps. Binary masks
         * 11111111 = All
         */
        // Map 29, 34, 18, 16, 28, 4, 3, 40
        public static readonly Offset MAP_PACK_1 = new Offset(0x145B7C54, 1, MemoryType.BigEndian);
        // Map 2, 38, 39, 24, 6, 12, 35, 1
        public static readonly Offset MAP_PACK_2 = new Offset(0x145B7C55, 1, MemoryType.BigEndian);
        // Map 11, 15, 30, 20, 5, 23, 31, 33
        public static readonly Offset MAP_PACK_3 = new Offset(0x145B7C56, 1, MemoryType.BigEndian);
        // Map Map Triforce 1, 42, Triforce 2, 43, Triforce 3, 44, 45, 46
        public static readonly Offset MAP_PACK_4 = new Offset(0x145B7C57, 1, MemoryType.BigEndian);
        // Map Secret Cave, Light Ring, Platform, Beedle's, Submarine
        public static readonly Offset MAP_PACK_5 = new Offset(0x145B7C58, 1, MemoryType.BigEndian);
        // Map 21, 27, 7, IN-credible, Octo, Great Fairy, Island Hearts, Sea Hearts
        public static readonly Offset MAP_PACK_6 = new Offset(0x145B7C59, 1, MemoryType.BigEndian);
        // Map 25, 37, 8, 26, 41, 19, 32, 13
        public static readonly Offset MAP_PACK_7 = new Offset(0x145B7C5A, 1, MemoryType.BigEndian);
        // Map 10, 14, Tingle's, Ghost Ship, 9, 22, 36, 17
        public static readonly Offset MAP_PACK_8 = new Offset(0x145B7C5B, 1, MemoryType.BigEndian);

        /**
         * 0x0 for not unlocked
         * 0x1 or 0x3 for unlocked. Both are used by the game, why ?
         * Hypothesis : 0x3 are for maps already unlocked at the beginning of the game. 0x1 for maps unlocked by the frog.
         * Conclusion: A1, B4, G2 should be 0x3.
         */
        public static readonly Offset MAP_UNLOCKED_A1 = new Offset(0x145B7C84, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A2 = new Offset(0x145B7C85, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A3 = new Offset(0x145B7C86, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A4 = new Offset(0x145B7C87, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A5 = new Offset(0x145B7C88, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A6 = new Offset(0x145B7C89, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_A7 = new Offset(0x145B7C8A, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_B1 = new Offset(0x145B7C8B, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B2 = new Offset(0x145B7C8C, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B3 = new Offset(0x145B7C8D, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B4 = new Offset(0x145B7C8E, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B5 = new Offset(0x145B7C8F, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B6 = new Offset(0x145B7C90, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_B7 = new Offset(0x145B7C91, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_C1 = new Offset(0x145B7C92, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C2 = new Offset(0x145B7C93, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C3 = new Offset(0x145B7C94, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C4 = new Offset(0x145B7C95, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C5 = new Offset(0x145B7C96, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C6 = new Offset(0x145B7C97, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_C7 = new Offset(0x145B7C98, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_D1 = new Offset(0x145B7C99, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D2 = new Offset(0x145B7C9A, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D3 = new Offset(0x145B7C9B, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D4 = new Offset(0x145B7C9C, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D5 = new Offset(0x145B7C9D, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D6 = new Offset(0x145B7C9E, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_D7 = new Offset(0x145B7C9F, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_E1 = new Offset(0x145B7CA0, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E2 = new Offset(0x145B7CA1, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E3 = new Offset(0x145B7CA2, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E4 = new Offset(0x145B7CA3, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E5 = new Offset(0x145B7CA4, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E6 = new Offset(0x145B7CA5, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_E7 = new Offset(0x145B7CA6, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_F1 = new Offset(0x145B7CA7, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F2 = new Offset(0x145B7CA8, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F3 = new Offset(0x145B7CA9, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F4 = new Offset(0x145B7CAA, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F5 = new Offset(0x145B7CAB, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F6 = new Offset(0x145B7CAC, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_F7 = new Offset(0x145B7CAD, 1, MemoryType.BigEndian);

        public static readonly Offset MAP_UNLOCKED_G1 = new Offset(0x145B7CAE, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G2 = new Offset(0x145B7CAF, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G3 = new Offset(0x145B7CB0, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G4 = new Offset(0x145B7CB1, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G5 = new Offset(0x145B7CB2, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G6 = new Offset(0x145B7CB3, 1, MemoryType.BigEndian);
        public static readonly Offset MAP_UNLOCKED_G7 = new Offset(0x145B7CB4, 1, MemoryType.BigEndian);

        /**
         * Binary mask
         * 10101 = All decrypted
         * Game use 0x255 ?
         */ 
        public static readonly Offset MAP_TRIFORCE_DECRYPTED = new Offset(0x145B7CC5, 1, MemoryType.BigEndian);

        public static readonly Offset BEEDLE_SHOP_POINT = new Offset(0x145B822A, 1, MemoryType.BigEndian);


        // Telescope : Game use 5 instead of 1 for an unknown reason. Both works.
        public static readonly Offset UNLOCK_ITEM_TELESCOPE = new Offset(0x145B7BD1, 1, MemoryType.BigEndian);
        // Sail : 1 = Normal, 3 = Swift sail (fast)
        public static readonly Offset UNLOCK_ITEM_SAIL = new Offset(0x145B7BD2, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_WIND_WAKER = new Offset(0x145B7BD3, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_GRAPPLING_HOOK = new Offset(0x145B7BD4, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_SPOILS_BAG = new Offset(0x145B7BD5, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_BOOMERANG = new Offset(0x145B7BD6, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_DEKU_LEAF = new Offset(0x145B7BD7, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_TINGLE_BOTTLE = new Offset(0x145B7BD8, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_PICTO_BOX = new Offset(0x145B7BD9, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_IRON_BOOTS = new Offset(0x145B7BDA, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_MAGIC_ARMOR = new Offset(0x145B7BDB, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_BAIT_BAG = new Offset(0x145B7BDC, 1, MemoryType.BigEndian);
        // Bow : 1 = normal, 3 = fire & ice, 7 = fire & ice & light
        public static readonly Offset UNLOCK_ITEM_BOW = new Offset(0x145B7BDD, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_BOMB = new Offset(0x145B7BDE, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_DELIVERY_BAG = new Offset(0x145B7BE3, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_HOOKSHOT = new Offset(0x145B7BE4, 1, MemoryType.BigEndian);
        public static readonly Offset UNLOCK_ITEM_SKULL_HAMMER = new Offset(0x145B7BE5, 1, MemoryType.BigEndian);


        public static readonly Offset BOW_ARROW_QTY = new Offset(0x145B7BE9, 1, MemoryType.BigEndian);
        public static readonly Offset BOMB_QTY = new Offset(0x145B7BEA, 1, MemoryType.BigEndian);
        public static readonly Offset BOW_ARROW_MAX_QTY = new Offset(0x145B7BEF, 1, MemoryType.BigEndian);
        public static readonly Offset BOMB_MAX_QTY = new Offset(0x145B7BF0, 1, MemoryType.BigEndian);


        public static readonly Offset SONGS_UNLOCKED = new Offset(0x145B7C3D, 1, MemoryType.BigEndian);
    }
}
