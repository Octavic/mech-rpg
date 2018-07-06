//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MechDerivedStats.cs">
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
    /// A collection of stats derived from the mech's base stats
    /// </summary>
    public class MechDerivedStats
    {
        public float TopSpeed { get; private set; }
        public float InitialJumpSpeed { get; private set; }
        public float FallSpeed { get; private set; }
        public float DashSpeed { get; private set; }

        public MechDerivedStats(MechStats baseStats)
        {
            this.Recalculate(baseStats);
        }

        public void Recalculate(MechStats baseStats)
        {
            this.TopSpeed = Config.Lerpables[Lerpable.TopSpeed].Apply(baseStats.Mobility / 100);
            this.InitialJumpSpeed = Config.Lerpables[Lerpable.InitialJumpSpeed].Apply(baseStats.Mobility / 100);
            this.FallSpeed = Config.Lerpables[Lerpable.FallSpeed].Apply(baseStats.Mobility / 100);
            this.DashSpeed = Config.Lerpables[Lerpable.DashSpeed].Apply(baseStats.Mobility / 100);
        }
    }
}
