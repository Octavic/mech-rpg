//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEquipmentProperty.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.EquipmentProperty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The base Equipment's property
    /// </summary>
    public abstract class BaseEquipmentProperty
    {
        /// <summary>
        /// Id of the property
        /// </summary>
        public int Id;

        /// <summary>
        /// How strong the effect is. Always between 0 and 1 with 0 being the weakest, and 1 being the strongest
        /// </summary>
        public float Strength;

        /// <summary>
        /// Applies the Equipment property
        /// </summary>
        /// <param name="original">The original Equipment stats</param>
        /// <returns>The new Equipment stats with the property applied</returns>
        public abstract EquipmentStats ApplyEffect(EquipmentStats original);
    }
}
