using GameStates.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameStates
{
    public class PauseState : BaseState
    {

        public PauseState() : base() { }

        public override void OnEnter()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        public override State OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return new PlayState();
            }

            return this;
        }
    }
}
