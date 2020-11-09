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

    void Awake()
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
            GameObject Mutant= PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), transform.position, transform.rotation);
            int playerID = Mutant.GetComponent<PhotonView>().ViewID;
            GameObject playericon = controller.PlayerIcon;
            int viewID = playericon.GetComponent<PhotonView>().ViewID;
            PV.RPC("SwitchParent", RpcTarget.AllBuffered, new object[] { viewID, playerID });
            PV.RPC("BeMutant", RpcTarget.All, new object[] { mutantID });  
        }

    }


    //public void BeginMutant() {
    //    controller.State = PlayerControllerTest.PlayerState.Mutant;
    //    int mutantID = PV.ViewID;
    //    GameObject mutant=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), transform.position, transform.rotation);
    //    PV.RPC("BeMutant", RpcTarget.All, new object[] { mutantID });
    //}


    [PunRPC]
    void BeMutant(int mutantID) {
         Destroy(gameObject);
    }

    [PunRPC]
    void SwitchParent(int viewID, int playerID)
    {
         GameObject icon = PhotonView.Find(viewID).gameObject;
         GameObject player = PhotonView.Find(playerID).gameObject;
            //icon.GetComponent<PlayerIcon>().setPlayer(player);
         player.GetComponent<PlayerControllerTest>().SetIcon(icon);
         
    }

    }
}
