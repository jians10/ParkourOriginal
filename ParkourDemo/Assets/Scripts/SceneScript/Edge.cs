using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // Start is called before the first frame update

    public float Hanger;
    public PhotonView PV;

    void Awake() {

        PV = GetComponent<PhotonView>();
    
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHangerPosition(int ViewID) { 
    
        
    
    
    
    }
    
}
