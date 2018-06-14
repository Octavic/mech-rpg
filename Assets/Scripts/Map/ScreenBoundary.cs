//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ScreenBoundary.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Equipments.Weapons;
    using UnityEngine;

    /// <summary>
    /// Defines the screen's boundary
    /// </summary>
    public class ScreenBoundary : MonoBehaviour, IHittable
    {
        public Factions Faction
        {
            get
            {
                return Factions.Environment;
            }
        }

        public void OnHit(WeaponHitStat hit)
        {
        }
    }
}
