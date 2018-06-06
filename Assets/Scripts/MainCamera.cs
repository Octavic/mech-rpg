//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MainCamera.cs">
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
    /// The main camera
    /// </summary>
    public class MainCamera : MonoBehaviour
    {
        private const float MinMagnitude = 0.001f;

        /// <summary>
        /// The magnitude and decrease of vibration
        /// </summary>
        private float _magnitude;
        private float _deacyFactor;
        private Vector3 _panFocus;

        /// <summary>
        /// Gets the current instance of the <see cref="MainCamera"/> class
        /// </summary>
        public static MainCamera CurrentInstance
        {
            get
            {
                return MainCamera._currentInstance;
            }
        }
        private static MainCamera _currentInstance;

        /// <summary>
        /// 
        /// </summary>
        public MainCamera()
        {
            MainCamera._currentInstance = this;
        }

        /// <summary>
        /// Shakes the camera
        /// </summary>
        /// <param name="magnitue">The initial magnitude of the shake</param>
        /// <param name="decayFactor">How fast the magnitude decays</param>
        public void Shake(float magnitue, float decayFactor = 0.7f)
        {
            this._magnitude = magnitue;
            this._deacyFactor = decayFactor;
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this._panFocus = this.transform.position;
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected void Update()
        {
            if (this._magnitude > 0)
            {
                this._magnitude = Utils.Lerp(this._magnitude, 0, this._deacyFactor);
                if (this._magnitude <= MinMagnitude)
                {
                    this._magnitude = 0;
                }
                else
                {
                    var randomAngle = GlobalRandom.NextFloat() * Mathf.PI * 2;
                    var offset = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0) * this._magnitude;
                    this.transform.position = this._panFocus + offset;
                }
            }
        }
    }
}
