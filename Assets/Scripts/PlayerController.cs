//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PlayerController.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mech;
    using UnityEngine;
    using Controls;
    using Equipments;

    /// <summary>
    /// The player  controller
    /// </summary>
    public class PlayerController : BaseController
    {
        /// <summary>
        /// The player's index
        /// </summary>
        public int PlayerIndex;

        /// <summary>
        /// How long the given key has been pressed
        /// </summary>
        private Dictionary<Buttons, float> _buttonHeldTime = new Dictionary<Buttons, float>();

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected override void Start()
        {
            GameController.CurrentInstance.RegisterPlayer(this);
            base.Start();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            // Movement
            var xMovement = Input.GetAxis(ControlNames.GetAxisName(Axises.Horizontal, this.PlayerIndex));
            var isJumping = Input.GetButton(ControlNames.GetButtonName(Buttons.Jump, this.PlayerIndex));
            this.Mech.Move(xMovement, isJumping);

            // Weapons
            this.UpdateWeaponButton(Buttons.LeftWeapon, this.Mech.LeftArm.Equipped);
            this.UpdateWeaponButton(Buttons.RightWeapon, this.Mech.RightArm.Equipped);

            base.Update();
        }

        private void UpdateWeaponButton(Buttons button, BaseEquipment equipment)
        {
            if (equipment == null)
            {
                return;
            }

            // Gather data
            var isPressedNow = Input.GetButton(ControlNames.GetButtonName(button, this.PlayerIndex));
            float heldTime = 0;
            var wasPressedBefore = this._buttonHeldTime.TryGetValue(button, out heldTime);

            var isNewPress = !wasPressedBefore && isPressedNow;
            var isReleased = wasPressedBefore && !isPressedNow;

            // The weapon is a dual mode weapon (If both are present,  dualMode takes  priority over monoMode)
            // Only one mode will have its hooks called
            if (equipment.IsDualFireMode)
            {
                var dualMode = equipment as IDualFireMode;

                if (isPressedNow)
                {
                    // Button is pressed. Check held time to see if threshold reached
                    if (heldTime < Controls.Config.LongPressDuration)
                    {
                        // Threshold not yet reached, add time and check again
                        heldTime += Time.deltaTime;
                        if (heldTime >= Controls.Config.LongPressDuration)
                        {
                            dualMode.OnLongPressStart();
                        }

                        // Update held time
                        this._buttonHeldTime[button] = heldTime;
                        return;
                    }
                    // Held time is greater than threshold and already triggered, do nothing
                }
                else if (isReleased)
                {
                    // Button is released, check held time to call right On...Release() trigger
                    if (heldTime > Controls.Config.LongPressDuration)
                    {
                        dualMode.OnLongPressRelease();
                    }
                    else
                    {
                        dualMode.OnShortPressRelease();
                    }

                    this._buttonHeldTime.Remove(button);
                }
            }
            else 
            {
                // Mono fire mode
                var monoMode = equipment as IMonoFireMode;
                if (isNewPress)
                {
                    monoMode.OnPressStart();
                    this._buttonHeldTime[button] = Time.deltaTime;
                }
                else if (isReleased)
                {
                    monoMode.OnPressRelease();
                    this._buttonHeldTime.Remove(button);
                }
            }
        }
    }
}
