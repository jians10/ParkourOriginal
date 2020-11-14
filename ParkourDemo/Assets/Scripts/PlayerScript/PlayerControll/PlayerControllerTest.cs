//using System;
//using System.Collections;
//using System.Runtime.CompilerServices;
using Photon.Pun;
//using Photon.Pun.UtilityScripts;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.UI;
//using UnityEngine.UIElements;

namespace Parkour
{
    public class PlayerControllerTest : MonoBehaviourPunCallbacks
    {
        [HideInInspector]
        public InputStr Input;
        public struct InputStr
        {
            public float LookH;
            public float LookV;
            public float RunX;
            public float RunZ;
            public bool Jump;
            public bool Sprint;
            //public bool WallRun;
            public bool Dash;
            public bool Jet;
            public bool Slide;
            public bool Grab;
            public bool PullUp;
            public bool PullDown;
            public bool PickUp;
            public bool Throw;
            public bool Charging;
            public float LiftDirection;
            public float ClimbUp;
            public bool Climb;
        }
        public enum PlayerState
        {
            NORMAL,
           // WallRunning,
            Dash,
            Mutant,
            Sonic,
            Hanging,
            Trans,
            Lifting,
            Climbing,
            Vaulting,
            Paralyze
        }
        //This will be useful in future
        public enum AirState
        {
            Flying,
            Jumping,
            Ground
        }


        public Transform orientation;

        [SerializeField]protected GameObject cameraHolder;
        [SerializeField]protected float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
        public InputReceive Controller;
        protected float verticalLookRotation;
        public float MaxSpeed = 7f;
        public const float SpeedValue = 7f;
        public const float acc = 3f;
        [HideInInspector]
        public PlayerState State = PlayerState.NORMAL;
        public AirState air = AirState.Ground;

        public float GroundDetectRadius = 0.3f;
        protected Rigidbody Rigidbody;
        protected CapsuleCollider MainCollider;
        protected Animator CharacterAnimator;
        // neo in this project
        public Vector3 moveDirection;
        public float moveDirectionUp;
        public float Rotation;
        public float CurrentSpeed;
        //protected WallRunMovement wallrun;
        public bool Grounded = true;
        public float currentCoolDown;
        public float TotalTime;
        // parameter related to Dash
        public float dashForce;
        public bool Dashcooldown = true;
        public bool EndDash = true;
        public float DashdurationTime = 1f;
        //parameter related to Sonic
        public float SonicdurationTime = 10f;
        public bool EndSonic = true;
        public bool AbleToSlide = false;
        protected float tempVelocity;
        //ParticleSystem Related to the speed
        public ParticleSystem SpeedEffect;
        public ParticleSystem FlashEffect;
        public PhotonView PV;
        //Do we have anythign to grab
        public bool Grab;
        public bool AbletoGrab;
        public bool UpTheWall;
        public float RayDistance;
        public float forward;
        public float up;
        // This all of this are variable that gonna be used in the pickup and throw 
        public float PickupDistance;
        public bool carryObject;
        public bool IsThrowable;
        public GameObject Item;
        public PickUpController PickCon;
        public Transform ObjectHolder;
        public bool DetectObject;
        public float PickupY;
        public float MinForce = 100;
        public float PushForce = 0;
        public float MaxForce = 1000;
        public bool Charged;
        protected float DistanceX;
        protected float DistanceY;
        protected float DistanceZ;
        protected GameObject Edge;
        protected Vector3 GrabOffset;
        // This are all parameter related to Climbing
        public bool AbleToClimb;
        public bool Climb;
        protected GameObject Ladder;
        protected Vector3 ClimbOffset;
        protected float ClimbSpeed = 0.3f;

        //All of this is related to Vaulting

        public bool AbleToVault;
        public bool Vault;
        protected GameObject VaultObject;
        protected Vector3 VaultOffset;
        public GameObject PlayerIcon=null;





        protected void Awake()
        {
            // wallrun = GetComponent<WallRunMovement>();
            Controller=GetComponent<InputReceive>();
            Rigidbody = GetComponent<Rigidbody>();
            CharacterAnimator = GetComponentInChildren<Animator>();
            MainCollider = GetComponent<CapsuleCollider>();
            PV = GetComponent<PhotonView>();
        }

        protected void Start()
        {
            if (Controller == null)
                return;
            if (photonView.IsMine) {
                if (PlayerIcon != null)
                {
                    PlayerIcon.GetComponent<PlayerIcon>().ChangeColor();
                }
            }
           
        }

        protected void Update()
        {
            // if (photonView.IsMine)
            //     return
            //Debug.Log(Input.Jet);
            if (Controller == null) {
                CurrentSpeed = Rigidbody.velocity.magnitude;
                Rotation = Vector3.SignedAngle(transform.forward, moveDirection, Vector3.up);
                CharacterAnimator.SetFloat("Rotation", Rotation);
                CharacterAnimator.SetFloat("Speed", CurrentSpeed);
                return;
            }
                
            SpeedLine();
            FlashLine();
            // do not use this any more 
            CharacterAnimator.SetBool("Grounded", Grounded);
            //var localVelocity = Quaternion.Inverse(transform.rotation) * (Rigidbody.velocity / MaxSpeed);
            AbleToSlide = (State == PlayerState.NORMAL || State == PlayerState.Sonic) && Grounded && CurrentSpeed > 6;
            moveDirection = Rigidbody.velocity;
            moveDirectionUp = Rigidbody.velocity.y;
            Rotation = Vector3.SignedAngle(transform.forward, moveDirection, Vector3.up);
            CharacterAnimator.SetFloat("Rotation", Rotation);
            CharacterAnimator.SetFloat("Speed", CurrentSpeed);
            CharacterAnimator.SetBool("Dash", State == PlayerState.Dash);
           // CharacterAnimator.SetBool("IsWallRunning", wallrun.isWallRunning);
            CharacterAnimator.SetBool("Slide", Input.Slide);
            CharacterAnimator.SetBool("Jump", Input.Jump);
            CharacterAnimator.SetBool("flying", Input.Jet);
            CharacterAnimator.SetBool("Grab", Grab);
            CharacterAnimator.SetBool("UpTheWall", UpTheWall);
            CharacterAnimator.SetBool("DownTheWall", Input.PullDown);
            CharacterAnimator.SetBool("CarryingObject", State == PlayerState.Lifting);
            CharacterAnimator.SetFloat("ClimbUp", Input.ClimbUp);
            CharacterAnimator.SetBool("Climb", Climb);
            CharacterAnimator.SetBool("ClimbQuit", Input.Jump);
            CharacterAnimator.SetBool("Vaulting", Vault);
            CharacterAnimator.SetFloat("MoveDirectionUp", moveDirectionUp);
            
        }





        protected void FixedUpdate()
        {
            if (Controller == null)
                return;
            if (Rigidbody == null)
                return;
            //Rigidbody.useGravity = State != PlayerState.Hanging;
            
            switch (State)
            {
               
                case PlayerState.Sonic:
                    SonicCounter();
                    Look();
                    Dash();
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    MaxSpeed = SpeedValue * 2;
                    NeoMove();
                    Hanging();
                    Slide();
                    Climbing();
                    Vaulting();
                    break;

                case PlayerState.NORMAL:
                    Look();
                    Dash();
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    MaxSpeed = SpeedValue;
                    NeoMove();
                    Hanging();
                    PickUp();
                    Slide();
                    Climbing();
                    Vaulting();
                    break;

                case PlayerState.Dash:
                    Dashing();
                    break;
                case PlayerState.Hanging:
                    AbletoGrab = false;
                    HangingStable();
                    Rigidbody.velocity = Vector3.zero;
                    CurrentSpeed = 0;
                    PullUp();
                    PullDown();
                    break;
                case PlayerState.Lifting:
                    Throw();
                    MaxSpeed = SpeedValue / 2;
                    NeoMove();
                    CheckCarrying();
                    Look();
                    if (Item != null)
                    {
                        Item.gameObject.transform.localPosition = new Vector3(DistanceX, DistanceY, DistanceZ);
                    }
                    break;
                case PlayerState.Climbing:
                    Grounded = Physics.OverlapBox(transform.position, new Vector3(0.2f, 0.2f, 0.2f)).Length > 1;
                    Rigidbody.velocity = Vector3.zero;
                    CurrentSpeed = 0;
                    ClimbUp();
                    ClimbQuit();
                    ClimbingUp();
                    cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, -3), 5f * Time.deltaTime);
                    verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
                    cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
                    break;
                case PlayerState.Mutant:
                    break;

            }


            Rigidbody.useGravity = State == PlayerState.NORMAL || State == PlayerState.Sonic || State == PlayerState.Lifting;
            MainCollider.enabled = State == PlayerState.NORMAL || State == PlayerState.Dash || State == PlayerState.Sonic || State == PlayerState.Lifting||State == PlayerState.Vaulting;
            //Rigidbody.MovePosition(Rigidbody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }

        protected void LateUpdate()
        {
            CharacterAnimator.transform.localPosition = Vector3.zero;
            CharacterAnimator.transform.localRotation = Quaternion.identity;
        }

        protected void Look()
        {
            if (!(AbleToSlide && Input.Slide))
            {
                transform.Rotate(Vector3.up * Input.LookH * mouseSensitivity);
                cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, 0), 5f * Time.deltaTime);
            }
            if ((AbleToSlide && Input.Slide))
            {
                cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 0.8f, 0), 5f * Time.deltaTime);

            }
            if ((State == PlayerState.Lifting))
            {
                cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 3f, -2), 5f * Time.deltaTime);

            }
            verticalLookRotation += Input.LookV * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;


        }

        public void StartJump()
        {
            if (Grounded)
            {
                if (Rigidbody != null)
                {
                    Rigidbody.AddForce(transform.up * jumpForce);
                }
            }
        }
        public void CheckAirState()
        {

            if (Grounded)
            {
                air = AirState.Ground;
            }
            else if (Input.Jet)
            {

                air = AirState.Flying;
            }
            else
            {

                air = AirState.Jumping;

            }


        }


        protected void NeoMove()
        {
            //Apply forces to move player

            var inputRun = Vector3.ClampMagnitude(new Vector3(Input.RunX, 0, Input.RunZ), 1);

            if ((Input.RunX != 0 || Input.RunZ != 0))
            {

                if (CurrentSpeed < MaxSpeed)
                {
                    if (CurrentSpeed > MaxSpeed - 0.05f)
                    {

                        CurrentSpeed = MaxSpeed;
                    }
                    else
                    {
                        CurrentSpeed += Time.deltaTime * acc;
                    }
                }
                else
                {
                    CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed, 2 * Time.deltaTime);
                }

                Rigidbody.velocity = new Vector3(inputRun.x * CurrentSpeed, Rigidbody.velocity.y, inputRun.z * CurrentSpeed);
            }
            //This is the script we use to main

            if (Input.RunX == 0 && Input.RunZ == 0)
            {

                Vector3 direction = Rigidbody.velocity.normalized;

                CurrentSpeed = Mathf.Lerp(CurrentSpeed, 0, 2 * Time.deltaTime);



                Rigidbody.velocity = new Vector3(direction.x * CurrentSpeed, Rigidbody.velocity.y, direction.z * CurrentSpeed);

            }

        }

        // This is to separate the basic movement and special skills










        //PickUp
        protected void PickUp()
        {

            if (Input.PickUp && Grounded)
            {
                Debug.Log("StartToCheck");
                RaycastHit hit;
                Ray directionRay = new Ray(transform.position + transform.up * PickupY, transform.forward);
                DetectObject = Physics.Raycast(directionRay, out hit, PickupDistance);
                if (Physics.Raycast(directionRay, out hit, PickupDistance))
                {
                    Debug.Log("HasSomethingToPick");
                    if (hit.collider.tag == "PickAbleObject")
                    {
                        Item = hit.collider.gameObject;
                        PickCon = Item.GetComponent<PickUpController>();
                        if (!PickCon.IsAttached)
                        {
                            Debug.Log("pickItuP");
                            PickCon.photonView.RequestOwnership();
                            PickCon.Player = this;
                            RaycastHit TestUnderbound;
                            Ray downRay = new Ray(Item.transform.position, -Vector3.up);
                            Physics.Raycast(downRay, out TestUnderbound);
                            float LowerBound = TestUnderbound.distance;
                            float RiseDistance = ObjectHolder.transform.localPosition.y;
                            // Use the PunRPC to set the object's position to the position we what 
                            int ItemID = Item.GetComponent<PhotonView>().ViewID;
                            int ViewID = PV.ViewID;
                            PV.RPC("RiseTheObject", RpcTarget.All, new object[] { ItemID, ViewID, RiseDistance + LowerBound });
                            State = PlayerState.Lifting;

                        }
                    }
                }
            }
        }
        [PunRPC]
        protected void RiseTheObject(int ItemID, int ViewID, float LocalDistanceY)
        {
            Item = PhotonView.Find(ItemID).gameObject;
            PickUpController PickCon = Item.GetComponent<PickUpController>();
            Physics.IgnoreCollision(Item.GetComponent<Collider>(), PhotonView.Find(ViewID).gameObject.GetComponent<Collider>(), true);
            if (carryObject = false && !PickCon.IsAttached)
            {
                PickCon.photonView.TransferOwnership(ViewID);
            }
            Item.transform.SetParent(transform);
            Item.gameObject.transform.localPosition = new Vector3(Item.gameObject.transform.localPosition.x, LocalDistanceY, Item.gameObject.transform.localPosition.z);
            DistanceY = Item.gameObject.transform.localPosition.y;
            DistanceX = Item.gameObject.transform.localPosition.x;
            DistanceZ = Item.gameObject.transform.localPosition.z;
            Rigidbody ItemRB = Item.GetComponent<Rigidbody>();
            ItemRB.constraints = RigidbodyConstraints.FreezeRotation;
            ItemRB.useGravity = false;
            PickCon.IsAttached = true;
            carryObject = true;
            IsThrowable = true;
        }


        [PunRPC]
        protected void ThrowObjectAway(int ItemID, float PushForce, Vector3 pushDirection)
        {
            Item = PhotonView.Find(ItemID).gameObject;
            PickUpController PickCon = Item.GetComponent<PickUpController>();
            PickCon.photonView.TransferOwnership(PickCon.Photon_View_Id);
            PickCon.IsAttached = false;
            Item.transform.parent = null;
            Physics.IgnoreCollision(Item.GetComponent<Collider>(), MainCollider, false);
            Rigidbody ItemRB = Item.GetComponent<Rigidbody>();
            ItemRB.constraints = RigidbodyConstraints.None;
            ItemRB.useGravity = true;
            Item.GetComponent<Rigidbody>().AddForce(pushDirection * PushForce);
            Item = null;
            IsThrowable = false;
            carryObject = false;
        }


        protected void Slide()
        {

            if (Input.Slide)
            {

                PV.RPC("Squat", RpcTarget.All, new object[] { });

            }
            else
            {

                PV.RPC("Stand", RpcTarget.All, new object[] { });

            }
        }

        [PunRPC]
        protected void Squat()
        {
            Debug.Log("Squat");
            MainCollider.center = new Vector3(0, 0.433f, 0);
            MainCollider.height = 1;

        }

        [PunRPC]
        protected void Stand()
        {
            MainCollider.center = new Vector3(0, 0.866f, 0);
            MainCollider.height = 1.9f;
        }



        protected void Throw()
        {
            Debug.Log("Called");
            if (!carryObject || !IsThrowable)
            {
                return;
            }
            if (Input.Charging)
            {
                Charged = true;
                Debug.Log("Charging");
                if (PushForce < MaxForce)
                {
                    PushForce = PushForce + ((MaxForce - MinForce) / 5) * Time.deltaTime;
                }
            }
            if (Charged && !Input.Charging)
            {
                Debug.Log("Throw");
                if (IsThrowable)
                {
                    //Item.transform.parent = null;
                    int ItemID = Item.GetComponent<PhotonView>().ViewID;
                    PV.RPC("ThrowObjectAway", RpcTarget.All, new object[] { ItemID, PushForce, transform.forward });
                    PushForce = MinForce;
                    Charged = false;
                    PickCon.Player = null;
                    PickCon = null;
                }
            }
        }


        public void DropObject()
        {

            if (!carryObject || !IsThrowable)
            {
                return;
            }
            if (IsThrowable)
            {
                //Item.transform.parent = null;
                int ItemID = Item.GetComponent<PhotonView>().ViewID;
                PV.RPC("ThrowObjectAway", RpcTarget.All, new object[] { ItemID, 30f, transform.forward + transform.up });
                PushForce = MinForce;
                Charged = false;
            }
        }




        protected void CheckCarrying()
        {
            if (carryObject == false && Item == null)
            {
                State = PlayerState.NORMAL;
                carryObject = false;
                Item = null;
            }
        }

        //special movement vaulting
        //Check Vaulting

        protected void Vaulting()
        {
            if (!Grounded)
            {
                return;
            }

            Vector3 DetectCenter = transform.position + transform.forward * 0.5f + transform.up * 0.6f;
            Vector3 DetectSize = new Vector3(0.8f, 1f, 0.6f);
            Collider[] VaultObjects = Physics.OverlapBox(DetectCenter, DetectSize, transform.rotation, 1 << 11);
            AbleToVault = VaultObjects.Length >= 1;
            if (AbleToVault)
            {
                VaultObject = VaultObjects[0].gameObject;
            }

            Vault = AbleToVault && Input.Grab;
            if (Vault)
            {

                Vector3 Direction = VaultObject.transform.position - transform.position;
                Vector3 Offset = Vector3.Project(Direction, VaultObject.transform.right);
                //transform.rotation = VaultObject.transform.rotation;
                VaultOffset = -Offset;
                State = PlayerState.Vaulting;
            }

        }

        public void FixVaultingUp()
        {
            if (VaultObject != null)
            {
                //transform.position =Vector3.Lerp(transform.position,VaultOffset + VaultObject.transform.position+VaultObject.transform.up*VaultObject.transform.localScale.y,Time.deltaTime);
                transform.position = VaultOffset + VaultObject.transform.position + VaultObject.transform.up * VaultObject.transform.localScale.y;
                cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, -1f), 5f);
            }
        }


        public void FinishVaultingUp()
        {
            print("Finish the PullUp");
            State = PlayerState.NORMAL;
            Vault = false;
            CurrentSpeed = SpeedValue;
            cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, 0), 5f*Time.deltaTime);

        }

        // special movement WallClimbing

        // check wall climbing 
        protected void Climbing()
        {

            Vector3 DetectCenter = transform.position + transform.forward * 0.5f + transform.up * 1.6f;
            Vector3 DetectSize = new Vector3(0.8f, 1f, 0.6f);
            Collider[] Grab = Physics.OverlapBox(DetectCenter, DetectSize, transform.rotation, 1 << 10);
            AbleToClimb = Grab.Length >= 1;
            if (AbleToClimb)
            {
                Ladder = Grab[0].gameObject;
            }
            Climb = AbleToClimb && Input.Climb;
            if (Climb)
            {
                print("Climbing");
                Vector3 Direction = Ladder.transform.position - transform.position;
                Vector3 Offset1 = Vector3.Project(Direction, Ladder.transform.up);
                Vector3 Offset2 = Vector3.Project(Direction, Ladder.transform.right);


                transform.rotation = Ladder.transform.rotation;
                this.transform.position = Ladder.transform.position - Offset1-Offset2 + Ladder.transform.forward * -0.4f;
                ClimbOffset = Ladder.transform.position - Offset1-Offset2 + Ladder.transform.forward * -0.4f;
                Rigidbody.velocity = Vector3.zero;
                State = PlayerState.Climbing;

            }
        }

        protected void ClimbUp()
        {
            if (Input.ClimbUp > 0.2f || Input.ClimbUp < -0.2f)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(ClimbOffset.x, transform.position.y + Input.ClimbUp * ClimbSpeed, ClimbOffset.z), Time.deltaTime * 2.5f);

            }
        }
        protected void ClimbQuit()
        {
            if (Input.Jump)
            {
                Climb = false;
                Ladder = null;
                Grab = false;
                Edge = null;
                State = PlayerState.NORMAL;
            }
        }
        protected void ClimbingUp()
        {
            Vector3 DetectCenter = transform.position + transform.forward * 0.5f + transform.up * 1.6f;
            Vector3 DetectSize = new Vector3(0.8f, 1f, 0.6f);
            Collider[] Grabing = Physics.OverlapBox(DetectCenter, DetectSize, transform.rotation, 1 << 9);
            AbletoGrab = Grabing.Length >= 1;
            if (AbletoGrab)
            {
                Edge = Grabing[0].gameObject;
            }
            Grab = AbletoGrab;
            if (Edge != null && Grab)
            {
                Ladder = null;
                Climb = false;
                Vector3 Direction = Edge.transform.position - transform.position;
                Vector3 Offset = Vector3.Project(Direction, Edge.transform.right);
                transform.rotation = Edge.transform.rotation;
                GrabOffset = Edge.transform.up * -2.3f + Edge.transform.forward * (-0.1f) - Offset;
                this.transform.position = Edge.transform.position + GrabOffset;
                State = PlayerState.Hanging;
            }
        }


        // Special ability Wall hanning 

        protected void Hanging()
        {
            //bool AbletoGrabRight = Physics.Raycast(transform.position + transform.up * up + transform.forward * forward + transform.right * 0.2f, transform.forward, RayDistance);
            //bool AbletoGrabLeft = Physics.Raycast(transform.position + transform.up * up + transform.forward * forward + transform.right * -0.2f, transform.forward, RayDistance);
            Vector3 DetectCenter1 = transform.position + transform.forward * 0.25f + transform.up * 2.4f + transform.right * -0.25f;
            Vector3 DetectCenter2 = transform.position + transform.forward * 0.25f + transform.up * 2.4f + transform.right * 0.25f;
            Vector3 DetectSize = new Vector3(0.2f, 0.3f, 0.25f);
            Collider[] grabLeft = Physics.OverlapBox(DetectCenter1, DetectSize, transform.rotation, 1 << 9);
            Collider[] grabRight = Physics.OverlapBox(DetectCenter2, DetectSize, transform.rotation, 1 << 9);
            bool AbletoGrabRight = grabRight.Length >= 1;
            bool AbletoGrabLeft = grabLeft.Length >= 1;
            AbletoGrab = AbletoGrabRight && AbletoGrabLeft;
            if (AbletoGrab)
            {
                Edge = grabLeft[0].gameObject;
            }
            //AbletoGrab = Physics.OverlapBox(transform.position + transform.up * up + transform.forward * forward, new Vector3(0.5f, 0.1f, 0.1f), transform.rotation).Length > 1;
            Grab = AbletoGrab && Input.Grab;
            if (Grab)
            {
                Vector3 Direction = Edge.transform.position - transform.position;
                Vector3 Offset = Vector3.Project(Direction, Edge.transform.right);
                transform.rotation = Edge.transform.rotation;
                GrabOffset = Edge.transform.up * -2.3f + Edge.transform.forward * (-0.1f) - Offset;
                this.transform.position = Edge.transform.position + GrabOffset;
                State = PlayerState.Hanging;

            }
        }

        protected void HangingStable()
        {

            if (Edge != null && Grab)
            {
                transform.position = Edge.transform.position + GrabOffset;
            }

        }
        protected void PullUp()
        {

            UpTheWall = Input.PullUp;
            if (UpTheWall)
            {
                Grab = false;
            }
        }
        protected void PullDown()
        {
            if (Input.PullDown)
            {
                Grab = false;
                FinishPullUp();
            }
        }
        public void FixPullUp()
        {
            if (Edge != null)
            {
                transform.position = Edge.transform.position + GrabOffset + transform.forward * -0.3f;
            }
            cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 3f, 0), 5f * Time.deltaTime);

        }

        public void TeleportPlayer()
        {
            if (Edge != null)
            {
               Vector3 TargetPosition = Edge.transform.position + GrabOffset + transform.forward * 0.4f + transform.up * 2.3f;
                PV.RPC("UpEdge", RpcTarget.AllBuffered, new object[] { TargetPosition });
            }
        }


        [PunRPC]
        protected void UpEdge(Vector3 TargetPosition)
        {
            transform.position = TargetPosition;

        }


        public void FinishPullUp()
        {

            State = PlayerState.NORMAL;
            CurrentSpeed = 0;
            if (Rigidbody != null)
            {
                Rigidbody.velocity = Vector3.zero;
            }
            cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(0, 1.7f, 0), 5f * Time.deltaTime);

        }

        // specialSkills___WallRun
       // void WallRun()
       // {
       //
       //     if (Input.WallRun)
       //     {
       //         wallrun.ActivateWallRun = true;
       //     }
       //     else
       //     {
       //
       //         wallrun.ActivateWallRun = false;
       //
       //     }
       //     cameraHolder.transform.Rotate(0, 0, wallrun.curCamAngle);

       // }
        //Special Skills__ Dash


        protected void Dash()
        {

            currentCoolDown = currentCoolDown - Time.deltaTime * 2;

            if (currentCoolDown <= 0)
            {
                Dashcooldown = true;
            }
            else
            {

                Dashcooldown = false;
            }


            if (Input.Dash && Dashcooldown)
            {
                tempVelocity = CurrentSpeed;
                currentCoolDown = 4f;
                State = PlayerState.Dash;
            }


        }
        protected void Dashing()
        {

            DashdurationTime = DashdurationTime - Time.deltaTime * 2;

            if (DashdurationTime <= 0)
            {
                EndDash = true;
            }
            else
            {
                EndDash = false;
            }
            CurrentSpeed = MaxSpeed;
            Rigidbody.velocity = orientation.forward * MaxSpeed * 2;

            if (EndDash)
            {

                DashdurationTime = 1f;
                State = PlayerState.NORMAL;
                Rigidbody.velocity = Vector3.zero;
                CurrentSpeed = tempVelocity;
            }

        }

        // draw and show the detector position 
        protected void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(transform.position, new Vector3(0.2f, 0.2f, 0.2f));
            Gizmos.DrawLine(transform.position + transform.up * up + transform.forward * forward + transform.right * 0.2f, transform.position + transform.up * up + transform.forward * forward + transform.right * 0.2f + transform.forward * RayDistance);
            Gizmos.DrawLine(transform.position + transform.up * up + transform.forward * forward + transform.right * -0.2f, transform.position + transform.up * up + transform.forward * forward + transform.right * -0.2f + transform.forward * RayDistance);
            Gizmos.DrawLine(transform.position + transform.up * PickupY, transform.position + transform.up * PickupY + transform.forward * PickupDistance);
        }



        // This is the counter we use to limit the time that we can do sonic running 

       protected  void SonicCounter()
        {

            SonicdurationTime = SonicdurationTime - Time.deltaTime;

            if (SonicdurationTime <= 0)
            {
                EndSonic = true;
            }
            else
            {
                EndSonic = false;
            }

            if (EndSonic)
            {
                SonicdurationTime = 10f;
                State = PlayerState.NORMAL;
                CurrentSpeed = Rigidbody.velocity.magnitude;
            }

        }
        protected void SpeedLine()
        {


            bool FullSpeed = CurrentSpeed > MaxSpeed - 0.5;
            bool FaceForward = Rotation < 15 && Rotation > -15;

            var em = SpeedEffect.emission;
            em.enabled = FullSpeed && FaceForward;

        }
        protected void FlashLine()
        {

            bool FullSpeed = CurrentSpeed > MaxSpeed - 0.5;
            bool FaceForward = Rotation < 15 && Rotation > -15;

            var em2 = FlashEffect.emission;
            em2.enabled = FullSpeed && FaceForward && State == PlayerState.Sonic;

        }
        public void SetIcon(GameObject Icon) {
            PlayerIcon = Icon;
            Icon.GetComponent<PlayerIcon>().setPlayer(this.gameObject);
        }


    }
}