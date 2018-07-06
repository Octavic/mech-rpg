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
    /// Defines a clip frame
    /// </summary>
    [Serializable]
    public class ClipFrame
    {
        public int Index;
        public float Delay;
    }

    /// <summary>
    /// Automatically adds some frames
    /// </summary>
    [Serializable]
    public class AutoFillFrames
    {
        public int StartIndex;
        public int Length;
        public float Delay;
    }

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
        public List<ClipFrame> Frames;

        /// <summary>
        /// A list of frames to be automatically added
        /// </summary>
        public List<AutoFillFrames> AutoGenFrames;

        /// <summary>
        /// The starting index of the clip
        /// </summary>
        public int StartingIndex
        {
            get
            {
                return this.Frames.First().Index;
            }
        }

        /// <summary>
        /// How many sprites rae in the clip
        /// </summary>
        public int ClipCount
        {
        get
            {
                return this.Frames.Count;
            }
        }

        /// <summary>
        /// If the animation should transition to another state automatically when it's finished
        /// </summary>
        public string TransitTo;

        /// <summary>
        /// If the clip is uninterrputable
        /// </summary>
        public bool IsUninterrputable;

        /// <summary>
        /// Used for initialization
        /// </summary>
        public void Initialize()
        {
            foreach (var autoGenFrame in this.AutoGenFrames)
            {
                for (int i = 0; i < autoGenFrame.Length; i++)
                {
                    var newFrame = new ClipFrame();
                    newFrame.Index = autoGenFrame.StartIndex + i;
                    newFrame.Delay = autoGenFrame.Delay;
                    this.Frames.Add(newFrame);
                }
            }
        }
    }
}
