using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine.UI;

public class MazeGameManager : GameManager
{
    public static MazeGameManager instance;
    // Start is called before the first frame update
    public int MutantPlayerCount = 0;
    public Text MutantCounter;
    public Text RunnerCounter;
    public GameObject QuitGameR=null;
    public GameObject QuitGameM=null;


    private new void Awake()
    {
        instance = this;
        base.Awake();
    }
    // Update is called once per frame
    void Update()
    {
        MutantCounter.text = "Mutant__"+MutantPlayerCount;
        RunnerCounter.text = "Runner__" +(currentPlayerLeft()-MutantPlayerCount);
    }
    int currentPlayerLeft() {

        if (PhotonNetwork.CurrentRoom != null)
        {
            return PhotonNetwork.CurrentRoom.PlayerCount;
        }
        else {
            return 0;
        }
       
    }

    public void IncreaseMutantCount() {
        PV.RPC("IncreaseMutantCountPun", RpcTarget.All, new object[] {  });
    }

    [PunRPC]
    void IncreaseMutantCountPun() {
        MutantPlayerCount = MutantPlayerCount + 1;
        if (MutantPlayerCount == currentPlayerLeft()) {
            EndGame();
        }
    }
    public void EndGame() {

        if (currentPlayerLeft() - MutantPlayerCount == 0)
        {
            QuitGameM.SetActive(true);
        }
        else
        {
            QuitGameR.SetActive(true);
        }
    }
    
}
