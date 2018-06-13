//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LerpFloat.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public static class Utils
    {
        /// <summary>
        /// Gets the lerped value
        /// </summary>
        /// <param name="start">The mininmal value</param>
        /// <param name="end">The maximum value</param>
        /// <param name="diff">A value between 0-1 defining where to stop</param>
        /// <returns>The lerped value</returns>
        public static float Lerp(float start, float end, float diff)
        {
            return (end - start) * diff + start;
        }

        public static float Atan2(Vector2 v)
        {
            return (float)Math.Atan2(v.y, v.x);
        }
    }
}
