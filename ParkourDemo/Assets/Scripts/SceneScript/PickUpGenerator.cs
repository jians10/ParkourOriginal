using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;
using System.IO;
using Parkour;

public class PickUpGenerator : MonoBehaviour
{

    public enum GeneratorState
    {
        CoolDown,
        Ready,
        Waiting
    }
    private string[] randomItem;
    public float CoolDownTime = 10;
    private float CoolDownTimeLeft = 0f;
    //public ParticleSystem ParticleEffect;
    public float CoolDownSpeed=1;
    public GameObject PickUpItem=null;  
    public GeneratorState currentstate;
    public Transform GeneratePoint;
    private PhotonView pv;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        pv = GetComponent<PhotonView>();
        currentstate =  GeneratorState.Ready;
        randomItem = new string[] { "JetPickUp","SpeedUpPickUp" };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pv.IsMine) {
            return;
        }
        if (currentstate == GeneratorState.CoolDown)
        {
            if (CoolDownTimeLeft > 0)
            {
                CoolDownTimeLeft = CoolDownTimeLeft - Time.deltaTime * CoolDownSpeed;
            }
            if (CoolDownTimeLeft <= 0) {

                currentstate = GeneratorState.Ready;
            
            }
        }
        if (currentstate == GeneratorState.Ready)
        {
            int i = Mathf.RoundToInt(Random.Range(0, randomItem.Length));
            //Info Player That smthing has be generated
            PickUpItem = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", randomItem[i]),GeneratePoint.position, Quaternion.identity);
            CoolDownTimeLeft = CoolDownTime;
            currentstate = GeneratorState.Waiting;
        }
        if (currentstate == GeneratorState.Waiting) {
            if (PickUpItem == null) {
                currentstate = GeneratorState.CoolDown;
            }
        }
    }
    

    


   

}
