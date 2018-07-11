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
        public bool CanMoveHorizontal;
        public bool CanMoveVertical;

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
            var distances =
                GameObject
                    .FindObjectsOfType<PlayerController>()
                    .Select(controller => controller.Mech.transform.position - this.transform.position)
                    .OrderBy(distance => distance.magnitude);

            if (distances.Count() > 0)
            {
                var closest = distances.First();
                float moveX = this.CanMoveHorizontal ? closest.x : 0; ;
                float moveY = this.CanMoveVertical ? closest.y : 0;

                var movement = new Vector3(moveX, moveY).normalized * this.MovementSpeed * Time.deltaTime;
                if (movement.magnitude > closest.magnitude)
                {
                    this.transform.position += closest;
                }
                else
                {
                    this.transform.position += movement;
                }
            }

            base.FixedUpdate();
        }
    }
}
