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
    using Animations;
    using Equipments;

    /// <summary>
    /// A collection of mech body parts
    /// </summary>
    [Serializable]
    public class MechBodyParts
    {
        public Animatable Cab;
        public Animatable Legs;
        public MechArm LeftArm;
        public MechArm RightArm;
    }

    /// <summary>
    /// The base mech object
    /// </summary>
    public abstract class BaseMech : MonoBehaviour
    {
        public BaseEquipment TEMP_Weapon;

        /// <summary>
        /// Id of the mech
        /// </summary>
        public int MechId;

        /// <summary>
        /// Name of the mech
        /// </summary>
        public string MechaName;

        /// <summary>
        /// Mech body parts
        /// </summary>
        public MechBodyParts Body;

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
        public bool IsFacingRight
        {
            get
            {
                return this._isFacingRight;
            }
            set
            {
                if (value != this._isFacingRight)
                {
                    this.transform.localScale = new Vector3(value ? 1 : -1, 1, 1);
                    var equipped = this.Body.LeftArm.Equipped;
                    this.Body.LeftArm.Equipped = this.Body.RightArm.Equipped;
                    this.Body.RightArm.Equipped = equipped;

                    this._isFacingRight = value;

                }
            }
        }
        private bool _isFacingRight;

        /// <summary>
        /// Keeps track of jump status
        /// </summary>
        protected float BoostSecondsLeft;

        /// <summary>
        /// The velocity
        /// </summary>
        private Vector2 Velocity { get; set; }

        /// <summary>
        /// Moves the mech sideways
        /// </summary>
        public void Move(float xMovement, bool isJumping)
        {
            // Apply movement vector and flip mech if moving other direction
            if (xMovement != 0)
            {
                this.IsFacingRight = xMovement > 0;
                this.Velocity = new Vector2(xMovement * this.EffectiveStats.GetMobilityValue(Lerpable.TopSpeed), this.Velocity.y);
            }
            else
            {
                this.Velocity = Vector2.Lerp(this.Velocity, new Vector2(0, this.Velocity.y), Config.SpeedDecayFactor);
            }

            // Apply animations
            if (this.IsAirborne)
            {
                this.Body.Cab.PlayClip("still");

                if (isJumping)
                {
                    this.Body.Legs.PlayClip("jump");
                }
                else
                {
                    this.Body.Legs.PlayClip("fall");
                }
            }
            else
            {
                var targetClip = xMovement != 0 ? "walk" : "still";
                this.Body.Cab.PlayClip(targetClip);
                this.Body.Legs.PlayClip(targetClip);
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
            this.MechRigidbody = this.GetComponent<Rigidbody2D>();
            this.EffectiveStats = this.BaseStats;
            this.IsFacingRight = true;
            this.Body.RightArm.Equipped = this.TEMP_Weapon;

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
