using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Parkour
{

    public class Lava : MonoBehaviour
    {
        // Start is called before the first frame updat

        //public RevivePoint[] RevivePoints;
        public Transform StartPoint;
        PhotonView PV;
        void Awake()
        {
            PV = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameObject target = other.gameObject;
                InputReceive IR = target.GetComponent<InputReceive>();
               
                if (IR != null)
                {
                    //Vector3 RevivePoint = CalculateDistance(target.transform.position);
                    Vector3 RevivePoint = RaceGameManager.instance.getRevivePosition();
                    int ItemID = target.GetComponent<PhotonView>().ViewID;
                    Debug.Log(ItemID);
                    PV.RPC("Revive", RpcTarget.All, new object[] { ItemID, RevivePoint });
                }

            }
        }

        //private Vector3 CalculateDistance(Vector3 PlayerPosition) {
        //    Vector3 RestartPoint = StartPoint.position;
        //    float MaxIndex = 0;
        //    foreach (RevivePoint revivePoint in RevivePoints) {
        //        if (revivePoint.Activated&&revivePoint.index > MaxIndex) {
        //            MaxIndex = revivePoint.index;
        //            RestartPoint = revivePoint.RevivePosition.position;
        //        }
        //    }
        //    return RestartPoint;
        //}


        [PunRPC]
        void Revive(int ItemID,Vector3 RevivePoint)
        {
            Debug.Log("teleport");
            GameObject Player = PhotonView.Find(ItemID).gameObject;
            Player.transform.position = RevivePoint;
        }
    }
}
