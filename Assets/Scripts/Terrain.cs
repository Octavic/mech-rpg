//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Terrain.cs">
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
    using Mech;

    /// <summary>
    /// Defines the terrain
    /// </summary>
    public class Terrain : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            var floorCheck = collision.GetComponent<MechFloorCheck>();
            if (floorCheck)
            {
                floorCheck.Mech.IsAirborne = false;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            var floorCheck = collision.GetComponent<MechFloorCheck>();
            if (floorCheck)
            {
                floorCheck.Mech.IsAirborne = true;
            }
        }
    }
}
