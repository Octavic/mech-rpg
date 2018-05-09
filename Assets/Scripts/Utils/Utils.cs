//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LerpFloat.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Utils
    {
        /// <summary>
        /// Gets the lerped value
        /// </summary>
        /// <param name="min">The mininmal value</param>
        /// <param name="max">The maximum value</param>
        /// <param name="diff">A value between 0-1 defining where to stop</param>
        /// <returns>The lerped value</returns>
        public static float Lerp(float min, float max, float diff)
        {
            return (max - min) * diff + min;
        }
    }
}
