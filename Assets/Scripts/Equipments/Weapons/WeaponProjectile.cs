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
        /// Velocity of the projectile
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// The end velocity goal
        /// </summary>
        public Vector2 VelocityGoal;

        /// <summary>
        /// The actual hit box
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

        /// <summary>
        /// Called once every 1/30 of a second
        /// </summary>
        protected void FixedUpdate()
        {
            this.Velocity = Vector2.Lerp(this.Velocity, this.VelocityGoal, 0.3f);
            this.transform.position += (Vector3)this.Velocity;
            this.transform.eulerAngles = new Vector3(0, 0, Utils.Atan2(this.Velocity) * Mathf.Rad2Deg);
        }
    }
}
