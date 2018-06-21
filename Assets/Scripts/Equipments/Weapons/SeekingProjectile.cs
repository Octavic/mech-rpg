//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SeekingProjectile.cs">
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
    /// Defines a missile
    /// </summary>
    public class SeekingProjectile : DetonateOnImpactProjectile
    {
        /// <summary>
        /// How fast the projectile can turn per second
        /// </summary>
        public float MaxTurning;

        /// <summary>
        /// The  target  that this projectile is going towards
        /// </summary>
        protected GameObject _target;

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            var enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);
            if (enemies.Length != 0)
            {
                this._target = enemies.OrderBy(enemy => (enemy.transform.position - this.transform.position).magnitude).First();
            }

            base.Start();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            if (this._target != null)
            {
                var goalAcceleration = this._target.transform.position - this.transform.position;
                var diffAcceleratio = Vector2.Lerp(this.Acceleration, goalAcceleration, 0.2f);
                this.Acceleration = diffAcceleratio.normalized * this.Acceleration.magnitude;
            }

            base.Update();
        }
    }
}
