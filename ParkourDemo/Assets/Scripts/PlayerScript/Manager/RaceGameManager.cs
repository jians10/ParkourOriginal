using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace Parkour {

    public class RaceGameManager : GameManager
    {
        // Start is called before the first frame update
        public RevivePoint Revive=null;
        public static RaceGameManager instance;
        [SerializeField] GameObject roomListItemPrefab;
        public Transform ScoreBoardContent;
        private TimerScript1 timeCounter;
        public GameObject EndGamePanel = null;
        private new void Awake() {
            instance = this;
            timeCounter = GetComponent<TimerScript1>();
            base.Awake();
            foreach (var player in PhotonNetwork.PlayerList)
            {
                //PlayerScoreList.Add(player.NickName, 0);
                ScoreList.Add(player, 0);
                Instantiate(roomListItemPrefab, ScoreBoardContent).GetComponent<ScoreBoardItem>().SetUp(player);
            }
        }
        public override void ReadyToPlay()
        {
            base.ReadyToPlay();
            timeCounter.StartCount();
        }
        // Update is called once per frame
        public void setRevive(RevivePoint target) {
            Revive = target;
        }
        public float CurrentRevivePointIndex() {
            if (Revive == null)
            {
                return 0;
            }
            else {

                return Revive.index;
            }
        }
        public Vector3 getRevivePosition()
        {
           return Revive.RevivePosition.position;
            
        }
        public void ReachEndPoint(Player player)
        {
            PV.RPC("ReachEnd", RpcTarget.All, new object[] { player });
            EndGame();
        }
        [PunRPC]
        public void ReachEnd(Player player)
        {
            int addAmount = (int)(100 * (timeCounter.timeLeft) / timeCounter.timerValue);
            int temp = (int)ScoreList[player];
            ScoreList[player] = temp + addAmount;
        }


        public void EndGame()
        {
            
            EndGamePanel.SetActive(true);
            int order = CalculateOrder();
            EndGamePanel.GetComponent<ShowResult>().setResult(order);
        }

        public int CalculateOrder() {
            int order = 1;
            int currentScore = (int)ScoreList[PhotonNetwork.LocalPlayer];
            foreach (var player in PhotonNetwork.PlayerList)
            {
                if ((int)(ScoreList[player]) > currentScore) {
                    order++;
                }
            }
            return order;
        }




    }

}