using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;


public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager basicinstance;
    // Start is called before the first frame update
    public float ReadyNumber=0;
    public GameObject readyButton;
    public GameObject readyPanel;
    protected PhotonView PV;
    Hashtable ReadyList;
    public Text numberCount;
   

    public void Awake()
    {
        ReadyNumber = 0;
        ReadyList = new Hashtable();
        basicinstance = this;
        PV = GetComponent<PhotonView>();
        foreach (var player in PhotonNetwork.PlayerList)
        {
            //PlayerScoreList.Add(player.NickName, 0);
           
            ReadyList.Add(player.NickName, true);
        }
    }
    public virtual void ReadyToPlay() {
        //ReadyNumber=ReadyNumber+1;
        readyButton.SetActive(false);
        PV.RPC("SetReady", RpcTarget.AllBuffered, new object[] { PhotonNetwork.NickName});
        if (ReadyNumber == PhotonNetwork.PlayerList.Length)
        {
            PV.RPC("StartGame", RpcTarget.AllBuffered, new object[] {});
        }
        
    }

    [PunRPC]
    public void SetReady(string nickName) {
        ReadyList[nickName] = true;
        ReadyNumber=ReadyNumber+1;
        numberCount.text = ReadyNumber.ToString() + " Ready Player";
    }

    [PunRPC]
    public void StartGame() {
        readyPanel.SetActive(false);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
    }

    public void QuitGame()
    {
        StartCoroutine(DisconnectedandLoadMenu());
        //ReconnectAgain();
    }
    IEnumerator DisconnectedandLoadMenu()
    {
        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
            yield return null;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.LoadLevel(0);
    }
   




}
