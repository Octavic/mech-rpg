//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ControlNames.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A collection of methods to get control axis/button  names
    /// </summary>
    public static class ControlNames
    {
        /// <summary>
        /// Gets the name of the axis
        /// </summary>
        /// <param name="axis">Target axis</param>
        /// <param name="playerIndex">Index of the player</param>
        /// <returns>The name of the axis</returns>
        public static string GetAxisName(Axises axis, int playerIndex)
        {
            return axis.ToString() + playerIndex;
        }
    }
}
