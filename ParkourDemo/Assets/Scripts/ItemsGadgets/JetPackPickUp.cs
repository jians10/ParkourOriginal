using Parkour;
using UnityEngine;
using Photon.Pun;

public class JetPackPickUp : PickUp
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

        JetPack Playerjet = PhotonView.Find(PlayerID).gameObject.GetComponent<JetPack>();

        Playerjet.JetActivate = true;

        
        Destroy(gameObject);
    
    
    }

}
