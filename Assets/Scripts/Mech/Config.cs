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

    public class LerpableValue
    {
        public float Min;
        public float Max;
        public LerpableValue(float min, float max)
        {
            this.Min = min;
            this.Max = max;
        }

        public float Apply(float t)
        {
            return Utils.Utils.Lerp(this.Min, this.Max, t);
        }
    }

    public enum Lerpable
    {
        MovementAcceleration,
        TopSpeed,
        MovementDecay,
        InitialJumpSpeed,
        FallSpeed
    }

    public static class Config
    {
        static Config()
        {
            Lerpables = new Dictionary<Lerpable, LerpableValue>();
            Lerpables[Lerpable.MovementAcceleration] = new LerpableValue(0.1f, 0.5f);
            Lerpables[Lerpable.TopSpeed] = new LerpableValue(0.03f, 0.06f);
            Lerpables[Lerpable.MovementDecay] = new LerpableValue(2.0f, 3.0f);
            Lerpables[Lerpable.InitialJumpSpeed] = new LerpableValue(0.02f, 0.03f);
            Lerpables[Lerpable.FallSpeed] = new LerpableValue(0.04f, 0.05f);
        }

        /// <summary>
        /// All of possible lerpables and their min/max values
        /// </summary>
        public static Dictionary<Lerpable, LerpableValue> Lerpables { get; private set; }

        public const float SpeedDecayFactor = 0.8f;
        public const float GravityFactor = 0.3f;
    }
}
