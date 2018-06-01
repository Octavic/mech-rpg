//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ScaleBar.cs">
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
    /// Defines a scalable bar (HP bar, energy bar, etc)
    /// </summary>
    public class ScaleBar : MonoBehaviour
    {
        /// <summary>
        /// The actual bar object
        /// </summary>
        public GameObject BarObject;

        /// <summary>
        /// Sets the bar's length
        /// </summary>
        /// <param name="val">a value between 0-1 </param>
        public void SetLength(float val)
        {
            BarObject.transform.localPosition = new Vector2(val / 2 - 0.5f, 0);
            BarObject.transform.localScale = new Vector3(val, 1, 1);
        }
    }
}
