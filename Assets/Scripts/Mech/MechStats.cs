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
    
    /// <summary>
    /// Status for a mech
    /// </summary>
    [Serializable]
    public  struct MechStats
    {
        public float Mobility;
        public float HP;
        public float Armor;
        public float EnergyCap;
        public float WeightCap;
    }
}
