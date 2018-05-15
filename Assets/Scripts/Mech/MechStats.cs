﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MechStats.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utils;

    /// <summary>
    /// Status for a mech
    /// </summary>
    [Serializable]
    public class MechStats
    {
        /// <summary>
        ///  All of the following values are capped from 0 - 100
        /// </summary>
        public float Mobility;
        public float HP;
        public float FirePower;
        public float WeightCap;

        /// <summary>
        /// The amount of jumps possible  in air (Excluding the base jump off of the ground
        /// </summary>
        public int TotalJumps;

        public float GetMobilityValue(Lerpable l)
        {
            return Config.Lerpables[l].Apply(this.Mobility / 100);
        }
    }
}
