//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EquipmentRarity.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines the rarity of a Equipment
    /// </summary>
    [Serializable]
    public struct EquipmentRarity
    {
        /// <summary>
        /// Name of the rarity
        /// </summary>
        public string Name;

        /// <summary>
        /// The color of the rarity
        /// </summary>
        public Color Color;
    }
}
