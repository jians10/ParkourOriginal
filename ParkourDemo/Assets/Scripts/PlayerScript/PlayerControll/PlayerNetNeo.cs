using Photon.Pun;
using UnityEngine;

namespace Parkour
{

    public class PlayerNetNeo : MonoBehaviourPun, IPunObservable
    {

        protected PlayerControllerTest Player;
        public GameObject orientation;
        public ParticleSystem SpeedLine;
        public ParticleSystem SprintEffect;
        public Rigidbody _rb;
        public Vector3 velocity; 
        Vector3 _networkPosition;
        Quaternion _networkRotation;
        

        
        
        private void Awake()
        {
            PhotonNetwork.SendRate = 25;
            PhotonNetwork.SerializationRate = 15;

            Player = GetComponent<PlayerControllerTest>();

            //destroy the controller if the player is not controlled by me
            if (!photonView.IsMine)
            {
                if (GetComponent<InputReceive>() != null)
                {
                    Destroy(GetComponent<InputReceive>());
                }
                Destroy(GetComponentInChildren<Camera>().gameObject);
                _rb = GetComponentInChildren<Rigidbody>();
                _rb.useGravity = false;
                Destroy(orientation.gameObject);
                Destroy(SpeedLine);
                Destroy(SprintEffect);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
                stream.SendNext(_rb.velocity);
                stream.SendNext(Player.State);
            }
            else
            {
                _networkPosition = (Vector3)stream.ReceiveNext();
                _networkRotation = (Quaternion)stream.ReceiveNext();
                _rb.velocity = (Vector3)stream.ReceiveNext();
                Player.State = (Parkour.PlayerControllerTest.PlayerState)stream.ReceiveNext();

                float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                _networkPosition += (_rb.velocity * lag);
            }
        }
        public void Update()
        {
            Debug.Log("Send Rate is "+PhotonNetwork.SendRate);
            //Default 20
            Debug.Log("Send RateOS is " +PhotonNetwork.SerializationRate);

            if (!photonView.IsMine)
            {

                var LagDistance = _networkPosition - transform.position;

                if (LagDistance.magnitude > 3* _rb.velocity.magnitude &&LagDistance.magnitude> 3f)
                {
                    transform.position = _networkPosition;
                    LagDistance = Vector3.zero;
                }

                else 
                {
                    transform.position = Vector3.MoveTowards(_rb.position, _networkPosition, Time.fixedDeltaTime);
                    transform.rotation = Quaternion.RotateTowards(_rb.rotation, _networkRotation, Time.fixedDeltaTime * 100.0f);
                }
            }

        }
    }
}