using PlayerStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class AbilityRecharging : BaseState
    {
        private float currentTime;
        float Cooldown = 5.0f;
        public AbilityRecharging(GameObject player) : base(player) 
        { 
            
        }

        public override void OnEnter()
        {
            currentTime = Time.time;
            dollyCart.m_Speed = 50f;
           
        }

        public override State OnUpdate()
        {

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80, 0.5f);

            Debug.Log(dollyCart.m_Speed);

            if (currentTime + Cooldown < Time.time) 
            {
               playerAbilities.UpdateAbilityTime(0.25f);
            }

            //returns to idle if ability fully charged
            if(playerAbilities.abilityTime >= 100f)
            {
                return new Idle(player);
            }

            //returns back to using state if player uses ability mid recharge
            if (Input.GetKey("space") && playerAbilities.abilityTime > 0)
            {
                return new UsingBoost(player);
            }

            if (Input.GetKey("c") && playerAbilities.abilityTime > 0)
            {
                return new UsingBrake(player);
            }

            return this;

        }


    }
}
