using Photon.Pun;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;


namespace Parkour
{
    public class Infection : MonoBehaviour
    {
        // Start is called before the first frame update

        PhotonView PV;
        private Rigidbody rb;
        void Start()
        {

            PV = GetComponent<PhotonView>();
            rb = GetComponent<Rigidbody>();

        }

        // Update is called once per frame
        void Update()
        {
            if (!PV.IsMine)
            {
                return;
            }
            if (rb == null)
            {
                return;

            }
        }


        private void OnTriggerEnter(Collider other)
        {
            
            if (other == null) {

                return; 
            }

            if (other.gameObject.tag == "Player")
            {
                if (other.gameObject.GetComponent<PhotonView>() != null)
                {

                    int ID = other.gameObject.GetComponent<PhotonView>().ViewID;
                    
                    if (ID != null)
                    {
                        PV.RPC("SetTarget", RpcTarget.All, new object[] { ID });
                    }
                }
            }
        }



        [PunRPC]
        void SetTarget(int id) {

            GameObject target= PhotonView.Find(id).gameObject;
            if (target.GetComponent<Mutant>() != null)
            {
                target.GetComponent<Mutant>().mutant = true;
            }
        }
    }
}
