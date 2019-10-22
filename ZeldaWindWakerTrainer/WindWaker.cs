using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Humanizer;

namespace ZeldaWindWakerTrainer
{
    internal class WindWaker
    {
        private readonly ProcessWrapper _processWrapper;
        public bool DisableWrite { get; set; }

        public WindWaker()
        {
            _processWrapper = new ProcessWrapper("Cemu");

            if (!_processWrapper.OpenProcess())
            {
                throw new Exception("Failed to open cemu process. Is it running ?");
            }
        }

        public string GetCemuPath()
        {
            return _processWrapper.GetProcessLocation();
        }

        public void SetBaseAddress(long baseAddress)
        {
            _processWrapper.SetBaseAddress(baseAddress);
        }

        public int GetMaxHealth()
        {
            return ReadOffset(GameOffsets.MAX_HEALTH);
        }

        public bool UpdateMaxHealth(int value)
        {
            return WriteOffset(GameOffsets.MAX_HEALTH, value);
        }

        public int GetHealth()
        {
            return ReadOffset(GameOffsets.HEALTH);
        }

        public bool UpdateHealth(int value)
        {
            return WriteOffset(GameOffsets.HEALTH, value);
        }

        public int GetMaxStaminaUnlock()
        {
            return ReadOffset(GameOffsets.MAX_STAMINA);
        }

        public bool UpdateMaxStamina(int value)
        {
            if (value != 0 && value != 16 && value != 32) return false;

            return WriteOffset(GameOffsets.MAX_STAMINA, value);
        }

        public int GetStamina()
        {
            return ReadOffset(GameOffsets.STAMINA);
        }

        public bool UpdateStamina(int quantity)
        {
            return WriteOffset(GameOffsets.STAMINA, quantity);
        }

        public bool GetWindWakerUnlocked()
        {
            return ReadOffset(GameOffsets.INVENTORY_ITEM_ID_WIND_WAKER) == 34;
        }

        public bool UpdateWindWakerUnlocked(bool value)
        {
            return 
                WriteOffset(GameOffsets.INVENTORY_ITEM_ID_WIND_WAKER, value ? 34 : 0) &&
                WriteOffset(GameOffsets.UNLOCK_ITEM_WIND_WAKER, value ? 1 : 0);
        }

        public bool GetHeroAmuletUnlocked()
        {
            return ReadOffset(GameOffsets.HERO_AMULET) != 0;
        }

        public bool UpdateHeroAmuletUnlocked(bool value)
        {
            return WriteOffset(GameOffsets.HERO_AMULET, value ? 1 : 0);
        }

        public bool GetPirateCharmUnlocked()
        {
            return ReadOffset(GameOffsets.PIRATE_CHARM) != 0;
        }

        public bool UpdatePirateCharmUnlocked(bool value)
        {
            return WriteOffset(GameOffsets.PIRATE_CHARM, value ? 1 : 0);
        }

        public int GetMaxRupee()
        {
            int value = ReadOffset(GameOffsets.MAX_RUBY_COUNT);

            if (value == 0) return 100;
            else if (value == 1) return 1000;
            else if (value == 2) return 5000;

            return -1;
        }

        public bool UpdateMaxRupee(int quantity)
        {
            int value = 0;
            if (quantity == 1000) value = 1;
            if (quantity == 5000) value = 2;

            return WriteOffset(GameOffsets.MAX_RUBY_COUNT, value);
        }

        public int GetRupee()
        {
            return ReadOffset(GameOffsets.RUBY_COUNT);
        }

        public bool UpdateRupee(int quantity)
        {
            return WriteOffset(GameOffsets.RUBY_COUNT, quantity) && WriteOffset(GameOffsets.RUBY_UI, quantity);
        }

        public bool GetPowerBracelets()
        {
            return ReadOffset(GameOffsets.STRENGTH_BRACELET) != 0;
        }

        public bool UpdatePowerBracelets(bool value)
        {
            return WriteOffset(GameOffsets.STRENGTH_BRACELET, value ? 1 : 0);
        }

        public bool[] GetTriforceFragments()
        {
            byte fragments = (byte)ReadOffset(GameOffsets.TRIFORCE_FRAGMENTS);
            return new bool[] {
                IsBitSet(fragments, 0),
                IsBitSet(fragments, 1),
                IsBitSet(fragments, 2),
                IsBitSet(fragments, 3),
                IsBitSet(fragments, 4),
                IsBitSet(fragments, 5),
                IsBitSet(fragments, 6),
                IsBitSet(fragments, 7)
            };
        }

        public bool UpdateTriforceFragments(bool[] fragments)
        {
            return WriteOffset(GameOffsets.TRIFORCE_FRAGMENTS, fragments);
        }

        public bool[] GetPearls()
        {
            byte pearls = (byte)ReadOffset(GameOffsets.PEARLS);
            return new bool[] {
                IsBitSet(pearls, 0), // Nayru
                IsBitSet(pearls, 1), // Din
                IsBitSet(pearls, 2) // Farore
            };
        }

        public bool UpdatePearls(bool[] pearls)
        {
            return WriteOffset(GameOffsets.PEARLS, pearls);
        }

        public bool GetMapUnlocked(string where)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"MAP_UNLOCKED_{where}");
            Offset offset = (Offset)myPropInfo.GetValue(null);
            return ReadOffset(offset) != 0;
        }

        public bool UpdateMapUnlocked(string where, bool unlocked)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"MAP_UNLOCKED_{where}");
            Offset offset = (Offset)myPropInfo.GetValue(null);

            int value = unlocked ? 1 : 0;
            if (unlocked && (where == "A1" || where == "B4" || where == "G2")) value = 3;

            return WriteOffset(offset, value);
        }

        public int GetInventoryItem(int inventoryId)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"INVENTORY_ITEM_ID_{inventoryId}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            return ReadOffset(offset);
        }

        public bool UpdateInventoryItem(int inventoryId, int itemId)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"INVENTORY_ITEM_ID_{inventoryId}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            Item? item = GameItems.GetItemById(itemId);
            return item.HasValue && WriteOffset(offset, item.Value.Id);
        }

        public int GetSpoilsBagInventoryItem(string index)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"SPOILS_BAG_ITEM_ID_{index}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            return ReadOffset(offset);
        }

        public bool UpdateSpoilsBagInventoryItem(string index, int id)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"SPOILS_BAG_ITEM_ID_{index}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            return WriteOffset(offset, id);
        }

        public int GetSpoilsBagInventoryItemQty(string index)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"SPOILS_BAG_ITEM_QTY_{index}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            return ReadOffset(offset);
        }

        public bool UpdateSpoilsBagInventoryItemQty(string index, int qty)
        {
            FieldInfo prop1 = typeof(GameOffsets).GetField($"SPOILS_BAG_ITEM_QTY_{index}");
            Offset offsetQty = (Offset)prop1.GetValue(GameItems.Instance);
            
            if (qty != 0) return WriteOffset(offsetQty, qty);

            FieldInfo prop2 = typeof(GameOffsets).GetField($"SPOILS_BAG_ITEM_ID_{index}");
            Offset offsetItem = (Offset)prop2.GetValue(GameItems.Instance);

            return WriteOffset(offsetQty, qty) && WriteOffset(offsetItem, 255);
        }

        public Dictionary<int, bool[]> GetMapFound()
        {
            Dictionary<int, bool[]> results = new Dictionary<int, bool[]>();
            foreach (int pack in new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })
            {
                FieldInfo myPropInfo = typeof(GameOffsets).GetField($"MAP_PACK_{pack}");
                Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);

                int value = ReadOffset(offset);
                results[pack] = new bool[] {
                    IsBitSet((byte)value, 0),
                    IsBitSet((byte)value, 1),
                    IsBitSet((byte)value, 2),
                    IsBitSet((byte)value, 3),
                    IsBitSet((byte)value, 4),
                    IsBitSet((byte)value, 5),
                    IsBitSet((byte)value, 6),
                    IsBitSet((byte)value, 7)
                };
            }
            return results;
        }

        public bool UpdateMapFound(int pack, int bit, bool value)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"MAP_PACK_{pack}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);
            return WriteSingleBit(offset, bit - 1, value);
        }

        public bool[] GetMapTriforceDecrypted()
        {
            int value = ReadOffset(GameOffsets.MAP_TRIFORCE_DECRYPTED);

            return new bool[]
            {
                IsBitSet((byte)value, 0),
                IsBitSet((byte)value, 2),
                IsBitSet((byte)value, 4)
            };
        }

        public bool UpdateTriforceDecrypted(int mapNo, bool value)
        {
            int bit = 1;

            if (mapNo != 1 && mapNo != 2 && mapNo != 3) return false;
            else if (mapNo == 2) bit = 3;
            else if (mapNo == 3) bit = 5;

            return WriteSingleBit(GameOffsets.MAP_TRIFORCE_DECRYPTED, bit - 1, value);
        }

        public int GetUnlockedItem(string item)
        {
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"UNLOCK_ITEM_{item.Underscore().ToUpper()}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);

            return ReadOffset(offset);
        }

        public bool UpdateUnlockedItem(string item, int value)
        {
            if (item == "Telescope" && value == 1) value = 5; // Optional but just to make it same as the game.
            FieldInfo myPropInfo = typeof(GameOffsets).GetField($"UNLOCK_ITEM_{item.Underscore().ToUpper()}");
            Offset offset = (Offset)myPropInfo.GetValue(GameItems.Instance);

            return WriteOffset(offset, value);
        }

        public int GetMaxArrowQty()
        {
            return ReadOffset(GameOffsets.BOW_ARROW_MAX_QTY);
        }

        public bool UpdateMaxArrowQty(int qty)
        {
            return WriteOffset(GameOffsets.BOW_ARROW_MAX_QTY, qty);
        }

        public int GetArrowQty()
        {
            return ReadOffset(GameOffsets.BOW_ARROW_QTY);
        }

        public bool UpdateArrowQty(int qty)
        {
            return WriteOffset(GameOffsets.BOW_ARROW_QTY, qty);
        }

        public int GetMaxBombQty()
        {
            return ReadOffset(GameOffsets.BOMB_MAX_QTY);
        }

        public bool UpdateMaxBombQty(int qty)
        {
            return WriteOffset(GameOffsets.BOMB_MAX_QTY, qty);
        }

        public int GetBombQty()
        {
            return ReadOffset(GameOffsets.BOMB_QTY);
        }

        public bool UpdateBombQty(int qty)
        {
            return WriteOffset(GameOffsets.BOMB_QTY, qty);
        }

        public bool[] GetSongsUnlocked()
        {
            int value = ReadOffset(GameOffsets.SONGS_UNLOCKED);

            return new bool[]
            {
                IsBitSet((byte)value, 0),
                IsBitSet((byte)value, 1),
                IsBitSet((byte)value, 2),
                IsBitSet((byte)value, 3),
                IsBitSet((byte)value, 4),
                IsBitSet((byte)value, 5)
            };
        }

        public bool UpdateSongUnlocked(int bit, bool value)
        {
            return WriteSingleBit(GameOffsets.SONGS_UNLOCKED, bit, value);
        }

        public int GetBeedlePoints()
        {
            return ReadOffset(GameOffsets.BEEDLE_SHOP_POINT);
        }

        public bool UpdateBeedlePoints(int qty)
        {
            return WriteOffset(GameOffsets.BEEDLE_SHOP_POINT, qty);
        }

        public int GetSwordType()
        {
            return ReadOffset(GameOffsets.SWORD_TYPE);
        }

        public bool UpdateSwordType(int type)
        {
            if (type != 0 && type != 1 && type != 3 && type != 7 && type != 15) return false;

            return WriteOffset(GameOffsets.SWORD_TYPE, type);
        }

        public int GetShieldType()
        {
            return ReadOffset(GameOffsets.SHIELD_TYPE);
        }

        public bool UpdateShieldType(int type)
        {
            if (type != 0 && type != 1 && type != 3) return false;

            return WriteOffset(GameOffsets.SHIELD_TYPE, type);
        }

        private static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        private bool WriteOffset(Offset offset, int value)
        {
            if (DisableWrite) return false;

            byte[] data;
            if (offset.Size == 1)
            {
                if (value > 255) return false;

                data = new byte[] { (byte)value };
            }
            else if (offset.Size == 2)
            {
                if (value > 65535) return false;
                data = BitConverter.GetBytes((short)value);
            }
            else
            {
                throw new Exception("32 Bits and 64 Bits types are currently not handled");
            }

            return _processWrapper.OverwriteMemoryProtection(offset.Address, offset.Size) && _processWrapper.WriteMemory(offset, data);
        }

        private bool WriteOffset(Offset offset, bool[] bitsValues)
        {
            if (DisableWrite) return false;
            if (offset.Size != 1) throw new Exception("Unsupported for now.");

            BitArray bits = new BitArray(8);
            for (int i = 0; i < bitsValues.Length; i++) bits[i] = bitsValues[i];

            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);

            return WriteOffset(offset, bytes[0]);
        }

        private bool WriteSingleBit(Offset offset, int bit, bool value)
        {
            if (DisableWrite) return false;
            if (offset.Size != 1) throw new Exception("Unsupported for now.");
            if (bit > 7) throw new Exception("Bit index are between 0 and 7");

            int currentValue = ReadOffset(offset);
            BitArray bits = new BitArray(new byte[] { (byte)currentValue });
            bits[bit] = value;

            byte[] newByte = new byte[1];
            bits.CopyTo(newByte, 0);

            return WriteOffset(offset, newByte[0]);
        }

        private int ReadOffset(Offset offset)
        {
            byte[] data = _processWrapper.ReadMemory(offset);

            if (data.Length != offset.Size) return -1;
            else if (data.Length == 1) return data[0];
            else if (data.Length == 2) return BitConverter.ToInt16(data, 0);
            
            throw new Exception("32 Bits and 64 Bits types are currently not handled");
        }
    }
}
