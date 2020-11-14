using UnityEngine;
using Photon.Pun;
using System.Collections;

namespace Parkour
{
    public class EndPoint : MonoBehaviour
    {
        // Start is called before the first frame update
        // public int Counter=0;
        public bool Activated = true;
        

        void Awake()
        {
            
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
                if (IR != null&&Activated)
                {
                    RaceGameManager.instance.ReachEndPoint(PhotonNetwork.LocalPlayer);
                    Activated = false;
                }
            }
        }

         

    }
}
