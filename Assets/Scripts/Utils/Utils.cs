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

        /// <summary>
        /// Extends the default atan2 function with a vector
        /// </summary>
        /// <param name="v">Target vector</param>
        /// <returns>the angle, in rad, of the vector</returns>
        public static float Atan2(Vector2 v)
        {
            return (float)Math.Atan2(v.y, v.x);
        }

        public static Vector2 FlipX(Vector2 v)
        {
            return new Vector2(-v.x, v.y);
        }

        /// <summary>
        /// Returns a new vector2 that's rotated x degrees
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="degrees">The degrees</param>
        /// <returns>A new rotated vector2</returns>
        public static Vector2 RotateDeg(this Vector2 v, float degrees)
        {
            return v.RotateRad(degrees * Mathf.Deg2Rad);   
        }

        public static Vector2 RotateRad(this Vector2 v, float rad)
        {
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);
            float x = v.x;
            float y = v.y;

            return new Vector2(cos * x - sin * y, sin * x + cos * y);
        }

        public static float AngleDiffDeg(float deg1, float deg2)
        {
            var diff = (deg2 - deg1) % 360;
            if (diff > 180)
            {
                diff -= 360;
            }

            return diff;
        }

        public static float AngleDiffDeg(Vector2 v1, Vector2 v2)
        {
            var deg1 = Mathf.Atan2(v1.y, v1.x) * Mathf.Rad2Deg;
            var deg2 = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
            return AngleDiffDeg(deg1, deg2);
        }
    }
}
