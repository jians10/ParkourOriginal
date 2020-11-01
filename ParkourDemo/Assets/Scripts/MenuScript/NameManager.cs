using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;


public class NameManager : MonoBehaviour
{
    public TMP_InputField Name;
    
    // Start is called before the first frame update

    // Update is called once per frame

    public void PlayerButton() {



        if (Name.text.Length < 2)
        {
            Name.text = null;
        }
        else
        {
            PhotonNetwork.NickName = Name.text;

        }
        PhotonNetwork.NickName = Name.text;
    }

    //public void Join
}
