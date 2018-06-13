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
    using Mech;

    /// <summary>
    /// Defines the base of a mech Equipment
    /// </summary>
    public abstract class BaseEquipment : MonoBehaviour
    {
        /// <summary>
        /// THe mech that this equipment is equipped on
        /// </summary>
        public BaseMech Mech;

        /// <summary>
        /// The arm that this equipment is equipped on
        /// </summary>
        public MechArm EquippedOnArm;

        /// <summary>
        /// Id of the equipment
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
        /// The base equipment stats
        /// </summary>
        public EquipmentStats BaseStats;

        /// <summary>
        /// If the weapon can be mounted on shoulder
        /// </summary>
        public virtual bool IsArmWeapon { get; protected set; }

        /// <summary>
        /// If the weapon can be mounted on arms
        /// </summary>
        public virtual bool IsShoulderWeapon
        {
            get
            {
                return !this.IsArmWeapon;
            }
        }

        /// <summary>
        /// A list of Equipment properties
        /// </summary>
        public List<BaseEquipmentProperty> Properties { get; private set; }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected virtual void Start()
        {
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void Update()
        {
        }
        
        /// The call order goes as following
        /// Short Press: OnPressStart() => OnShortRelease()
        /// Long Press: OnPressStart() => OnLongPressStart() => OnLongPressRelease()

        /// <summary>
        /// Called when the button to fire is pressed and then released
        /// </summary>
        public virtual void OnShortRelease()
        {
        }

        /// <summary>
        /// Called when the button is held down 
        /// </summary>
        public virtual void OnPressStart()
        {
        }

        /// <summary>
        /// Called when the player has the button held long enough
        /// </summary>
        public virtual void OnLongPressStart()
        {
        }

        /// <summary>
        /// Called when the held button is released
        /// </summary>
        public virtual void OnLongRelease()
        {
        }
    }
}
