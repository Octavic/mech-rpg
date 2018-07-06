//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IPlayable.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Animations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines something that can play an animation
    /// </summary>
    public interface IPlayable
    {
        /// <summary>
        /// Plays a clip
        /// </summary>
        /// <param name="clipName">name of the clip</param>
        /// <param name="delayModifier"></param>
        /// <param name="overrideRestart"></param>
        void PlayClip(string clipName, float delayModifier = 1.0f, bool shouldRestart = false);
    }
}
