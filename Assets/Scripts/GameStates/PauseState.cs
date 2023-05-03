using GameStates.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace GameStates
{
    public class PauseState : BaseState
    {
        //Event to show menu when in pause state
        public UnityEvent ShowMenu;
        public PauseState(GameObject PauseMenu) : base(PauseMenu) { }

        public override void OnEnter()
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
          
        }

        public override State OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return new PlayState(PauseMenu);
            }

            return this;
        }
    }
}
