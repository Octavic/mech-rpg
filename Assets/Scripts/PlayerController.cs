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
        protected override void FixedUpdate()
        {
            var xMovement = Input.GetAxis(ControlNames.GetAxisName(Axises.Horizontal, this.PlayerIndex));
            var isJumping = Input.GetButton(ControlNames.GetButtonName(Buttons.Jump, this.PlayerIndex));

            this.Mech.Move(xMovement, isJumping);

            base.FixedUpdate();
        }
    }
}
