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

            protected GameObject PauseMenu;
           
            public BaseState(GameObject PauseMenu)
            {
               this.PauseMenu = PauseMenu;
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
