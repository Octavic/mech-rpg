//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IKnockBackable.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines something that can be knocked back
    /// </summary>
    public interface IKnockBackable
    {
        /// <summary>
        /// Gets or sets a value that indicates if the entity is still in unresponsive hitstun
        /// </summary>
        bool IsInHitStun { get; set; }

        /// <summary>
        /// Applies the hit
        /// </summary>
        /// <param name="direction">The direction of the knock back</param>
        /// <param name="knockBackForce">Force  of the knock back</param>
        /// <param name="hitStun">Duration of hitstun</param>
        void ApplyHit(Vector2 direction, float knockBackForce, float hitStun);
    }
}
