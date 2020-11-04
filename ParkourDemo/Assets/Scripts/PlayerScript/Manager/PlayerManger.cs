using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    public GameObject PlayerIconLocal = null;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        LeftBound = GameObject.Find("LBound").transform.position;
        RightBound = GameObject.Find("RBound").transform.position;
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

        if (PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), Vector3.zero, Quaternion.identity);
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(10, 0, 10), Quaternion.identity);
            GameObject player=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MutantPlayer"), ChaserPosition, Quaternion.identity);
           
            if (RoomIndex == 2) {
                int playerID = player.GetComponent<PhotonView>().ViewID;
                GameObject playericon = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerIcon"), MapImage.transform.position, Quaternion.identity);
                //playericon.GetComponent<PlayerIcon>().setPlayer(player);
                int viewID = playericon.GetComponent<PhotonView>().ViewID;
                PV.RPC("SetIconParent", RpcTarget.AllBuffered, new object[] {viewID, playerID });
                Instantiate(PlayerIconLocal, MapImage).GetComponent<PlayerIconLocal>().setPlayer(player);
            }
            //RandomValueGenerator();
           

        }
        else
        {
            RandomValueGenerator();
            GameObject player=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerNeo"), new Vector3(Xpos, LeftBound.y, Zpos), Quaternion.identity);
            if (RoomIndex == 2)
            {
                int playerID = player.GetComponent<PhotonView>().ViewID;
                GameObject playericon = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerIcon"), MapImage.transform.position, Quaternion.identity);
                playericon.GetComponent<PlayerIcon>().setPlayer(player);
                //playericon.transform.SetParent(MapImage);
                int viewID = playericon.GetComponent<PhotonView>().ViewID;
                PV.RPC("SetIconParent", RpcTarget.AllBuffered, new object[] { viewID, playerID });
                Instantiate(PlayerIconLocal, MapImage).GetComponent<PlayerIconLocal>().setPlayer(player);

            }
            Zpos = 0;
            Zpos = 0;
        }
       // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TestExample"), ChaserPosition, Quaternion.identity);
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

    [PunRPC]
    void SetIconParent(int viewID, int playerID) {
        GameObject icon = PhotonView.Find(viewID).gameObject;
        GameObject player= PhotonView.Find(playerID).gameObject;
        icon.GetComponent<PlayerIcon>().setPlayer(player);
        icon.transform.SetParent(MapImage);
    }
}
