//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GameController.cs">
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

    /// <summary>
    /// The level controller
    /// </summary>
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// Gets the current instance of the <see cref="GameController"/> class
        /// </summary>
        public static GameController CurrentInstance
        {
            get
            {
                if (GameController._currentInstance == null)
                {
                    GameController._currentInstance = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
                }

                return GameController._currentInstance;
            }
        }
        private static GameController _currentInstance;

        /// <summary>
        /// Gets a list of currently active players
        /// </summary>
        public List<PlayerController> Players
        {
            get
            {
                if (this._players == null)
                {
                    this._players = new List<PlayerController>();
                }

                return this._players;
            }
            set
            {
                this._players = value;
            }
        }
        private List<PlayerController> _players;
        
        /// <summary>
        /// Registers a new player controller
        /// </summary>
        /// <param name="controller">The controller being registered</param>
        /// <returns>Index  of the new controller</returns>
        public void RegisterPlayer(PlayerController controller)
        {
            this.Players.Add(controller);
            this.Players = this.Players.OrderBy(player => player.PlayerIndex).ToList();
        }
    }
}
