//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EquipmentRarity.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines a globally random number generator
    /// </summary>
    public static class GlobalRandom
    {
        private static Random r = new Random();

        public static int Next()
        {
            return r.Next();
        }

        public static int Next(int max)
        {
            return r.Next(max);
        }

        public static int Next(int min, int max)
        {
            return r.Next(min, max);
        }

        public static float NextFloat()
        {
            return (float)(r.NextDouble());
        }
    }
}
