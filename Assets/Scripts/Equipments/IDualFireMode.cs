//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDualFireMode.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines a weapon that can have two fire modes (long vs short press)
    /// </summary>
    public interface IDualFireMode
    {
        // ------------------------------------------------------
        // |                    |                                
        // ------------------------------------------------------
        // Start           Long Press threshold

        // Example of short press
        // ------------------------------------------------------
        // |         |        
        // ------------------------------------------------------
        // s         r
        // s - Start
        // r - Release
        // Calls: OnShortpressReleasee() at r

        // Example of long press
        // ------------------------------------------------------
        // |                    |                    |                           
        // ------------------------------------------------------
        // s                    t                    r
        // s - Start
        // t - Long Press Threshold
        // r - Release
        // Calls: OnLongPressStart() at t
        //        OnLongPressRelease() at r

        /// <summary>
        /// Called when the short press is released
        /// </summary>
        void OnShortPressRelease();

        /// <summary>
        /// Called when the long press starts
        /// </summary>
        void OnLongPressStart();

        /// <summary>
        /// Called when the long press is released
        /// </summary>
        void OnLongPressRelease();
    }
}
