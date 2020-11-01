using Photon.Pun;
using UnityEngine;

namespace Parkour
{
    public class PickUp : MonoBehaviour
    {
        // Start is called before the first frame update

        public bool CanBePickUp=true;
        protected PhotonView PV;
        protected PlayerControllerTest Player=null;
        public void Awake()
        {
            PV = GetComponent<PhotonView>();
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                Player = collider.gameObject.GetComponent<PlayerControllerTest>();
                if (CanBePickUp&&Player!=null)
                {
                    Debug.Log("I'm not null");
                    PickUpObject();
                    print("Item Picked Up");
                }
               
                //Destroy(gameObject);
            }
        }

        public virtual void PickUpObject() {
            return;
        //comment This is the parent class that used generate different gadgets.
        }

    }
}
