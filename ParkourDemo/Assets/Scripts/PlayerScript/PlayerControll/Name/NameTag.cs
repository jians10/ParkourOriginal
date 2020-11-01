using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace Parkour
{

    public class NameTag : MonoBehaviour
    {
        // Start is called before the first frame update
        private PhotonView PV;
        public TMP_Text NAMEPLATE;

        void Awake()
        { 
                string name = PhotonNetwork.NickName;
                PV = GetComponent<PhotonView>();
            if (PV!= null && PV.IsMine){
                PV.RPC("getName", RpcTarget.AllBuffered, name);
            }
        }

        [PunRPC]
        public void getName(string name)
        {
            NAMEPLATE.text = name;
        }
    }

}