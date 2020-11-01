using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManger : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiate Player Controller");

        if (PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(0, 0, 0), Quaternion.identity);

        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(10,0,10), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
