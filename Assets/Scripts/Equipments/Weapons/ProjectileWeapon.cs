//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ProjectileWeapon.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines a weapon that fires a projectile
    /// </summary>
    public class ProjectileWeapon : BaseWeapon
    {
        /// <summary>
        /// The prefab for a projectile to be fired
        /// </summary>
        public WeaponProjectile ProjectilePrefab;

        /// <summary>
        /// Called when the player holds the button
        /// </summary>
        public override void OnPressStart()
        {
            base.OnPressStart();
        }
    }
}
