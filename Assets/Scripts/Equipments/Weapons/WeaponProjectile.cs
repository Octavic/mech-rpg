//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WeaponProjectile.cs">
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
    /// Defines a projectile that's shot by a weapon
    /// </summary>
    public class WeaponProjectile : DelayedSelfDestroy
    {
        /// <summary>
        /// The actual hitbox
        /// </summary>
        public WeaponHitbox Hitbox;

        /// <summary>
        /// Called when the projectile hits something
        /// </summary>
        public void Detonate()
        {
            this.Hitbox.gameObject.SetActive(true);
            this.ResetTimer(true);
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected new void Start()
        {
            this.Hitbox.gameObject.SetActive(false);
            this.ResetTimer(false);
        }
    }
}
