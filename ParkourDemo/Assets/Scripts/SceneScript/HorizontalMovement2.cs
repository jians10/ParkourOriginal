using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Parkour;

public class HorizontalMovement2 : MonoBehaviour
{

    // Start is called before the first frame update
    float Zvalue;
    public float MoveDistance;
    public float speed = 2.5f;
    private PhotonView Pv;
    private Vector3 StartPoint;
    private Vector3 Destination;
    private bool left;
    void Start()
    {
        left = true;
        Zvalue = transform.position.z;
        Pv = GetComponent<PhotonView>();
        StartPoint = transform.position;
        Destination = new Vector3(transform.position.z, transform.position.y, Zvalue + MoveDistance);

    }

    //adjust this to change speed


    void Update()
    {
        if (!Pv.IsMine)
        {

            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, Zvalue + Mathf.PingPong(Time.time * speed, MoveDistance));


    }


    // only an test code of photon rpc, still need to change. 

    private void Move()
    {
        int ViewID = Pv.ViewID;
        Pv.RPC("MoveUpandDown", RpcTarget.All, new object[] { Pv.ViewID });
    }



    [PunRPC]
    void MoveHorizontal(int ViewID)
    {
        GameObject platform = PhotonView.Find(ViewID).gameObject;
        if (left)
        {

            platform.transform.position = Vector3.Lerp(transform.position, Destination, 2 * Time.deltaTime);
            //new Vector3(transform.position.x, Yvalue + Mathf.PingPong(Time.time * speed, MoveDistance), transform.position.z);
            if (platform.transform.position.z - StartPoint.z > MoveDistance - 0.5)
            {
                left = false;
            }
        }
        else
        {

            platform.transform.position = Vector3.Lerp(transform.position, StartPoint, 2 * Time.deltaTime);
            if (platform.transform.position.z - StartPoint.z < 0.5)
            {
                left = true;
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Mutant")
        {

            if (collision.rigidbody != null)
            {

                int ViewID = collision.gameObject.GetComponent<PlayerControllerTest>().photonView.ViewID;
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

