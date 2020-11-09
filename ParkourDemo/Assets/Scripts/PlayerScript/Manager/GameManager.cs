using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject readyButton;
    public void ReadyToPlay() {
        readyButton.SetActive(false);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
    }
    public void QuitGame()
    {
        StartCoroutine(DisconnectedandLoadMenu());
        //ReconnectAgain();
    }
    IEnumerator DisconnectedandLoadMenu()
    {
        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
            yield return null;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.LoadLevel(0);

    }


}
