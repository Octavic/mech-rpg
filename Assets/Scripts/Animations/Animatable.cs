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
    public class Animatable : MonoBehaviour
    {
        /// <summary>
        /// Path to the sprite sheet
        /// </summary>
        public string SpriteSheetPath;

        /// <summary>
        /// All of the possible animations
        /// </summary>
        public List<AnimatableClip> Animations;

        /// <summary>
        /// A hash of name=>animation
        /// </summary>
        private Dictionary<string, AnimatableClip> AnimationHash;

        /// <summary>
        /// The actual sprite sheet's sub sprites
        /// </summary>
        private List<Sprite> Sprites;

        /// <summary>
        /// The sprite renderer component
        /// </summary>
        private new SpriteRenderer renderer;

        /// <summary>
        /// The clip currently going on
        /// </summary>
        private AnimatableClip currentClip;
        private int currentIndex;
        private float timeTillNextFrame;

        /// <summary>
        /// Switches to the target clip
        /// </summary>
        /// <param name="clipName">The target clip</param>
        public void PlayClip(string clipName)
        {
            AnimatableClip clip;
            if (!this.AnimationHash.TryGetValue(clipName, out clip))
            {
                Debug.LogError("Clip does not exist: " + clipName);
            }

            this.PlayClip(clip);
        }

        /// <summary>
        /// used for initialization
        /// </summary>
        protected virtual void Start()
        {
            this.Sprites = Resources.LoadAll<Sprite>(this.SpriteSheetPath).ToList();
            this.renderer = this.GetComponent<SpriteRenderer>();

            this.AnimationHash = new Dictionary<string, AnimatableClip>();

            foreach (var animation in this.Animations)
            {
                animation.Initialize();
                var name = animation.Name;
                if (this.AnimationHash.ContainsKey(name))
                {
                    Debug.LogError("Duplicate animator clip name declaration: " + name);
                }
                else
                {
                    this.AnimationHash[name] = animation;
                }
            }

            this.renderer = this.GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void Update()
        {
            // Nothing to play
            if (this.currentClip == null)
            {
                return;
            }

            this.timeTillNextFrame -= Time.deltaTime;

            // Not time to switch yet
            if (this.timeTillNextFrame > 0)
            {
                return;
            }

            this.currentIndex++;

            if (this.currentIndex >= this.Sprites.Count)
            {
                Debug.LogError("Sprite index out of range: " + this.currentIndex);
                return;
            }

            this.renderer.sprite = this.Sprites[this.currentIndex];
            this.timeTillNextFrame = this.currentClip.Delay;

            // Reached the end of clip
            if (this.currentIndex >= this.currentClip.ClipCount)
            {
                if (this.currentClip.ShouldLoop)
                {
                    this.PlayClip(this.currentClip);
                }
                else
                {
                    this.currentClip = null;
                }
            }
        }

        /// <summary>
        /// Plays the target clip
        /// </summary>
        /// <param name="targetClip">Target clip to be played</param>
        private void PlayClip(AnimatableClip targetClip)
        {
            this.currentClip = targetClip;
            this.currentIndex = 0;
            this.timeTillNextFrame = targetClip.Delay;
            this.renderer.sprite = this.Sprites[0];
        }
    }
}
