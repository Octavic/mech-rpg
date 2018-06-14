﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="HittableMapEntity.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Equipments.Weapons;
    using UnityEngine;

    public class HittableMapEntity : MapEntity, IHittable
    {
        /// <summary>
        /// Faction of this entity
        /// </summary>
        public Factions EntityFaction;

        public Factions Faction
        {
            get
            {
                return this.EntityFaction;
            }
        }

        /// <summary>
        /// Called when the map  entity is hit
        /// </summary>
        /// <param name="hit">The weapon hitbox</param>
        public virtual void OnHit(WeaponHitStat hit)
        {
        }

        /// <summary>
        /// Called when the trigger enters
        /// </summary>
        /// <param name="collider">The collision</param>
        protected virtual void OnTriggerEnter2D(Collider2D collider)
        {
            var hitbox = collider.GetComponent<WeaponHitbox>();
            if (hitbox != null)
            {
                this.OnHit(hitbox.HitStat);
            }

            var projectile = collider.GetComponent<WeaponProjectile>();
            if (projectile != null)
            {
                projectile.OnHit(this);
            }
        }
    }
}
