//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BulletLine.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Equipments.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a bullet line
    /// </summary>
    public class BulletLine : SegmentLine
    {
        /// <summary>
        /// The little splash 
        /// </summary>
        public DelayedSelfDestroy SplashPrefab;

        public void OnBulletHit(Vector2 muzzleLocation, RaycastHit2D hit)
        {
            var hitPos = hit.transform.position;
            this.Connect(muzzleLocation, hit.point);
            var newSplash = Instantiate(this.SplashPrefab);
            newSplash.transform.position = hit.point;
            var hitAngle = hit.normal;
            newSplash.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(hitAngle.y, hitAngle.x) * Mathf.Rad2Deg);
        }
    }
}
