//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MechArm.cs">
//    Copyright (c) Yifei Xu .  All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Mech
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Animations;
    using Equipments;
    using UnityEngine;

    /// <summary>
    /// Defines a mech's arms
    /// </summary>
    public class MechArm : Animatable
    {
        /// <summary>
        /// If the arm is rendered on top
        /// </summary>
        public bool IsOnTop;

        /// <summary>
        /// The currently equipped item
        /// </summary>
        public BaseEquipment Equipped
        {
            get
            {
                return this._equipped;
            }
            set
            {
                // Unequip what's currently in hand
                if (this._equipped != null)
                {
                    this._equipped.EquippedOnArm = null;
                }

                // Set new equip's render layer
                if (value != null)
                {
                    value.GetComponent<SpriteRenderer>().sortingOrder = this.IsOnTop ? 1 : -1;

                    value.EquippedOnArm = this;
                    value.transform.parent = this.transform;
                    value.transform.localPosition = Config.WeaponHandOffset;
                }

                this._equipped = value;
            }
        }

        private BaseEquipment _equipped;
    }
}
