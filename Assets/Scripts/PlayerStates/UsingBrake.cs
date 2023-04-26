using UnityEngine;

namespace PlayerStates
{
    public class UsingBrake : BaseState
    {

        public UsingBrake(GameObject player) : base(player)
        {

        }

        public override void OnEnter()
        {
            dollyCart.m_Speed = 20f;
           
        }

        public override State OnUpdate()
        {

            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);

            //stopped using brake
            if (!Input.GetKey("c"))
            {
                return new AbilityRecharging(player);
            }

            //now boosting
            if(Input.GetKey("space")) 
            { 
                return new UsingBoost(player);
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
