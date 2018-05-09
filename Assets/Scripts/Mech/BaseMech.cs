//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseMech.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// The base mech object
    /// </summary>
    public abstract class BaseMech : MonoBehaviour
    {
        /// <summary>
        /// Id of the mech
        /// </summary>
        public int MechId;

        /// <summary>
        /// Name of the mech
        /// </summary>
        public string MechaName;

        /// <summary>
        /// The base stats of a mech
        /// </summary>
        public MechStats BaseStats;

        /// <summary>
        /// The final  states of a mech
        /// </summary>
        public MechStats EffectiveStats;

        /// <summary>
        /// The sprite renderer
        /// </summary>
        public SpriteRenderer Renderer;

        /// <summary>
        /// The mech's rigidbody
        /// </summary>
        public Rigidbody2D MechRigidbody;

        /// <summary>
        /// Moves the mech sideways
        /// </summary>
        public void Move(float xMovement, bool isJumping)
        {
            var resultMove = new Vector3(xMovement * Time.deltaTime * this.EffectiveStats.GetMovementSpeed(), 0, 0);

            if (xMovement < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (xMovement > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }

            if (isJumping)
            {
                resultMove += new Vector3(0, Time.deltaTime * this.EffectiveStats.GetJumpSpeed());
            }

            this.MechRigidbody.MovePosition(this.transform.position + resultMove);
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this.Renderer = this.GetComponent<SpriteRenderer>();
            this.MechRigidbody = this.GetComponent<Rigidbody2D>();

            var sprites = Resources.LoadAll<Sprite>(this.MechaName);
            this.Renderer.sprite = sprites[0];

            this.EffectiveStats = this.BaseStats;
        }
    }
}
