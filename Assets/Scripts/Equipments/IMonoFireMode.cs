//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IMonoFireMode.cs">
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
    /// Defines an equipment that only have one fire mode
    /// </summary>
    public interface IMonoFireMode
    {
        void OnPressStart();
        void OnPressRelease();
    }
}
