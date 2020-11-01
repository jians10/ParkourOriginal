using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parkour
{
    public class Hanging : MonoBehaviour
    {
        // Start is called before the first frame update
        public PlayerControllerTest MainController;
        Rigidbody rb;
        public bool grabbing;
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rb == null) {
                return;
            }
            Debug.Log("activate");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (rb == null) {
                return;
            }
            Debug.Log("grabbing");
            if (other.gameObject.tag == "Edge")
            {
                grabbing = true;
                MainController.AbletoGrab = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (rb == null) {
                return;
            }
            if (other.gameObject.tag == "Edge") {

                MainController.AbletoGrab = false;
                grabbing = false;
            
            }
        }


    }
}
