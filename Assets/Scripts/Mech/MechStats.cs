//  --------------------------------------------------------------------------------------------------------------------
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
    public  struct MechStats
    {
        /// <summary>
        ///  All of the following values are capped from 0 - 100
        /// </summary>
        public float Mobility;
        public float HP;
        public float Armor;
        public float EnergyCap;
        public float WeightCap;

        public float GetMovementSpeed()
        {
            return Utils.Lerp(Config.MinMovementSpeed, Config.MaxMovementSpeed, this.Mobility / 100);
        }

        public float GetJumpSpeed()
        {
            return Utils.Lerp(Config.MinJumpSpeed, Config.MaxJumpSpeed, this.Mobility / 100);
        }
    }
}
