//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEquipment.cs">
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
    using EquipmentProperty;

    /// <summary>
    /// Defines the base of a mech Equipment
    /// </summary>
    public abstract class BaseEquipment : MonoBehaviour
    {
        /// <summary>
        /// Id of the quipment
        /// </summary>
        public int EquipmentId;

        /// <summary>
        /// Name of the equipment
        /// </summary>
        public string EquipmentName;

        /// <summary>
        /// Rarity for the equipment
        /// </summary>
        public EquipmentRarity Rarity;

        /// <summary>
        /// Class of the weapon
        /// </summary>
        public EquipmentClass Class;

        /// <summary>
        /// If the weapon can be mounted on shoulder
        /// </summary>
        public bool CanMountShoulder;

        /// <summary>
        /// If the weapon can be mounted on arms
        /// </summary>
        public bool CanMountArms;

        /// <summary>
        /// A list of Equipment properties
        /// </summary>
        public List<BaseEquipmentProperty> Properties { get; private set; }
    }
}
