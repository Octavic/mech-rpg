//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEquipment.cs">
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
    /// Defines a weapon's hitbox
    /// </summary>
    public class WeaponHitbox : MonoBehaviour
    {
        /// <summary>
        /// The damage stats
        /// </summary>
        public float Damage;
        public float HitStunSeconds;
        public float Impact;
        public Vector2 KnockBack;
    }
}
