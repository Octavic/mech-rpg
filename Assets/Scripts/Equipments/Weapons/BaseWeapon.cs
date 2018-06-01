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
        /// If the weapon is being fired right now
        /// </summary>
        protected bool _isFiring;

        /// <summary>
        /// Called when the bu
        /// </summary>
        public override void OnLongPressStart()
        {
            this._isFiring = true;
            this.Animatable.PlayClip("fire");
            this.EquippedOnArm.PlayClip("fire");
            base.OnLongPressStart();
        }

        /// <summary>
        /// Called when the weapon is released
        /// </summary>
        public override void OnButtonRelease()
        {
            this._isFiring = false;
            this.Animatable.PlayClip("still");
            this.EquippedOnArm.PlayClip("still");
            base.OnButtonRelease();
        }

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

        protected override void Update()
        {
            if (this._isFiring)
            {
                MainCamera.CurrentInstance.Shake(0.05f);
            }

            base.Update();
        }
    }
}
