using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using Photon.Realtime;


public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager basicinstance;
    // Start is called before the first frame update
    public float ReadyNumber=0;
    public GameObject readyButton;
    public GameObject readyPanel;
    protected PhotonView PV;
    Hashtable ReadyList;
    public Hashtable ScoreList;
    public Text numberCount;
    public Vector3 G = new Vector3(0, -10f, 0);
   

    public void Awake()
    {
        Physics.gravity = G;
        ReadyNumber = 0;
        ReadyList = new Hashtable();
        ScoreList = new Hashtable();
        basicinstance = this;
        PV = GetComponent<PhotonView>();
        foreach (var player in PhotonNetwork.PlayerList)
        {
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
    public void IncreaseScore(Player player, int addAmount)
    {
        PV.RPC("Scoreincrement", RpcTarget.All, new object[] { player, addAmount });
    }
    [PunRPC]
    public void Scoreincrement(Player player, int addAmount)
    {
        //int temp = (int)player.CustomProperties["score"];
        //Hashtable hash = new Hashtable();
        //hash.Add("score", temp + addAmount);
        //player.CustomProperties = hash;
        int temp = (int)ScoreList[player];
        ScoreList[player] = temp + addAmount;


    }




}
