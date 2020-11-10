using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    bool startTimer = false;
    double timerIncrementValue;
    double startTime;
    double timeLeft;
    [SerializeField]public float timerValue = 180f;
    ExitGames.Client.Photon.Hashtable CustomeValue;
    public Text Clock;
    private PhotonView PV;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            PV.RPC("StartTimer", RpcTarget.AllBuffered, new object[] { startTime, true });
        }
       

    }

    void Update()
    {
        //Debug.LogError(startTimer);
        if (!startTimer) return;
        timerIncrementValue = PhotonNetwork.Time - startTime;
        timeLeft= timerValue- Mathf.Ceil((float)(timerIncrementValue));
        Clock.text = (int)timeLeft + "s";
        if (timeLeft<=0)
        {
            MazeGameManager.instance.EndGame();
        }
    }

    [PunRPC]
    void StartTimer(double BeginTime, bool start)
    {
        startTime = BeginTime;
        startTimer = start;
    }

}
