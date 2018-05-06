//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseMech.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// The base mech object
    /// </summary>
    public abstract class BaseMech : MonoBehaviour
    {
        /// <summary>
        /// Id of the mech
        /// </summary>
        public int MechId;

        /// <summary>
        /// Name of the mech
        /// </summary>
        public string MechaName;

        /// <summary>
        /// The base stats of a mech
        /// </summary>
        public MechStats BaseStats;

        /// <summary>
        /// The sprite renderer
        /// </summary>
        public SpriteRenderer Renderer;

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this.Renderer = this.GetComponent<SpriteRenderer>();
            var sprites = Resources.LoadAll<Sprite>(this.MechaName);
            this.Renderer.sprite = sprites[0];
        }
    }
}
