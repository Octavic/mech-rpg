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
    using UnityEngine;

    /// <summary>
    /// Defines a weapon that fires a projectile
    /// </summary>
    public class ProjectileWeapon : RapidFireWeapon
    {
        /// <summary>
        /// A list of muzzle locations
        /// </summary>
        public List<GameObject> MuzzleLocations;

        /// <summary>
        /// What's the delay between each projectile
        /// </summary>
        public float FireDelay;

        /// <summary>
        /// The prefab for a projectile to be fired
        /// </summary>
        public WeaponProjectile ProjectilePrefab;

        /// <summary>
        /// How many projectiles has been fired for this sequence
        /// </summary>
        private int _fired;
        private float _fireDelay;

        /// <summary>
        /// Spawns a new projectile
        /// </summary>
        /// <returns></returns>
        protected virtual WeaponProjectile SpawnProjectile()
        {
            var newProjectile = Instantiate(this.ProjectilePrefab);
            if (!this.Mech.IsFacingRight)
            {
                newProjectile.Velocity = Utils.FlipX(newProjectile.Velocity);
            }

            return newProjectile;
        }

        /// <summary>
        /// Called when the weapon is fired
        /// </summary>
        public override void Fire()
        {
            this._fired = 0;
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            this._fired = this.MuzzleLocations.Count;
            base.Start();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            if (this._fireDelay > 0)
            {
                this._fireDelay -= Time.deltaTime;
            }

            if (this._fireDelay <=0  && this._fired < this.MuzzleLocations.Count)
            {
                this.Animatable.PlayClip("fire", 1, true);
                this.EquippedOnArm.PlayClip(this.ArmAnimationClipName, 1, true);

                var newProjectile = this.SpawnProjectile();
                newProjectile.transform.position = this.MuzzleLocations[this._fired].transform.position;
                this._fired++;
                this._fireDelay = this.FireDelay;
            }
            base.Update();
        }
    }
}
