using Parkour;
using UnityEngine;
using Photon.Pun;

public class Sonic : PickUp
{
    // Start is called before the first frame update

    public override void PickUpObject()
    {
        if (Player != null) {


            PV.RPC("OnPickUp", RpcTarget.AllBufferedViaServer, new object[] { Player.PV.ViewID });
        }
    }

    [PunRPC]
    protected void OnPickUp(int PlayerID) {

        Debug.Log("PicKuP");

        PlayerControllerTest player = PhotonView.Find(PlayerID).gameObject.GetComponent<PlayerControllerTest>();
        player.State = PlayerControllerTest.PlayerState.Sonic;
        Destroy(gameObject);
    
    
    }

}
