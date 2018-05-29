//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseEnemy.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Enemy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines an enemy's combat stats 
    /// </summary>
    [Serializable]
    public class EnemyStats
    {
        public float Attack;
        public float HP;
        public float Armor;
        public float Resistance;
    }
}
