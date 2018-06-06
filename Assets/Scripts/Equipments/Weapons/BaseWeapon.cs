//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseWeapon.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Animations;
    using Mech;

    /// <summary>
    /// Defines a base weapon
    /// </summary>
    public abstract class BaseWeapon : BaseEquipment
    {
        /// <summary>
        /// The animatable component
        /// </summary>
        Animatable Animatable;

        /// <summary>
        /// If using the weapon should prevent the mech from moving
        /// </summary>
        public bool ShouldGround;

        /// <summary>
        /// Called when the weapon is equipped
        /// </summary>
        public virtual void OnEquip(MechArm newArm)
        {
            this.EquippedOnArm = newArm;
        }

        public virtual void OnUnequip()
        {
            this.EquippedOnArm = null;
        }

        /// <summary>
        /// Used  for initialization
        /// </summary>
        protected override void Start()
        {
            this.Animatable = this.GetComponent<Animatable>();

            base.Start();
        }
    }
}
