//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WeaponProjectile.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using Map;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a projectile that's shot by a weapon
    /// </summary>
    public abstract class WeaponProjectile : DelayedSelfDestroy
    {
        /// <summary>
        /// Velocity of the projectile
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// How much the velocity changes per second
        /// </summary>
        public Vector2 Acceleration;

        /// <summary>
        /// Called when the projectile hits something
        /// </summary>
        /// <param name="hittable">The "something" that's hit</param>
        public abstract void OnHit(IHittable hittable);

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            this.ResetTimer(false);
        }

        /// <summary>
        /// Called once every 1/30 of a second
        /// </summary>
        protected virtual void FixedUpdate()
        {
            this.Velocity += this.Acceleration * Time.deltaTime;
            this.transform.position += (Vector3)this.Velocity * Time.deltaTime ;
            this.transform.eulerAngles = new Vector3(0, 0, Utils.Atan2(this.Velocity) * Mathf.Rad2Deg);
        }
    }
}
