using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerStates
{
    public abstract class BaseState : State
    {

        protected GameObject player;
        protected PlayerHealth healthController;
        protected PlayerMovementController playerController;
        protected PlayerAbilities playerAbilities;
        protected Cinemachine.CinemachineDollyCart dollyCart;
        protected Camera cam;

        public BaseState(GameObject player)
        {
            this.player = player;
            this.healthController = player.GetComponent<PlayerHealth>();
            this.playerController = player.GetComponent<PlayerMovementController>();
            this.playerAbilities = player.GetComponent<PlayerAbilities>();
            this.dollyCart = player.GetComponentInParent<Cinemachine.CinemachineDollyCart>();
            this.cam = Camera.main; 
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
