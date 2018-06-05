//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="HitScanWeapon.cs">
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
    using Utils;
    using Map;

    /// <summary>
    /// Defines a hitscan weapon
    /// </summary>
    public class HitScanWeapon : BaseWeapon
    {
        /// <summary>
        /// Stats about the weapon
        /// </summary>
        public GameObject MuzzleLocation;
        public WeaponHitStat BaseHit;

        public override void OnPressStart()
        {
            this.Fire();
            base.OnPressStart();
        }

        /// <summary>
        /// Fires the weapon
        /// </summary>
        protected void Fire()
        {
            var inaccuracy = (100 - this.BaseStats.Accuracy) / 100 * GlobalRandom.NextFloat() * Mathf.PI;
            if (GlobalRandom.NextBool())
            {
                inaccuracy *= -1;
            }

            var shootX = Mathf.Cos(inaccuracy);
            var shootY = Mathf.Sin(inaccuracy);
            if (!this.Mech.IsFacingRight)
            {
                shootX *= -1;
            }

            var rayCast = Physics2D.RaycastAll(this.MuzzleLocation.transform.position, new Vector2(shootX, shootY));
            for (var i = 0; i < rayCast.Length; i++)
            {
                var hittable = rayCast[i].collider.GetComponent<IHittable>();
                if (hittable != null)
                {
                    hittable.OnHit(this.BaseHit);
                    break;
                }
            }
        }
    }
}
