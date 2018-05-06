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
        /// A collection  of button => button names mapping
        /// </summary>
        private static Dictionary<Buttons, string> buttonNames;

        /// <summary>
        /// Used for initialization
        /// </summary>
        static ControlNames()
        {
            buttonNames = new Dictionary<Buttons, string>();
            buttonNames[Buttons.L] = "L";
            buttonNames[Buttons.R] = "R";
            buttonNames[Buttons.Jump] = "A";
            buttonNames[Buttons.LeftWeapon] = "X";
            buttonNames[Buttons.RightWeapon] = "B";
            buttonNames[Buttons.MechAbility] = "Y";
            buttonNames[Buttons.Start] = "Start";
        }

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

        /// <summary>
        /// Gets the name of the button
        /// </summary>
        /// <param name="button">Target button</param>
        /// <param name="playerIndex">Index of the player</param>
        /// <returns></returns>
        public static string GetButtonName(Buttons button, int playerIndex)
        {
            return buttonNames[button] + playerIndex;
        }
    }
}
