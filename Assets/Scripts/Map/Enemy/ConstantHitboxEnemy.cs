//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ConstantHitboxEnemy.cs">
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

    /// <summary>
    /// Describes an enemy that has a constant hitbox that deals damage when the player touches them
    /// </summary>
    public class ConstantHitboxEnemy : BaseEnemy
    {
        /// <summary>
        /// How fast the enemy moves
        /// </summary>
        public float MovementSpeed;

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void FixedUpdate()
        {
            var closestPlayer = GameObject.FindObjectsOfType<PlayerController>().Min(controller => (controller.transform.position - this.transform.position).magnitude);
            base.Update();
        }
    }
}
