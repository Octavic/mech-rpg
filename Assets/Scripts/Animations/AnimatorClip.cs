﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AnimatorClip.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Animations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a clip of an animation
    /// </summary>
    [Serializable]
    public class AnimatorClip
    {
        /// <summary>
        /// A unique name used to identify the clip
        /// </summary>
        public string Name;

        /// <summary>
        /// In order to define a series of sprites to use, either list them here
        /// </summary>
        public List<int> SpriteIndexes;

        /// <summary>
        /// Or use a starting index + a length
        /// </summary>
        public int StartingIndex;
        public int ClipCount;

        /// <summary>
        /// How much time to wait in between switching to the next frame
        /// </summary>
        public float Delay;

        /// <summary>
        /// If the animation should loop
        /// </summary>
        public bool ShouldLoop;

        /// <summary>
        /// Initializes the clip
        /// </summary>
        public void Initialize()
        {
            var isContinuous = this.ClipCount != 0;
            var isCustom = this.SpriteIndexes.Count != 0;

            if (!isContinuous && !isCustom)
            {
                Debug.LogError("Clip is empty: " + this.Name);
                return;
            }

            if (isContinuous)
            {
                for (int i = 0; i < this.ClipCount; i++)
                {
                    this.SpriteIndexes.Add(this.StartingIndex + i);
                }
            }
            else
            {
                this.StartingIndex = this.SpriteIndexes[0];
                this.ClipCount = this.SpriteIndexes.Count();
            }
        }
    }
}
