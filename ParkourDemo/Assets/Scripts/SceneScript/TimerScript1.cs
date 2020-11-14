using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace Parkour
{
    public class TimerScript1 : MonoBehaviour
    {
        bool startTimer = false;
        double timerIncrementValue;
        double startTime;
        public double timeLeft;
        [SerializeField] public float timerValue = 10f;


        public Text Clock;
        private PhotonView PV;
        void Awake()
        {
            timeLeft = timerValue;
            PV = GetComponent<PhotonView>();
        }


        public void StartCount()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                // CustomeValue = new ExitGames.Client.Photon.Hashtable();
                startTime = PhotonNetwork.Time;
                PV.RPC("StartTimer", RpcTarget.AllBuffered, new object[] { startTime, true });
            }
        }

        void Update()
        {
            //Debug.LogError(startTimer);
            if (!startTimer) return;
            timerIncrementValue = PhotonNetwork.Time - startTime;
            timeLeft = timerValue - Mathf.Ceil((float)(timerIncrementValue));
            Clock.text = (int)timeLeft + "s";
            if (timeLeft <= 0)
            {
                RaceGameManager.instance.EndGame();
            }
        }

        [PunRPC]
        void StartTimer(double BeginTime, bool start)
        {
            startTime = BeginTime;
            startTimer = start;
        }

    }
}
