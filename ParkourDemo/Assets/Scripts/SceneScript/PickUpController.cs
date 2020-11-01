using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Parkour
{
    public class PickUpController : MonoBehaviourPun, IPunOwnershipCallbacks
    {
        private PhotonView PV;
        public bool IsAttached = false;
        public int Photon_View_Id;
        public PlayerControllerTest Player;

        private void Awake()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDestroy()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }
        private void Start()
        {
            PV = GetComponent<PhotonView>();
            Photon_View_Id = PV.ViewID;
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            if (targetView != base.photonView)
                return;
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
            if (targetView != base.photonView)
                return;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (IsAttached)
            {
                if (collision.gameObject.tag != "Player")
                {
                    if (Player != null)
                    {
                        Player.DropObject();
                    }
                }
            }
        }
    }
}