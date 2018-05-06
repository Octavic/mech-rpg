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
        /// Called once per frame
        /// </summary>
        protected override void Update()
        {
            var xMovement = Input.GetAxis(ControlNames.GetAxisName(Axises.Horizontal, this.PlayerIndex));
            Mech.transform.position += new Vector3(xMovement * Mech.BaseStats.Mobility, 0, 0);
            base.Update();
        }
    }
}
