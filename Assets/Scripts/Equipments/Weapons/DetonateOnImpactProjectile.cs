//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DetonateOnImpactProjectile.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Map;
    using UnityEngine;

    /// <summary>
    /// Defines a projectile that detonates upon impact
    /// </summary>
    public class DetonateOnImpactProjectile : WeaponProjectile
    {
        public float ScreenShake;

        /// <summary>
        /// Called when the projectile hits something
        /// </summary>
        public void Detonate()
        {
            MainCamera.CurrentInstance.Shake(this.ScreenShake);

            this.Hitbox.gameObject.SetActive(true);
            this.Velocity = new Vector2();
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.ResetTimer(true);
        }

        /// <summary>
        /// The actual hit box
        /// </summary>
        public WeaponHitbox Hitbox;

        public override void OnHit(IHittable hittable)
        {
            if (hittable.Faction != this.Hitbox.HitStat.Faction)
            {
                this.Detonate();
            }
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            this.Hitbox.gameObject.SetActive(false);

            base.Start();
        }
    }
}
