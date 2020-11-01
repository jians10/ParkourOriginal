using Photon.Pun;
using UnityEngine;

namespace Parkour
{

    public class PlayerNetNeo : MonoBehaviourPun
    {

        protected PlayerControllerTest Player;
        protected Vector3 RemotePlayerPosition;
        protected Quaternion RemotePlayerRotation;
        protected float RemoteLookX;
        protected float RemoteLookZ;
        protected float LookXVel;
        protected float LookZVel;
        public GameObject orientation;

        private void Awake()
        {
            Player = GetComponent<PlayerControllerTest>();

            //destroy the controller if the player is not controlled by me
            if (!photonView.IsMine)
            {
                if (GetComponent<InputReceive>() != null)
                {
                    Destroy(GetComponent<InputReceive>());
                }
                Destroy(GetComponentInChildren<Camera>().gameObject);
                Destroy(GetComponentInChildren<Rigidbody>());
                Destroy(orientation.gameObject);
            }
        }
    }
}