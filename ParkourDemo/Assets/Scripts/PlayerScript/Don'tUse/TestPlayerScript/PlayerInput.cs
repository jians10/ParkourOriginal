using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

    public class PlayerInput : MonoBehaviourPunCallbacks
    {
        [HideInInspector]
        public InputStr Input;
        public struct InputStr
        { 
            public float RunX;
            public float RunZ;
            public bool Jump;
        }

        public const float Speed = 10f;
        public const float JumpForce = 5f;

        [HideInInspector]
        public PlayerState State = PlayerState.NORMAL;

        protected Rigidbody Rigidbody;
        protected Quaternion LookRotation;
        protected Collider MainCollider;
        protected Animator CharacterAnimator;
        protected GameObject CharacterRagdoll;

        protected bool Grounded = true;

        private void Awake()
        {
        
            Rigidbody = GetComponent<Rigidbody>();
            CharacterAnimator = GetComponentInChildren<Animator>();
            MainCollider = GetComponent<Collider>();
        }
        private void Update()
        {
            if (Rigidbody == null)
                return;
            CharacterAnimator.SetBool("Grounded", Grounded);
            var localVelocity = Quaternion.Inverse(transform.rotation) * (Rigidbody.velocity / Speed);
            CharacterAnimator.SetFloat("RunX", localVelocity.x);
            CharacterAnimator.SetFloat("RunZ", localVelocity.z);
        }
        public enum PlayerState
        {
            NORMAL,
            TRANSITION,
            Special
        }

        

}