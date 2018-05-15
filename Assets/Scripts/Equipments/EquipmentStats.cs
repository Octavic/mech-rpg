//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EquipmentStats.cs">
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
    /// The basic Equipment stats
    /// </summary>
    [Serializable]
    public class EquipmentStats
    {
        public float Damage;
        public float ReloadSpeed;
        public float CritChance;
        public float CritDamage;
        public float Impact;
    }
}
