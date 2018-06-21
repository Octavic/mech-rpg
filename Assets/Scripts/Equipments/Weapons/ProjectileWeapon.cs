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
        /// Spawns a new projectile
        /// </summary>
        /// <returns></returns>
        protected virtual WeaponProjectile SpawnProjectile()
        {
        }

        /// <summary>
        /// Called when the weapon is fired
        /// </summary>
        public override void Fire()
        {
            foreach (var muzzleLocation in this.MuzzleLocations)
            {
                this.Animatable.PlayClip("fire");
                this.EquippedOnArm.PlayClip("fire");

                var newProjectile = Instantiate(this.ProjectilePrefab);
                if (!this.Mech.IsFacingRight)
                {
                    newProjectile.Velocity = Utils.FlipX(newProjectile.Velocity);
                    newProjectile.Acceleration = Utils.FlipX(newProjectile.Acceleration);
                }

                newProjectile.transform.position = muzzleLocation.transform.position;
            }
        }
    }
}
