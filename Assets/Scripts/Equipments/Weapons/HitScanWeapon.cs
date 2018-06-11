﻿//  --------------------------------------------------------------------------------------------------------------------
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

        /// <summary>
        /// The screen shake each time the gun fire
        /// </summary>
        public float ScreenShake;

        /// <summary>
        /// The bulletline prefab
        /// </summary>
        public BulletLine BulletLinePrefab;

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
            this.EquippedOnArm.PlayClip("fire", 1.0f, true);
            this.Animatable.PlayClip("fire", 1.0f, true);

            int shootCount = (int)this.PelletCount;
            float diff = this.PelletCount - shootCount;
            if (GlobalRandom.NextFloat() < diff)
            {
                shootCount++;
            }

            MainCamera.CurrentInstance.Shake(this.ScreenShake);

            for (int shoot = 0; shoot < shootCount; shoot++)
            {
                var inaccuracy = (100 - this.BaseStats.Accuracy) / 200 * GlobalRandom.NextFloat() * Mathf.PI;
                if (GlobalRandom.NextBool())
                {
                    inaccuracy *= -1;
                }

                var shootX = Mathf.Cos(inaccuracy);
                var shootY = Mathf.Sin(inaccuracy);

                var hitX = this.BaseHit.KnockBack.x;
                if (!this.Mech.IsFacingRight)
                {
                    shootX *= -1;
                    hitX *= -1;
                }

                var adjustedHit = new WeaponHitStat(this.BaseHit);
                adjustedHit.KnockBack = new Vector2(hitX, this.BaseHit.KnockBack.y);

                var rayCast = Physics2D.RaycastAll(this.MuzzleLocation.transform.position, new Vector2(shootX, shootY));
                for (var i = 0; i < rayCast.Length; i++)
                {
                    var hittable = rayCast[i].collider.GetComponent<IHittable>();
                    if (hittable != null)
                    {
                        hittable.OnHit(adjustedHit);
                        var newBullet = Instantiate(this.BulletLinePrefab);
                        newBullet.OnBulletHit(this.MuzzleLocation.transform.position, rayCast[i]);
                        break;
                    }
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
