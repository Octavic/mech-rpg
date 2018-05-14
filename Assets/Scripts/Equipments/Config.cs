
namespace Assets.Scripts.Equipments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utils;

    public static class Config
    {
        private static WeightedList<EquipmentRarity> rarityList = new WeightedList<EquipmentRarity>();

        /// <summary>
        /// Used for initialization
        /// </summary>
        static Config()
        {
            rarityList.AddItem(EquipmentRarity.Common, 100);
            rarityList.AddItem(EquipmentRarity.Uncommon, 60);
            rarityList.AddItem(EquipmentRarity.Rare, 30);
            rarityList.AddItem(EquipmentRarity.Epic, 7);
            rarityList.AddItem(EquipmentRarity.Legendary, 2.5f);
        }

        /// <summary>
        /// Generates a new rarity for the next equipment
        /// </summary>
        /// <returns>A newly generated rarity</returns>
        public static EquipmentRarity RollRarity()
        {
            return rarityList.GetItem();
        }
    }
}
