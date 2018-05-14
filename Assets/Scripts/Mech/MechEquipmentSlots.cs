//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MechEquipmentSlots.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Equipments;

    /// <summary>
    /// Defines a mech's equipment slots
    /// </summary>
    [Serializable]
    public struct MechEquipmentSlots
    {
        public EquipmentSlot LeftShoulder;
        public EquipmentSlot RightShoulder;
        public EquipmentSlot LeftArm;
        public EquipmentSlot RightArm;
    }
}
