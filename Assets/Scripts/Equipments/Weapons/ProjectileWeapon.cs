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
    public class ProjectileWeapon : RapidFireWeapon
    {
        /// <summary>
        /// The prefab for a projectile to be fired
        /// </summary>
        public WeaponProjectile ProjectilePrefab;

        /// <summary>
        /// Called when the weapon is fired
        /// </summary>
        public override void Fire()
        {
            this.Animatable.PlayClip("fire");
            this.EquippedOnArm.PlayClip("fire");

            var newProjectile = Instantiate(this.ProjectilePrefab);
            if (!this.Mech.IsFacingRight)
            {
                newProjectile.Velocity = Utils.FlipX(newProjectile.Velocity);
                newProjectile.Acceleration = Utils.FlipX(newProjectile.Acceleration);
            }

            newProjectile.transform.position = this.MuzzleLocation.transform.position;
        }
    }
}
