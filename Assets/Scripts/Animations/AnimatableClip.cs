//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AnimatableClip.cs">
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
    /// Defines a series of sprites to be used as animation
    /// </summary>
    [Serializable]
    public class AnimatableClip
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
        /// The starting index of the clip
        /// </summary>
        public int StartingIndex;

        /// <summary>
        /// How many sprites rae in the clip
        /// </summary>
        public int ClipCount;

        /// <summary>
        /// How much time to wait in between switching to the next frame
        /// </summary>
        public float Delay;

        /// <summary>
        /// If the animation should transition to another state automatically when it's finished
        /// </summary>
        public string TransitTo;

        /// <summary>
        /// If the clip is uninterrputable
        /// </summary>
        public bool IsUninterrputable;

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
