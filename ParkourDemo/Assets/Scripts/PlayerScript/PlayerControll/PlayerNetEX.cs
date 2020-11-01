using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

namespace Parkour
{

    public class PlayerNetEX : MonoBehaviourPun, IPunObservable
    {

        protected PlayerControllerTest Player;
        protected Vector3 RemotePlayerPosition;
        protected float RemoteLookX;
        protected float RemoteLookZ;
        protected float LookXVel;
        protected float LookZVel;
        public GameObject orientation;
        public ParticleSystem SpeedLine;
        public ParticleSystem SprintEffect;

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
                Destroy(SpeedLine);
                Destroy(SprintEffect);
            }
        }

        public void Update()
        {
            if (photonView.IsMine)
                return;

            var LagDistance = RemotePlayerPosition - transform.position;

            //ignore the y distance
            LagDistance.y = 0;

            if (LagDistance.magnitude < 0.11f)
            {
                //Player is nearly at the point
                Player.Input.RunX = 0;
                Player.Input.RunZ = 0;
            }
            else
            {
                //Player has to go to the point
                Player.Input.RunX = LagDistance.normalized.x;
                Player.Input.RunZ = LagDistance.normalized.z;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                RemotePlayerPosition = (Vector3)stream.ReceiveNext();
            }
        }
    }
}