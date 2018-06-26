//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AnimatableGroup.cs">
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

    [Serializable]
    public class AnimatableGropuChildClip
    {
        public IPlayable Playable;
        public string ChildClipName;
    }

    [Serializable]
    public class AnimatableGroupMasterClip
    {
        public string MasterClipName;
        public List<AnimatableGropuChildClip> Children;
    }

    /// <summary>
    /// Defines a group of animatable items
    /// </summary>
    public class AnimatableGroup : MonoBehaviour, IPlayable
    {
        public List<AnimatableGroupMasterClip> Clips;

        private Dictionary<string, AnimatableGroupMasterClip> _clipDict = new Dictionary<string, AnimatableGroupMasterClip>();
        
        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            foreach (var clip in this.Clips)
            {
                this._clipDict[clip.MasterClipName] = clip;
            }

        }

        public void PlayClip(string clipName, float delayModifier = 1.0f, bool shouldRestart = false)
        {
            AnimatableGroupMasterClip result;
            if (this._clipDict.TryGetValue(clipName, out result))
            {
                foreach (var childClip in result.Children)
                {
                    childClip.Playable.PlayClip(childClip.ChildClipName, delayModifier, shouldRestart);
                }
            }
        }
    }
}
