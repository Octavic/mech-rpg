//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="HittableMapEntity.cs">
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

    public class HittableMapEntity : MapEntity, IHittable
    {
        /// <summary>
        /// Faction of this entity
        /// </summary>
        public Factions EntityFaction;

        /// <summary>
        /// A list of effects that this entity is immune to
        /// </summary>
        public List<Effects> ImmuneTo;
        private HashSet<Effects> _immuneTo;

        public Factions Faction
        {
            get
            {
                return this.EntityFaction;
            }
        }

        protected Dictionary<Effects, AppliedEffect> _activeEffects;

        public bool IsAffectedBy(Effects effect)
        {
            return this._activeEffects.ContainsKey(effect);
        }
        public bool TryApplyEffect(AppliedEffect effect)
        {
            if (this._immuneTo.Contains(effect.Effect))
            {
                return false;
            }

            return true;
        }

        public AppliedEffect GetEffect(Effects effect)
        {
            AppliedEffect result;
            return this._activeEffects.TryGetValue(effect, out result) ? result : null;
        }

        /// <summary>
        /// Called when the map  entity is hit
        /// </summary>
        /// <param name="hit">The weapon hitbox</param>
        public virtual void OnHit(WeaponHitStat hit)
        {
        }

        /// <summary>
        /// Called when the trigger enters
        /// </summary>
        /// <param name="collider">The collision</param>
        protected virtual void OnTriggerEnter2D(Collider2D collider)
        {
            var hitbox = collider.GetComponent<WeaponHitbox>();
            if (hitbox != null)
            {
                this.OnHit(hitbox.HitStat);
            }

            var projectile = collider.GetComponent<WeaponProjectile>();
            if (projectile != null)
            {
                projectile.OnHit(this);
            }
        }

        /// <summary>
        /// Called once per fixed duration
        /// </summary>
        protected override void FixedUpdate()
        {
            var effects = this._activeEffects.Keys.ToList() ;
            foreach (var effect in effects)
            {
                var targetEffect = this._activeEffects[effect];
                targetEffect.Decay(Time.deltaTime);
                if (targetEffect.ShouldRemove())
                {
                    this._activeEffects.Remove(effect);
                }
            }
            

            base.FixedUpdate();
        }
    }
}
