//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PlayerController.cs">
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
    /// An assault rifle that has a noob tube attachment
    /// </summary>
    public class NBTB : HitScanWeapon, IDualFireMode
    {
        public override bool IsDualFireMode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Prefab for the  grenade game object
        /// </summary>
        public WeaponProjectile GrenadePrefab;

        /// <summary>
        /// Muzzle for the grenade
        /// </summary>
        public GameObject GrenadeMuzzle;

        /// <summary>
        /// Cooldown until the grenade can be used again
        /// </summary>
        private float _grenadeCooldown;

        /// <summary>
        /// The usual cooldown for the grenade
        /// </summary>
        private const float GrenadeCooldown = 3.0f;

        public void OnShortPressRelease()
        {
            var newGrenade = Instantiate(this.GrenadePrefab);
            if (!this.Mech.IsFacingRight)
            {
                newGrenade.Velocity = Utils.FlipX(newGrenade.Velocity);
            }

            newGrenade.transform.position = this.GrenadeMuzzle.transform.position;
        }

        public void OnLongPressStart()
        {
            base.OnPressStart();
        }

        public void OnLongPressRelease()
        {
            base.OnPressRelease();
        }
    }
}
