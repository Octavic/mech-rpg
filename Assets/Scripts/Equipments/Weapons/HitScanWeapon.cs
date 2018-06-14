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
    using Map;

    /// <summary>
    /// Defines a hit scan weapon
    /// </summary>
    public class HitScanWeapon : RapidFireWeapon
    {
        /// <summary>
        /// The pellet count. When it's not a whole number, a random die is rolled to see if an extra bullet is shot
        /// </summary>
        public float PelletCount;

        /// <summary>
        /// The screen shake each time the gun fire
        /// </summary>
        public float ScreenShake;

        /// <summary>
        /// The bulletLine prefab
        /// </summary>
        public BulletLine BulletLinePrefab;

        /// <summary>
        /// The hit of the bullet
        /// </summary>
        public WeaponHitStat BaseHit;

        /// <summary>
        /// Fires the weapon
        /// </summary>
        public override void Fire()
        {
            var facingRightFactor = this.Mech.IsFacingRight ? 1 : -1;

            // Set overriding animation
            this.EquippedOnArm.PlayClip("fire", 1.0f, true);
            this.Animatable.PlayClip("fire", 1.0f, true);

            // Set shoot pellet count
            int shootCount = (int)this.PelletCount;
            float diff = this.PelletCount - shootCount;
            if (GlobalRandom.NextFloat() < diff)
            {
                shootCount++;
            }

            // Camera shake
            MainCamera.CurrentInstance.Shake(this.ScreenShake);

            // Adjust knock back
            var hitX = this.BaseHit.KnockBack.x * facingRightFactor;
            var adjustedHit = new WeaponHitStat(this.BaseHit);
            adjustedHit.KnockBack = new Vector2(hitX, this.BaseHit.KnockBack.y);

            // Apply recoil
            var recoilX = -this.BaseStats.Recoil * facingRightFactor;
            this.Mech.ApplyKnockback(new Vector2(recoilX, 0), this.BaseStats.Recoil,0);

            // Fire  all pellets
            for (int shoot = 0; shoot < shootCount; shoot++)
            {
                // Determine inaccuracy
                var inaccuracy = (100 - this.BaseStats.Accuracy) / 200 * GlobalRandom.NextFloat() * Mathf.PI;
                if (GlobalRandom.NextBool())
                {
                    inaccuracy *= -1;
                }

                var shootX = Mathf.Cos(inaccuracy) * facingRightFactor;
                var shootY = Mathf.Sin(inaccuracy);

                var rayCastHits = Physics2D.RaycastAll(this.MuzzleLocation.transform.position, new Vector2(shootX, shootY));
                for (var i = 0; i < rayCastHits.Length; i++)
                {
                    var curHit = rayCastHits[i];
                    var hittable = curHit.collider.GetComponent<IHittable>();
                    if (hittable != null && hittable.Faction != adjustedHit.Faction)
                    {
                        hittable.OnHit(adjustedHit);
                        var newBullet = Instantiate(this.BulletLinePrefab);
                        newBullet.OnBulletHit(this.MuzzleLocation.transform.position, curHit);
                        break;
                    }
                }
            }
        }
    }
}
