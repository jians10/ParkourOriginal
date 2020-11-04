using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerIcon : MonoBehaviour
{
    // Start is called before the first frame update
    //public RectTransform playerInMap;
    private RectTransform map2dEnd;
    private Transform map3dParent;
    private Transform map3dEnd;
    private Vector3 normalized, mapped;
    private GameObject player = null;
    //private PhotonView PV;

    void Awake()
    {
        map2dEnd = GameObject.Find("MapEnd2D").GetComponent<RectTransform>();
        map3dParent = GameObject.Find("MapCenter3D").GetComponent<Transform>();
        map3dEnd = GameObject.Find("MapEnd3D").GetComponent<Transform>();
        //PV = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            return;
        }
        //player = GameObject.FindWithTag("Player");
        //player.transform.position - map3dParent.position
        normalized = Divide(new Vector3(player.transform.position.x - map3dParent.position.x,
                        0,
                        player.transform.position.z - map3dParent.position.z)
            ,
            map3dEnd.position - map3dParent.position
        );
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        this.transform.localPosition = mapped;
    }
    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
    public void setPlayer(GameObject target){

        player = target;

    }
}
