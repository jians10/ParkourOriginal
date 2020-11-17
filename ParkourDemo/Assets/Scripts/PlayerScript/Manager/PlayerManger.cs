using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Parkour;

public class PlayerManger : MonoBehaviour
{
    PhotonView PV;
    public Vector3 LeftBound;
    public Vector3 RightBound;
    public Vector3 ChaserPosition;
    public int RoomIndex;
    private float Zpos;
    private float Xpos;
    Transform MapImage=null;
    //public GameObject PlayerIconLocal = null;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        LeftBound = GameObject.Find("LBound").transform.position;
        Debug.Log(LeftBound);
        RightBound = GameObject.Find("RBound").transform.position;
        Debug.Log(RightBound);
        ChaserPosition = GameObject.Find("MPosition").transform.position;
        RoomIndex = SceneManager.GetActiveScene().buildIndex;
        if (RoomIndex == 2) {
            MapImage = GameObject.Find("MapImage").transform;
        }
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

        if (RoomIndex == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), ChaserPosition, Quaternion.identity);
                int playerID = player.GetComponent<PhotonView>().ViewID;
                GameObject playericon = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerIcon"), MapImage.transform.position, Quaternion.identity);
                int viewID = playericon.GetComponent<PhotonView>().ViewID;
                PV.RPC("SetIconParent", RpcTarget.AllBuffered, new object[] { viewID, playerID });
                MazeGameManager.instance.IncreaseMutantCount();
            }
            else
            {
                RandomValueGenerator();
                GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(Xpos, LeftBound.y, Zpos), Quaternion.identity);
                int playerID = player.GetComponent<PhotonView>().ViewID;
                GameObject playericon = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerIcon"), MapImage.transform.position, Quaternion.identity);
                int viewID = playericon.GetComponent<PhotonView>().ViewID;
                PV.RPC("SetIconParent", RpcTarget.AllBuffered, new object[] { viewID, playerID });
                Zpos = 0;
                Xpos = 0;
            }
        }
        else {
            RandomValueGenerator();
            GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(Xpos, LeftBound.y, Zpos), Quaternion.identity);
        }
    }
    void Update()
    {
        
    }

    private void RandomValueGenerator()
    {
        Zpos = Random.Range(Mathf.Min(RightBound.z, LeftBound.z), Mathf.Max(RightBound.z, LeftBound.z));
        Xpos = Random.Range(Mathf.Min(RightBound.x, LeftBound.x), Mathf.Max(RightBound.x, LeftBound.x));

        //float[] choicesX = { Mathf.Min(RightBound.x, LeftBound.x), Mathf.Max(RightBound.x, LeftBound.x) };
        //int XChoice = Random.Range(0, 2);
        //Zpos = choicesX[XChoice];
    }

    [PunRPC]
    void SetIconParent(int viewID, int playerID) {
        GameObject icon = PhotonView.Find(viewID).gameObject;
        GameObject player= PhotonView.Find(playerID).gameObject;
        //icon.GetComponent<PlayerIcon>().setPlayer(player);
        player.GetComponent<PlayerControllerTest>().SetIcon(icon);
        icon.transform.SetParent(MapImage);
    }
}
