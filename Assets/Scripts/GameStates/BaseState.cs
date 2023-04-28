using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStates
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    namespace PlayerStates
    {
        public abstract class BaseState : State
        {

            protected GameObject pauseMenu;

            public BaseState()
            {
                this.pauseMenu = GameObject.Find("/Canvas/PauseMenu");
            }

            public virtual void OnEnter()
            {

            }

            public virtual State OnUpdate()
            {
                return this;
            }

            public virtual State OnFixedUpdate()
            {
                return this;
            }
        }

    }

}
