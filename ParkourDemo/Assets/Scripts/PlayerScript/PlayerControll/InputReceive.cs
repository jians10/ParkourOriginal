using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parkour

{
    public class InputReceive : MonoBehaviour
    {

        //Parameters
        protected const float RotationSpeed = 10;
        public Transform orientation;

        PlayerControllerTest Player;
        // Use this for initialization
        void Start()
        {
            Player = GetComponent<PlayerControllerTest>();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {           //set player values
            Vector3 neoRunX = (orientation.transform.forward * Input.GetAxisRaw("Vertical"));
            Vector3 neoRunZ = (orientation.transform.right * Input.GetAxisRaw("Horizontal"));
            Vector3 SpeedDirection = neoRunX + neoRunZ;
            Player.Input.RunX = SpeedDirection.x;
            Player.Input.RunZ = SpeedDirection.z;
            Player.Input.LookH = Input.GetAxisRaw("Mouse X");
            Player.Input.LookV = Input.GetAxisRaw("Mouse Y");
            Player.Input.Jump = Input.GetButton("Jump");
            Player.Input.Jet = Input.GetKey(KeyCode.Tab);
            Player.Input.Slide = Input.GetKey(KeyCode.CapsLock);
            Player.Input.Grab = Input.GetKey(KeyCode.G);
            Player.Input.Dash = Input.GetKey(KeyCode.LeftShift);
            Player.Input.PullUp = Input.GetKey(KeyCode.W);
            Player.Input.PullDown = Input.GetKey(KeyCode.S);
            Player.Input.PickUp = Input.GetKey(KeyCode.E);
            Player.Input.Charging = Input.GetMouseButton(0);
            Player.Input.Throw = Input.GetMouseButtonUp(0);
            Player.Input.LiftDirection = Input.GetAxisRaw("Vertical");

        }
        private void Update()
        {
            
        }
    }
}