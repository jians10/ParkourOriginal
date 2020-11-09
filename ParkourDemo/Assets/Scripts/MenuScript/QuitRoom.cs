using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class QuitRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update



    public void QuitGame()
    {
        //StartCoroutine(DisconnectedandLoadMenu());
        //ReconnectAgain();
    }
    IEnumerator DisconnectedandLoadMenu() {
        PhotonNetwork.LeaveRoom();
      
        while (PhotonNetwork.InRoom)
            yield return null;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene(0);

    }


}
