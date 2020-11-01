using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item Picked Up");
            Destroy(gameObject);
        }
    }
}
