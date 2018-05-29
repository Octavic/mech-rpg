//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEnemy.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Enemy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// The enemy base class
    /// </summary>
    public abstract class BaseEnemy : MonoBehaviour
    {
        /// <summary>
        /// The  base stats of an enemy
        /// </summary>
        public EnemyStats BaseStats;

        /// <summary>
        /// The effect stats of an enemy
        /// </summary>
        public EnemyStats EffectiveStats { get; private set; }

        public float CurrentHP
        {
            get
            {
                return this._currentHP;
            }
            set
            {
                this._currentHP = value;
            }
        }
        private float _currentHP;
    }
}
