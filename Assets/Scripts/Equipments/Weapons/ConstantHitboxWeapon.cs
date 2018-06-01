//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ConstantHitboxWeapon.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a weapon that when fired, activates a constant hitbox (machine gun, laser, etc)
    /// </summary>
    public class ConstantHitboxWeapon : BaseWeapon
    {
        /// <summary>
        /// The weapon's hitbox
        /// </summary>
        public WeaponHitbox Hitbox;

        /// <summary>
        /// Called when the weapon is used
        /// </summary>
        public override void OnLongPressStart()
        {
            this.Hitbox.gameObject.SetActive(true);
            base.OnLongPressStart();
        }

        /// <summary>
        /// Called when the weapon is used
        /// </summary>
        public override void OnButtonRelease()
        {
            this.Hitbox.gameObject.SetActive(false);
            base.OnButtonRelease();
        }
    }
}
