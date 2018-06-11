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
    using UnityEngine;

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
            return Utils.Lerp(this.Min, this.Max, t);
        }
    }

    public enum Lerpable
    {
        TopSpeed,
        InitialJumpSpeed,
        FallSpeed
    }

    public static class Config
    {
        static Config()
        {
            Lerpables = new Dictionary<Lerpable, LerpableValue>();
            Lerpables[Lerpable.TopSpeed] = new LerpableValue(0.03f, 0.06f);
            Lerpables[Lerpable.InitialJumpSpeed] = new LerpableValue(0.003f, 0.008f);
            Lerpables[Lerpable.FallSpeed] = new LerpableValue(0.03f, 0.04f);
        }

        /// <summary>
        /// All of possible lerpables and their min/max values
        /// </summary>
        public static Dictionary<Lerpable, LerpableValue> Lerpables { get; private set; }

        public const float SpeedDecayFactor = 0.8f;
        public const float GravityFactor = 0.3f;

        public static Vector2 WeaponHandOffset = new Vector2(0.02f, -0.13f);
    }
}
