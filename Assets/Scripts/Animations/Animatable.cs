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
        public List<AnimatorClip> Animations;

        /// <summary>
        /// A hash of name=>animation
        /// </summary>
        private Dictionary<string, AnimatorClip> AnimationHash;

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
        private AnimatorClip currentClip;
        private int currentIndex;
        private float timeTillNextFrame;

        /// <summary>
        /// Switches to the target clip
        /// </summary>
        /// <param name="clipName">The target clip</param>
        public void PlayClip(string clipName)
        {
            AnimatorClip clip;
            if (!this.AnimationHash.TryGetValue(clipName, out clip))
            {
                Debug.LogError("Clip does not exist: " + clipName);
            }

            this.PlayClip(clip);
        }

        /// <summary>
        /// used for initialization
        /// </summary>
        private void Start()
        {
            this.Sprites = Resources.LoadAll<Sprite>(this.SpriteSheetPath).ToList();
            this.renderer = this.GetComponent<SpriteRenderer>();

            this.AnimationHash = new Dictionary<string, AnimatorClip>();

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
        private void Update()
        {
            if (this.currentClip != null)
            {
                this.timeTillNextFrame -= Time.deltaTime;
                if (this.timeTillNextFrame < 0)
                {
                    this.currentIndex++;
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
            }
        }

        /// <summary>
        /// Plays the target clip
        /// </summary>
        /// <param name="targetClip">Target clip to be played</param>
        private void PlayClip(AnimatorClip targetClip)
        {
            this.currentClip = targetClip;
            this.currentIndex = 0;
            this.timeTillNextFrame = targetClip.Delay;
            this.renderer.sprite = this.Sprites[0];
        }
    }
}
