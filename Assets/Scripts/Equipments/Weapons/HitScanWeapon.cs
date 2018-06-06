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
    /// Defines a hitscan weapon
    /// </summary>
    public class HitScanWeapon : BaseWeapon
    {
        /// <summary>
        /// The pellet count. When it's not a whole number, a random die is rolled to see if an extra bullet is shot
        /// </summary>
        public float PelletCount;

        private bool _isFiring;
        private float _cooldown;

        /// <summary>
        /// Stats about the weapon
        /// </summary>
        public GameObject MuzzleLocation;
        public WeaponHitStat BaseHit;

        public override void OnPressStart()
        {
            this._isFiring = true;
            base.OnPressStart();
        }

        public override void OnShortRelease()
        {
            this._isFiring = false;
            base.OnShortRelease();
        }

        public override void OnLongRelease()
        {
            base.OnLongRelease();
            this._isFiring = false;
            base.OnLongRelease();
        }

        /// <summary>
        /// Fires the weapon
        /// </summary>
        protected void Fire()
        {
            this.EquippedOnArm.PlayClip("fire");
            this.Animatable.PlayClip("fire");
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

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            if (this._cooldown >= 0)
            {
                this._cooldown -= Time.deltaTime;
            }

            if (this._isFiring)
            {
                if (this._cooldown <= 0)
                {
                    this.Fire();
                    this._cooldown = Config.GetAttackDelay(this.BaseStats.AttackSpeed);
                }
            }
            base.Update();
        }
    }
}
