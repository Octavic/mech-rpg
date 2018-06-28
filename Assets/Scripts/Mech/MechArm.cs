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
                // Set new equip's render layer
                if (value != null)
                {
                    value.GetComponent<SpriteRenderer>().sortingOrder = this.IsOnTop ? 1 : -1;

                    value.EquippedOnArm = this;
                    value.transform.parent = this.transform;
                    value.transform.localPosition = this.IsOnTop ? Config.WeaponHandOffset : Utils.FlipX(Config.WeaponHandOffset);
                }

                this._equipped = value;
            }
        }

        /// <summary>
        /// Unequips the current equipped item
        /// </summary>
        /// <returns>The unequipped item</returns>
        public BaseEquipment Unequip()
        {
            if (this.Equipped != null)
            {
                this.Equipped.EquippedOnArm = null;
            }

            return this.Equipped;
        }

        private BaseEquipment _equipped;
    }
}
