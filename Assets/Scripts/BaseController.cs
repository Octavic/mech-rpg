//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseController.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Assets.Scripts.Mech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Defines a player/ai controller
    /// </summary>
    public abstract class BaseController : MonoBehaviour
    {
        /// <summary>
        /// The controlled mech
        /// </summary>
        public BaseMech Mech;

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected virtual void Start()
        {
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void FixedUpdate()
        {
        }
    }
}
