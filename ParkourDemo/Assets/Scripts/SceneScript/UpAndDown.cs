using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Parkour;

public class UpAndDown : MonoBehaviour
{

    // Start is called before the first frame update
    float Yvalue;
    public float MoveDistance;
    public float speed = 2.5f;
    private PhotonView Pv;
    private Vector3 StartPoint;
    private Vector3 Destination;
    private bool up;
    void Start()
    {
        up = true;
        Yvalue = transform.position.y;
        Pv = GetComponent<PhotonView>();
        StartPoint = transform.position;
        Destination = new Vector3(transform.position.x, transform.position.y + MoveDistance, transform.position.z);
        
    }

    //adjust this to change speed
    

    void Update()
    {
        if (!Pv.IsMine) {

            return;
        }

        transform.position=new Vector3(transform.position.x, Yvalue + Mathf.PingPong(Time.time * speed, MoveDistance), transform.position.z);
        

    }


    // only an test code of photon rpc, still need to change. 

    private void Move()
    {
        int ViewID = Pv.ViewID;
        Pv.RPC("MoveUpandDown", RpcTarget.All, new object[] { Pv.ViewID });
    }



    [PunRPC]
    void MoveUpandDown( int ViewID)
    {
        GameObject platform = PhotonView.Find(ViewID).gameObject;
        if (up)
        {
            
            platform.transform.position = Vector3.Lerp(transform.position, Destination, 2 * Time.deltaTime);
            //new Vector3(transform.position.x, Yvalue + Mathf.PingPong(Time.time * speed, MoveDistance), transform.position.z);
            if (platform.transform.position.y - StartPoint.y > MoveDistance - 0.5) {
                up = false;
            }
        }
        else {

            platform.transform.position = Vector3.Lerp(transform.position, StartPoint, 2 * Time.deltaTime);
            if (platform.transform.position.y - StartPoint.y < 0.5)
            {
                up = true;
            }
        }
    }



    [PunRPC]
    void Belong(int ViewID, int PlatformID)
    {
        GameObject player = PhotonView.Find(ViewID).gameObject;
        GameObject Platform = PhotonView.Find(PlatformID).gameObject;
        player.gameObject.transform.parent = Platform.transform;
    }


    [PunRPC]
    void Gone(int ViewID)
    {
        GameObject player = PhotonView.Find(ViewID).gameObject;
        player.gameObject.transform.parent = null;
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Mutant") {

            if (collision.rigidbody != null) {

               int ViewID= collision.gameObject.GetComponent<PlayerControllerTest>().photonView.ViewID;
               Pv.RPC("Belong", RpcTarget.All, new object[] { ViewID, Pv.ViewID });

            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Mutant")
        {

            if (collision.rigidbody != null)
            {

                int ViewID = collision.gameObject.GetComponent<PlayerControllerTest>().photonView.ViewID;
                Pv.RPC("Gone", RpcTarget.All, new object[] { ViewID });

            }
        }
    }
}
