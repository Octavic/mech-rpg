//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Animatable.cs">
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
    /// Defines an object that can be animated
    /// </summary>
    public class Animatable : MonoBehaviour, IPlayable
    {
        /// <summary>
        /// Path to the sprite sheet
        /// </summary>
        public string SpriteSheetPath;

        /// <summary>
        /// Path to the decal sprite sheet. The animation will  be duplicated
        /// </summary>
        public string DecalSheetPath;
        public SpriteRenderer DecalRenderer;

        /// <summary>
        /// All of the possible animations
        /// </summary>
        public List<AnimatableClip> Animations;

        /// <summary>
        /// Gets the name of the current clip
        /// </summary>
        public string CurrentPlaying
        {
            get
            {
                return this._currentClip != null ? this._currentClip.Name : null;
            }
        }

        /// <summary>
        /// A hash of name=>animation
        /// </summary>
        private Dictionary<string, AnimatableClip> AnimationHash;

        /// <summary>
        /// The actual sprite sheet's sub sprites
        /// </summary>
        private List<Sprite> _sprites;
        private List<Sprite> _decals;

        /// <summary>
        /// The sprite renderer component
        /// </summary>
        protected SpriteRenderer _renderer;

        /// <summary>
        /// The clip currently going on
        /// </summary>
        private AnimatableClip _currentClip;
        private int _currentIndex;
        private float _speedModifier;
        private float _timeTillNextFrame;

        /// <summary>
        /// Switches to the target clip
        /// </summary>
        /// <param name="clipName">The target clip</param>
        /// <param name="shouldRestart">If the clipname is the same, should the clip start</param>
        /// <param name="delayModifier">The speed modifier</param>
        public void PlayClip(string clipName, float delayModifier = 1.0f, bool shouldRestart = false)
        {
            // If the same clip is playing and flag is not set, do nothing
            if (this._currentClip != null)
            {
                if (this._currentClip.Name == clipName && !shouldRestart)
                {
                    return;
                }

                if (this._currentClip.IsUninterrputable)
                {
                    return;
                }
            }

            AnimatableClip clip;
            if (!this.AnimationHash.TryGetValue(clipName, out clip))
            {
                Debug.LogError("Clip does not exist: " + clipName);
                return;
            }

            this.PlayClip(clip, delayModifier);
        }

        /// <summary>
        /// used for initialization
        /// </summary>
        protected virtual void Start()
        {
            this._sprites = Resources.LoadAll<Sprite>(this.SpriteSheetPath).ToList();
            if (this.DecalRenderer != null)
            {
                this._decals = Resources.LoadAll<Sprite>(this.DecalSheetPath).ToList();
            }

            this._renderer = this.GetComponent<SpriteRenderer>();
            this.AnimationHash = new Dictionary<string, AnimatableClip>();

            foreach (var animation in this.Animations)
            {
                var name = animation.Name;
                if (this.AnimationHash.ContainsKey(name))
                {
                    Debug.LogError("Duplicate animator clip name declaration: " + name);
                }
                else
                {
                    animation.Initialize();
                    this.AnimationHash[name] = animation;
                }
            }

        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void Update()
        {
            // Nothing to play
            if (this._currentClip == null)
            {
                return;
            }

            this._timeTillNextFrame -= Time.deltaTime;

            // Not time to switch yet
            if (this._timeTillNextFrame > 0)
            {
                return;
            }

            this._currentIndex++;

            // Reached the end of clip
            if (this._currentIndex >= this._currentClip.ClipCount)
            {
                var nextClip = this._currentClip.TransitTo;
                if (!String.IsNullOrEmpty(nextClip))
                {
                    this._currentClip = null;
                    this.PlayClip(nextClip, this._speedModifier, true);
                }
                else
                {
                    this._currentClip = null;
                }

                return;
            }

            var targetFrame = this._currentClip.Frames[this._currentIndex];
            var targetFrameIndex = targetFrame.Index;
            if (targetFrameIndex >= this._sprites.Count)
            {
                Debug.LogError("Sprite index out of range: " + this._currentIndex);
                return;
            }

            this._renderer.sprite = this._sprites[targetFrameIndex];
            if (this.DecalRenderer != null)
            {
                this.DecalRenderer.sprite = this._decals[targetFrameIndex];
            }
            this._timeTillNextFrame = targetFrame.Delay * this._speedModifier;
        }

        /// <summary>
        /// Plays the target clip
        /// </summary>
        /// <param name="targetFrame">Target clip to be played</param>
        /// <param name="speedModifier">The speed modifier</param>
        private void PlayClip(AnimatableClip targetFrame, float speedModifier = 1.0f)
        {
            this._currentClip = targetFrame;
            this._currentIndex = 0;
            this._timeTillNextFrame = targetFrame.Frames.First().Delay * speedModifier;
            this._renderer.sprite = this._sprites[targetFrame.StartingIndex];
            this._speedModifier = speedModifier;
        }
    }
}
