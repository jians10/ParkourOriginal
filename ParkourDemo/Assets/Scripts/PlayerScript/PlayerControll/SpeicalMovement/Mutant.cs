using Photon.Pun;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;


namespace Parkour { 
public class Mutant : MonoBehaviour
{
    // Start is called before the first frame update


    public bool mutant;
    PhotonView PV;
    private PlayerControllerTest controller;
    private Rigidbody rb;

    void Start()
    {
      
        PV = GetComponent<PhotonView>();
        controller = GetComponent<PlayerControllerTest>();
            rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        if (rb == null) {
            return;    
            
        }

        if (mutant) {

            controller.State = PlayerControllerTest.PlayerState.Mutant;
            int mutantID = PV.ViewID;
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), transform.position, transform.rotation);
            PV.RPC("BeMutant", RpcTarget.All, new object[] { mutantID });  
        }

    }

    [PunRPC]
    void BeMutant(int mutantID) {
        GameObject mutantplayer= PhotonView.Find(mutantID).gameObject;
        if (mutantplayer != null&& mutantplayer.tag == "Player") {
            Destroy(mutantplayer);
        }   
    }


     private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Mutant") {

           mutant = true;
            
        }    
     }

    }
}
