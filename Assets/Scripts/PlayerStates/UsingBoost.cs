using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerStates
{
    public class UsingBoost : BaseState
    {
       
        public UsingBoost(GameObject player) : base(player) 
        {
                  
        }

        public override void OnEnter()
        {
            dollyCart.m_Speed = 90f;
            
        }

        public override State OnUpdate()
        {

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 100, 0.5f);

            //stopped using boost
            if (!Input.GetKey("space"))
            {
                return new AbilityRecharging(player);
            }

            if (Input.GetKey("c"))
            {
                return new UsingBrake(player);
            }

            if (playerAbilities.abilityTime <= 0f)
            {
                return new AbilityRecharging(player);
            }

            playerAbilities.UpdateAbilityTime(-0.25f);

            return this;
        }

    }
}
