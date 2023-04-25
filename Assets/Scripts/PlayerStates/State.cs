using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerStates
{
    public interface State
    {

        void OnEnter();

       
        State OnUpdate();

        State OnFixedUpdate();

    }
}
