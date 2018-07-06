//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RapidFireWeapon.cs">
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
    /// A weapon that when tapped, fires once. And when held, rapidly fires
    /// </summary>
    public abstract class RapidFireWeapon: BaseWeapon
    {
        /// <summary>
        /// State of the weapon
        /// </summary>
        private bool _isFiring;
        private float _cooldown;

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
            this._isFiring = false;
            base.OnLongRelease();
        }

        /// <summary>
        /// Fires the weapon
        /// </summary>
        public abstract void Fire();

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
