//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Terrain.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Mech;
    using Equipments.Weapons;

    /// <summary>
    /// Defines the terrain
    /// </summary>
    public class Terrain : MonoBehaviour, IHittable
    {
        public Factions Faction
        {
            get
            {
                return Factions.Environment;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            var floorCheck = collision.GetComponent<MechFloorCheck>();
            if (floorCheck)
            {
                floorCheck.Mech.IsAirborne = false;
            }

            var hitbox = collision.GetComponent<WeaponHitbox>();
            if (hitbox != null)
            {
                this.OnHit(hitbox.HitStat);
            }

            var projectile = collision.GetComponent<WeaponProjectile>();
            if (projectile != null)
            {
                projectile.OnHit(this);
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            var floorCheck = collision.GetComponent<MechFloorCheck>();
            if (floorCheck)
            {
                floorCheck.Mech.IsAirborne = true;
            }
        }

        public void OnHit(WeaponHitStat hit)
        {
        }
    }
}
