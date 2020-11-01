using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Parkour
{
    public class JetPack : MonoBehaviour
    {
        // Start is called before the first frame update

        public float JetForce;
        //public float JetWait;
        public float JetRecover;
        public float maxfuel;
        public float currentFuel;
        //public float currentRecovery;
        bool canJet;
        private Rigidbody rb;
        private PlayerControllerTest player;
        bool Grounded;
        public bool JetActivate;
        public GameObject JetPackMesh;
        public float JetDurationTime=10;
        public bool EndJet=false; 
        private void Awake()
        {

            rb = GetComponent<Rigidbody>();
            player = GetComponent<PlayerControllerTest>();
        }


        void Start()
        {
            currentFuel = maxfuel;
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!JetActivate)
            {
                JetPackMesh.SetActive(false);
                return;

            }
            JetPackMesh.SetActive(true);
            if (rb == null)
            {
                return;
            }
            canJet = player.Input.Jet;
            Grounded = player.Grounded;
            if (canJet&&!Grounded) {

                if (currentFuel > 0) {

                    rb.AddForce(Vector3.up * JetForce * Time.fixedDeltaTime, ForceMode.Acceleration);
                    currentFuel = Mathf.Max(0, currentFuel - Time.fixedDeltaTime);
                }
            }
            if (Grounded) {

                //if (currentRecovery < JetWait)
                //{
                //    currentRecovery = Mathf.Min(JetWait, currentRecovery + Time.fixedDeltaTime);
                //}
                //else
                //{
                currentFuel = Mathf.Min(maxfuel, currentFuel + Time.fixedDeltaTime * JetRecover);
                //}
            }
            SonicCounter();
          
        }
        void SonicCounter()
        {

            JetDurationTime = JetDurationTime - Time.deltaTime;

            if (JetDurationTime <= 0)
            {
                EndJet = true;
            }
            else
            {
                EndJet = false;
            }

            if (EndJet)
            {
                JetDurationTime= 10f;
                JetActivate = false;
            }

        }





    }
}