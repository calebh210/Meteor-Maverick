using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStates.PlayerStates;
using UnityEngine;
using UnityEngine.Events;

namespace GameStates
{
    public class PlayState : BaseState
    {
        public UnityEvent HideMenu;
        public PlayState(GameObject PauseMenu) : base(PauseMenu) { }

        public override void OnEnter()
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            
        }

        public override State OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return new PauseState(PauseMenu);
            }

            return this;
        }

        
    }
}
