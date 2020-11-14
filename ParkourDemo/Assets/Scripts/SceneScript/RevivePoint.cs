using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace Parkour
{

    public class RevivePoint : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool Activated;
        public float index;
        public Transform RevivePosition; 
        void Awake()
        {
            Activated = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameObject target = other.gameObject;
                InputReceive IR = target.GetComponent<InputReceive>();
                if (IR != null)
                {
                    Activated = true;
                    IncreaseScore();
                }
            }
        }

        private void IncreaseScore() {

            if (index > RaceGameManager.instance.CurrentRevivePointIndex()) {
                RaceGameManager.instance.setRevive(this);
                RaceGameManager.instance.Scoreincrement(PhotonNetwork.LocalPlayer,10);
            }

        }


    }
}