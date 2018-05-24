//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseMech.cs">
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
        /// Called when the bu
        /// </summary>
        public override void OnLongPressStart()
        {
            this.Animatable.PlayClip("fire");
            this.EquippedOnArm.PlayClip("fire");
            base.OnLongPressStart();
        }

        /// <summary>
        /// Called when the weapon is released
        /// </summary>
        public override void OnButtonRelease()
        {
            this.Animatable.PlayClip("still");
            this.EquippedOnArm.PlayClip("still");
            base.OnButtonRelease();
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
