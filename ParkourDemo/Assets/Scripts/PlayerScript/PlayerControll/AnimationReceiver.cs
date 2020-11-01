using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parkour {
    public class AnimationReceiver : MonoBehaviour
    {
        // Start is called before the first frame update

        public PlayerControllerTest Controller;

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void StartJump() {
            Controller.StartJump();
            //Debug.Log("jUMP");
        }

        void FixPullUp() {

            Controller.FixPullUp();
        
        }

        void TeleportPlayer() {

            Controller.TeleportPlayer();
        
        }
       
        void FinishPullUp()
        {

            Controller.FinishPullUp();

        }

    }

}