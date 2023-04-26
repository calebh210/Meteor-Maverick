using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates {
    public class Idle : BaseState
    {
       

        public Idle (GameObject player) : base (player) 
        { 
            
        }

        public override void OnEnter()
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80, 0.5f);
        }

        public override State OnUpdate()
        {
            
            if (Input.GetKey("space"))
            {
                return new UsingBoost(player);
            }

            if (Input.GetKey("c"))
            {
                return new UsingBrake(player);
            }

            return this;
        }

    }
}