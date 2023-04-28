using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStates.PlayerStates;
using UnityEngine;

namespace GameStates
{
    public class PlayState : BaseState
    {
        public PlayState() : base() { }

        public override void OnEnter()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        public override State OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return new PauseState();
            }

            return this;
        }

        
    }
}
