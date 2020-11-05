using Parkour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;
using System.IO;

public class Trap : MonoBehaviour
{
    private MutantControllerTest mutant;
    protected PhotonView PV;
    protected PlayerControllerTest Player = null;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Awake()
    {
        mutant = null;
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 13)
        {
            mutant = collider.gameObject.GetComponent<MutantControllerTest>();
            triggerTrap();
           
            //Path.Combine("PhotonPrefabs", "ExplosionEffect")
        }
    }


    public void triggerTrap()
    {
        if (mutant != null)
        {
            PV.RPC("OnHit", RpcTarget.AllBufferedViaServer, new object[] { mutant.PV.ViewID });
        }
    }

    [PunRPC]
    protected void OnHit(int PlayerID)
    {

        Debug.Log("PicKuP");
        MutantControllerTest player = PhotonView.Find(PlayerID).gameObject.GetComponent<MutantControllerTest>();
        player.Paralyze = true;
        player.State = PlayerControllerTest.PlayerState.Paralyze;
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    




}
