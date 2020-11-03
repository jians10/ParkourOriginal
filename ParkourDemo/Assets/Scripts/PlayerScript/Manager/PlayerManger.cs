using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManger : MonoBehaviour
{
    PhotonView PV;
    public Vector3 LeftBound;
    public Vector3 RightBound;
    public Vector3 ChaserPosition;
    private float Zpos;
    private float Xpos;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        LeftBound = GameObject.Find("LBound").transform.position;
        RightBound = GameObject.Find("RBound").transform.position;
        ChaserPosition = GameObject.Find("MPosition").transform.position;
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
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(10, 0, 10), Quaternion.identity);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), ChaserPosition, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(Xpos, LeftBound.y, Zpos), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomValueGenerator()
    {
        Zpos = Random.Range(Mathf.Min(RightBound.z, LeftBound.z), Mathf.Max(RightBound.z, LeftBound.z));
        Xpos = Random.Range(Mathf.Min(RightBound.x, LeftBound.x), Mathf.Max(RightBound.x, LeftBound.x));
    }
}
