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
    using Equipments.Weapons;

    /// <summary>
    /// The enemy base class
    /// </summary>
    public abstract class BaseEnemy : MonoBehaviour
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
        protected virtual void Start()
        {
            this.EffectiveStats = this.BaseStats;
            this.CurrentHP = this.EffectiveStats.HP;
        }

        /// <summary>
        /// Called when trigger collision happens
        /// </summary>
        /// <param name="collider">The collider</param>
        protected virtual void OnTriggerEnter2D(Collider2D collider)
        {
            var hitBox = collider.GetComponent<WeaponHitbox>();
            if (hitBox != null && !hitBox.IsConstant)
            {
                this.CurrentHP -= hitBox.Damage;
            }
        }

        /// <summary>
        /// Called when trigger stays collided
        /// </summary>
        /// <param name="collider">The collider</param>
        protected virtual void OnTriggerStay2D(Collider2D collider)
        {
            var hitBox = collider.GetComponent<WeaponHitbox>();
            if (hitBox != null && hitBox.IsConstant)
            {
                this.CurrentHP -= hitBox.Damage * Time.deltaTime;
            }
        }
    }
}
