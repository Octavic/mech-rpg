//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SegmentLine.cs">
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

    /// <summary>
    /// Defines a line segment that can be connected at two points
    /// </summary>
    public class SegmentLine : MonoBehaviour
    {
        /// <summary>
        /// Connects the line
        /// </summary>
        /// <param name="a">point A</param>
        /// <param name="b">point B</param>
        public void Connect(Vector2 a, Vector2 b)
        {
            var diff = b - a;
            this.transform.position = (a + b) / 2;
            this.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
            this.transform.localScale = new Vector3(diff.magnitude, 1, 1);
        }
    }
}
