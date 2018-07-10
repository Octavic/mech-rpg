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
    public abstract class RapidFireWeapon: BaseWeapon, IMonoFireMode
    {
        public override bool IsDualFireMode
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// State of the weapon
        /// </summary>
        private bool _isFiring;
        private float _cooldown;

        public  void OnPressStart()
        {
            this._isFiring = true;
        }

        public void OnPressRelease()
        {
            this._isFiring = false;
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
