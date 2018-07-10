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
    using Animations;
    using Equipments;
    using Map;

    /// <summary>
    /// A collection of mech body parts
    /// </summary>
    [Serializable]
    public class MechBodyParts
    {
        public Animatable Cab;
        public Animatable Legs;
        public MechArm BottomArm;
        public MechArm TopArm;
    }

    /// <summary>
    /// The base mech object
    /// </summary>
    public abstract class BaseMech : KnockBackableMapEntity
    {
        public BaseEquipment TEMP_Weapon;
        public BaseEquipment TEMP_Weapon2;

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
        public MechStats EffectiveStats { get; private set; }
        public MechDerivedStats DerivedStats { get; private set; }

        /// <summary>
        /// The mech's rigidbody
        /// </summary>
        public Rigidbody2D MechRigidbody;

        /// <summary>
        /// If the  mech is in air right now
        /// </summary>
        public bool IsAirborne { get; set; }

        public MechArm RightArm
        {
            get
            {
                return this._isFacingRight ? this.Body.TopArm : this.Body.BottomArm;
            }
        }

        public MechArm LeftArm
        {
            get
            {
                return this._isFacingRight ? this.Body.BottomArm : this.Body.TopArm;
            }
        }

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
                    var leftEquipped = this.LeftArm.Unequip();
                    var rightEquipped = this.RightArm.Unequip();

                    this._isFacingRight = value;

                    this.RightArm.Equipped = rightEquipped;
                    this.LeftArm.Equipped = leftEquipped;
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
        /// The dash cooldown
        /// </summary>
        private float _dashCooldown;

        /// <summary>
        /// Moves the mech sideways
        /// </summary>
        public void Move(float xMovement, bool isJumping)
        {
            if (this.IsInHitStun)
            {
                return;
            }

            // Apply movement vector and flip mech if moving other direction
            if (xMovement != 0)
            {
                this.IsFacingRight = xMovement > 0;
                this.Velocity = new Vector2(xMovement * this.DerivedStats.TopSpeed, this.Velocity.y);
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
                // Execute dash
                if (this._dashCooldown <= 0 && !this.IsAirborne && Math.Abs(xMovement) > 0.8f)
                {
                    this.Body.Legs.PlayClip("dash");
                    this.Body.Cab.PlayClip("dash");
                    var dashSpeed = this.DerivedStats.DashSpeed;
                    Debug.Log(dashSpeed);
                    if (!this.IsFacingRight)
                    {
                        dashSpeed *= -1;
                    }
                    this.Velocity += new Vector2(dashSpeed, 0);
                    this._dashCooldown = 1.0f;
                }
                else
                {
                    MainCamera.CurrentInstance.Shake(0.02f);
                    this.Velocity += new Vector2(0, this.DerivedStats.InitialJumpSpeed);
                }
            }
            else if (this.IsAirborne)
            {
                this.Velocity = new Vector2(this.Velocity.x, Utils.Lerp(this.Velocity.y, -this.DerivedStats.FallSpeed, Config.GravityFactor));
            }
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            this.MechRigidbody = this.GetComponent<Rigidbody2D>();
            this.EffectiveStats = this.BaseStats;
            this.DerivedStats = new MechDerivedStats(this.EffectiveStats);
            this.IsFacingRight = true;

            var weapon1 = Instantiate(this.TEMP_Weapon);
            weapon1.Mech = this;
            var weapon2 = Instantiate(this.TEMP_Weapon2);
            weapon2.Mech = this;
            this.Body.TopArm.Equipped = weapon1;
            this.Body.BottomArm.Equipped = weapon2;

            this.IsAirborne = true;

            base.Start();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void FixedUpdate()
        {
            var oldVelocity = this.Velocity;
            var maxSpeed = this.DerivedStats.TopSpeed;

            // Limit max horizontal speed before applying  
            if (Math.Abs(oldVelocity.x) > maxSpeed)
            {
                this.Velocity = new Vector2(Utils.Lerp(oldVelocity.x, maxSpeed, 0.6f), oldVelocity.y);
            }

            this.MechRigidbody.MovePosition(this.transform.position + (Vector3)this.Velocity);
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            if (this._dashCooldown > 0)
            {
                this._dashCooldown -= Time.deltaTime;
            }

            //if (Input.GetKeyDown(KeyCode.J) && this.RightArm.Equipped != null)
            //{
            //    this.RightArm.Equipped.OnPressStart();
            //}
            //else if (Input.GetKeyUp(KeyCode.J) && this.RightArm.Equipped != null)
            //{
            //    this.RightArm.Equipped.OnPressRelease();
            //}

            //if (Input.GetKeyDown(KeyCode.K) && this.LeftArm.Equipped != null)
            //{
            //    this.LeftArm.Equipped.OnPressStart();
            //}
            //else if (Input.GetKeyUp(KeyCode.K) && this.LeftArm.Equipped != null)
            //{
            //    this.LeftArm.Equipped.OnPressRelease();
            //}

            base.Update();
        }
    }
}
