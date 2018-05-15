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
    using Utils;

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
        /// A collection of equipment slots
        /// </summary>
        public MechEquipmentSlots EquipmentSlots;

        /// <summary>
        /// The final  states of a mech
        /// </summary>
        [HideInInspector]
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
        /// If the  mech is in air right now
        /// </summary>
        public bool IsAirborne { get; set; }

        /// <summary>
        /// If the unit is facing left or right
        /// </summary>
        public bool IsFacingRight { get; private set; }

        /// <summary>
        /// Keeps track of jump status
        /// </summary>
        protected bool CanGroundJump { get; private set; }
        protected int AirJumpsLeft { get; private set; }

        /// <summary>
        /// The velocity
        /// </summary>
        private Vector2 Velocity { get; set; }

        /// <summary>
        /// Moves the mech sideways
        /// </summary>
        public void Move(float xMovement, bool isJumping)
        {
            //  Flip the sprite based on x movement
            if (xMovement < 0)
            {
                this.IsFacingRight = false;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (xMovement > 0)
            {
                this.IsFacingRight = true;
                this.transform.localScale = new Vector3(1, 1, 1);
            }

            if (xMovement != 0)
            {
                this.Velocity += new Vector2(xMovement * this.EffectiveStats.GetMobilityValue(Lerpable.MovementAcceleration), 0);
            }
            else
            {
                this.Velocity = new Vector2(Utils.Lerp(this.Velocity.x, 0, Config.SpeedDecayFactor), this.Velocity.y);
            }

            if (isJumping)
            {
                this.Velocity += new Vector2(0, this.EffectiveStats.GetMobilityValue(Lerpable.InitialJumpSpeed));
            }
            else if (this.IsAirborne)
            {
                this.Velocity = new Vector2(this.Velocity.x, Utils.Lerp(this.Velocity.y, -this.EffectiveStats.GetMobilityValue(Lerpable.FallSpeed), Config.GravityFactor));
            }
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected virtual void Start()
        {
            this.Renderer = this.GetComponent<SpriteRenderer>();
            this.MechRigidbody = this.GetComponent<Rigidbody2D>();

            var sprites = Resources.LoadAll<Sprite>(this.MechaName);
            this.Renderer.sprite = sprites[0];

            this.EffectiveStats = this.BaseStats;

            this.IsAirborne = true;
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void FixedUpdate()
        {
            var oldVelocity = this.Velocity;
            var maxSpeed = this.EffectiveStats.GetMobilityValue(Lerpable.TopSpeed);

            //  Limit max horizontal speed before applying  
            if (Math.Abs(oldVelocity.x) > maxSpeed)
            {
                this.Velocity = new Vector2(Math.Sign(oldVelocity.x) * maxSpeed, oldVelocity.y);
            }

            this.MechRigidbody.MovePosition(this.transform.position + (Vector3)this.Velocity);
        }
    }
}
