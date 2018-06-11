//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KnockBackableMapEntity.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Equipments.Weapons;
    using UnityEngine;

    public class KnockBackableMapEntity : HittableMapEntity, IKnockBackable
    {
        public bool IsInHitStun
        {
            get
            {
                return this._hitStunLeft > 0;
            }
        }

        /// <summary>
        /// The current knockback force
        /// </summary>
        protected Vector2? KnockBack
        {
            get
            {
                return this._knockback;
            }
        }
        private Vector2? _knockback;

        /// <summary>
        /// How much hit stun is left
        /// </summary>
        protected float _hitStunLeft;

        /// <summary>
        /// Clears the knockback
        /// </summary>
        protected void ClearKnockback()
        {
            this._knockback = null;
        }

        public virtual void ApplyKnockback(Vector2 direction, float knockBackForce, float hitStun)
        {
            this._knockback = direction.normalized * knockBackForce;
            this._hitStunLeft = hitStun;
        }

        /// <summary>
        /// Called when the entity is hit
        /// </summary>
        /// <param name="hit">The hit box</param>
        public override void OnHit(WeaponHitStat hit)
        {
            this.ApplyKnockback(hit.KnockBack, hit.Impact, hit.HitStunSeconds);
            base.OnHit(hit);
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            if (this._knockback.HasValue)
            {
                this.transform.position += (Vector3)this.KnockBack.Value * Time.deltaTime;
                this._knockback *= 0.8f;
                if (this._knockback.Value.magnitude <= 0.001)
                {
                    this.ClearKnockback();
                }
            }

            if (this._hitStunLeft > 0)
            {
                this._hitStunLeft -= Time.deltaTime;
            }

            base.Update();
        }
    }
}
