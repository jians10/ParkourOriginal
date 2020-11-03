﻿using Parkour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;
using UnityEngine.PlayerLoop;

namespace Parkour
{



    public class MutantControllerTest : PlayerControllerTest
    {

        public bool CheckingTarget=false;
        public bool Attack=false;
        public bool AbletoAttack=true;
        public float SkillCoolDownLeft = 10f;
        public bool SkillReady = false;
        public GameObject toxin;


        private new void Awake()
        {
            toxin.SetActive(false);
            base.Awake();
        }


        private new void Update()
        {
            base.Update();

            CharacterAnimator.SetBool("Attack", Attack);
        }
        // Start is called before the first frame update
        protected new void FixedUpdate()
        {
            if (Rigidbody == null)
                return;

            Rigidbody.useGravity = State == PlayerState.Hanging;
            SpecialSkillCounter();
            switch (State)
            {

                case PlayerState.Sonic:
                    SonicCounter();
                    Look();
                    Dash();
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    MaxSpeed = SpeedValue * 2;
                    NeoMove();
                    Hanging();
                    Slide();
                    Climbing();
                    Vaulting();
                    Infection();
                    EXinfection();
                    Attacking();
                    break;

                case PlayerState.NORMAL:
                    Look();
                    Dash();
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    MaxSpeed = SpeedValue;
                    NeoMove();
                    Hanging();
                    //PickUp();
                    Slide();
                    Climbing();
                    Vaulting();
                    Infection();
                    EXinfection();
                    Attacking();
                    break;

                case PlayerState.Dash:
                    Dashing();
                    break;
                case PlayerState.Hanging:
                    AbletoGrab = false;
                    HangingStable();
                    Rigidbody.velocity = Vector3.zero;
                    CurrentSpeed = 0;
                    PullUp();
                    PullDown();
                    break;
                case PlayerState.Lifting:
                    Throw();
                    MaxSpeed = SpeedValue / 2;
                    NeoMove();
                    CheckCarrying();
                    Look();
                    if (Item != null)
                    {
                        Item.gameObject.transform.localPosition = new Vector3(DistanceX, DistanceY, DistanceZ);
                    }
                    break;
                case PlayerState.Climbing:
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    Rigidbody.velocity = Vector3.zero;
                    CurrentSpeed = 0;
                    ClimbUp();
                    ClimbQuit();
                    ClimbingUp();
                    cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, -3), 5f * Time.deltaTime);
                    verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
                    cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
                    break;

            }


            Rigidbody.useGravity = State == PlayerState.NORMAL || State == PlayerState.Sonic || State == PlayerState.Lifting;
            MainCollider.enabled = State == PlayerState.NORMAL || State == PlayerState.Dash || State == PlayerState.Sonic || State == PlayerState.Lifting;
        }


        void Infection() {
            Vector3 DetectCenter = transform.position + transform.forward * 0.4f + transform.up * 1.4f ;
            Vector3 DetectSize = new Vector3(1.6f, 0.5f, 0.8f);
            Collider[] Targets = Physics.OverlapBox(DetectCenter, DetectSize, transform.rotation, 1 << 12);
            if (Targets.Length < 0) {
                return;
            } 
            
            foreach (Collider Target in Targets) {
                if (Target != null)
                {
                    if (Target.gameObject.tag == "Player")
                    {
                        int ID = Target.gameObject.GetComponent<PhotonView>().ViewID;
                        PV.RPC("MutantTarget", RpcTarget.All, new object[] { ID });
                    }
                }
            }
        }
        void EXinfection()
        {
            if (!CheckingTarget) {
                return;
            }
            Vector3 DetectCenter = transform.position;
            Collider[] Targets = Physics.OverlapSphere(DetectCenter, 3.5f, 1 << 12);
            if (Targets.Length < 0)
            {
                return;
            }

            foreach (Collider Target in Targets)
            {
                if (Target != null)
                {
                    if (Target.gameObject.tag == "Player")
                    {
                        int ID = Target.gameObject.GetComponent<PhotonView>().ViewID;
                        PV.RPC("MutantTarget", RpcTarget.All, new object[] { ID });
                    }
                }
            }
        }

        [PunRPC]
        void MutantTarget(int id)
        {
            PhotonView target = PhotonView.Find(id);
            if (target != null)
            {
                if (target.gameObject.tag == "Player" && target.GetComponent<Mutant>() != null)
                {
                    target.GetComponent<Mutant>().mutant = true;
                }
            }
        }

        void Attacking() {

            Attack = Input.PickUp && AbletoAttack;
            
        }

        public void StartCheckingTarget(){
            CheckingTarget = true;
            toxin.SetActive(true);
        }

        public void EndCheckingTarget(){
            CheckingTarget = false;
            toxin.SetActive(false);
        }


        protected void SpecialSkillCounter()
        {

            if (SkillCoolDownLeft > -1)
            {
                SkillCoolDownLeft = SkillCoolDownLeft - Time.deltaTime;
            }

            if (SkillCoolDownLeft <= 0)
            {
                AbletoAttack = true;
            }
            else
            {
                AbletoAttack = false;
            }

            if (Attack) {
                SkillCoolDownLeft = 10f;
            }

        }


    }
}