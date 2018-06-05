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
        /// How much hit stun is left
        /// </summary>
        protected float _hitStunLeft;

        public virtual void ApplyKnockback(Vector2 direction, float knockBackForce, float hitStun)
        {
            this._hitStunLeft = hitStun;
        }

        /// <summary>
        /// Called when the entity is hit
        /// </summary>
        /// <param name="hit">The hit box</param>
        public override void OnHit(WeaponHitbox hit)
        {
            this.ApplyKnockback(hit.KnockBack, hit.Impact, hit.HitStunSeconds);
            base.OnHit(hit);
        }
    }
}
