
namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Equipments.Weapons;
     
    /// <summary>
    /// Defines something that can be hit with a bullet, melee, etc
    /// </summary>
    public interface IHittable
    {
        Factions Faction { get; }

        /// <summary>
        /// Called when the entity is hit
        /// </summary>
        /// <param name="hit">The weapon hit</param>
        void OnHit(WeaponHitStat hit);
    }
}
