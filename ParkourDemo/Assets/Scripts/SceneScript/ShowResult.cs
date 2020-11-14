using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class ShowResult : MonoBehaviour
{

    public Text Name;
    public Text Order;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setResult(int order) {
        Name.text = "Name:"+PhotonNetwork.LocalPlayer.NickName;
        Order.text = "Rank:"+ order;
        
    }
}
