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
        /// How much the velocity changes per second
        /// </summary>
        public Vector2 Acceleration;

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
            this.Velocity = new Vector2();
            this.Acceleration = new Vector2();
            this.GetComponent<SpriteRenderer>().enabled = false;
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
            this.Velocity += this.Acceleration * Time.deltaTime;
            this.transform.position += (Vector3)this.Velocity * Time.deltaTime ;
            this.transform.eulerAngles = new Vector3(0, 0, Utils.Atan2(this.Velocity) * Mathf.Rad2Deg);
        }
    }
}
