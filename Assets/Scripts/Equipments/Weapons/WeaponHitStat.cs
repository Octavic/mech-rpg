﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WeaponHitStat.cs">
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
    /// Defines the stats of a weapon hit
    /// </summary>
    [Serializable]
    public class WeaponHitStat
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public WeaponHitStat(WeaponHitStat hit)
        {
            this.Damage = hit.Damage;
            this.HitStunSeconds = hit.HitStunSeconds;
            this.Recoil = hit.Recoil;
            this.Impact = hit.Impact;
            this.KnockBack = hit.KnockBack;
        }

        /// <summary>
        /// The damage stats
        /// </summary>
        public float Damage;
        public float HitStunSeconds;
        public float Recoil;
        public float Impact;
        public Vector2 KnockBack;
    }
}
