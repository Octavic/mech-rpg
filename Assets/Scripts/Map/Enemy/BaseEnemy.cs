//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEnemy.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map.Enemy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Equipments.Weapons;

    /// <summary>
    /// The enemy base class
    /// </summary>
    public abstract class BaseEnemy : KnockBackableMapEntity
    {
        /// <summary>
        /// The hp bar component
        /// </summary>
        public ScaleBar HPBar;

        /// <summary>
        /// The  base stats of an enemy
        /// </summary>
        public EnemyStats BaseStats;

        /// <summary>
        /// The effect stats of an enemy
        /// </summary>
        public EnemyStats EffectiveStats { get; private set; }

        /// <summary>
        /// The current HP
        /// </summary>
        public float CurrentHP
        {
            get
            {
                return this._currentHP;
            }
            set
            {
                if (value <= 0)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    this.HPBar.SetLength(value / this.EffectiveStats.HP);
                }

                this._currentHP = value;
            }
        }
        private float _currentHP;

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            this.EffectiveStats = this.BaseStats;
            this.CurrentHP = this.EffectiveStats.HP;
            base.Start();
        }

        /// <summary>
        /// Called when the entity is hit
        /// </summary>
        /// <param name="hit">The weapon hit that went through</param>
        public override void OnHit(WeaponHitStat hit)
        {
            this.CurrentHP -= hit.Damage;
            base.OnHit(hit);
        }
    }
}
