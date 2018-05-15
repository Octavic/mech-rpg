//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EquipmentSlot.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Equipments;

    /// <summary>
    /// Defines a slot that equipment can be placed in
    /// </summary>
    [Serializable]
    public class EquipmentSlot
    {
        /// <summary>
        /// If the slot can mount shoulder weapons
        /// </summary>
        bool IsShoulder;

        /// <summary>
        /// If the gievn equipment fits in this slot
        /// </summary>
        /// <param name="equipment">Target equipment</param>
        /// <returns>True if the equipment fits</returns>
        public bool CanMount(BaseEquipment equipment)
        {
            return this.IsShoulder || equipment.IsShoulderWeapon;
        }
    }
}
