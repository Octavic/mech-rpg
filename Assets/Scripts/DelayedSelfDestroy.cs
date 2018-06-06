//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DelayedSelfDestroy.cs">
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
    /// Defines an object that self destructs after the set delay
    /// </summary>
    public class DelayedSelfDestroy : MonoBehaviour
    {
        /// <summary>
        /// How long it'll take to detonate
        /// </summary>
        public float Delay;
        private float _timeLeft;

        /// <summary>
        /// If the  timer is ticking down
        /// </summary>
        public bool IsTicking { get; set; }

        /// <summary>
        /// Resets the ticking timer
        /// </summary>
        /// <param name="shouldStartTicking">If the object should immediately start counting down to self destruction</param>
        public void ResetTimer(bool shouldStartTicking = true)
        {
            this._timeLeft = this.Delay;
            this.IsTicking = shouldStartTicking;
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected virtual void Start()
        {
            this.ResetTimer();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void Update()
        {
            if (this.IsTicking)
            {
                this._timeLeft -= Time.deltaTime;
                if (this._timeLeft <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
