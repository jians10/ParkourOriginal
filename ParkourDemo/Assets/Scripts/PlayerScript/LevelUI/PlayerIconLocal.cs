using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconLocal : MonoBehaviour
{
    // Start is called before the first frame update
    // public RectTransform playerInMap;
    private RectTransform map2dEnd;
    private Transform map3dParent;
    private Transform map3dEnd;
    private Vector3 normalized, mapped;
    private GameObject player;
    private Transform MapImage = null;


    void Awake()
    {
        map2dEnd = GameObject.Find("MapEnd2D").GetComponent<RectTransform>();
        map3dParent = GameObject.Find("MapCenter3D").GetComponent<Transform>();
        map3dEnd = GameObject.Find("MapEnd3D").GetComponent<Transform>();
        MapImage = GameObject.Find("MapImage").transform;
        this.transform.parent = MapImage;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Called Icon 3");
        if (player == null) {
            return;
        }
        Debug.Log("Called Icon 4");
        Debug.Log(player.GetComponent<PhotonView>().ViewID);
        normalized = Divide(
            new Vector3(player.transform.position.x - map3dParent.position.x,
                        0,
                        player.transform.position.z - map3dParent.position.z),
            map3dEnd.position - map3dParent.position
        ); 
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        transform.localPosition = mapped;
    }
    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
    public void setPlayer(GameObject target)
    {

        player = target;

    }
}
