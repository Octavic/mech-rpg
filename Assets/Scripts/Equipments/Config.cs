//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Config.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains equipment related config and util functions
    /// </summary>
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
            rarityList.AddItem(EquipmentRarity.Epic, 10);
            rarityList.AddItem(EquipmentRarity.Legendary, 4f);
        }

        /// <summary>
        /// Generates a new rarity for the next equipment
        /// </summary>
        /// <returns>A newly generated rarity</returns>
        public static EquipmentRarity RollRarity()
        {
            return rarityList.GetItem();
        }

        public static float GetAttackDelay(float attackSpeed)
        {
            return Utils.Lerp(2.0f, 0.01f, attackSpeed / 100);
        }
    }
}
