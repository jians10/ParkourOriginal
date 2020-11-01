using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
	[SerializeField] TMP_Text text;
	Player player;

	//when the player join the room the launcher will generate call back 
	// then it will generate this "Player List Item"
	


	public void SetUp(Player _player)
	{
		player = _player;
		text.text = _player.NickName;
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		if (player == otherPlayer)
		{
			Destroy(gameObject);
		}
	}

	// When the Player leave the room then the player List Item will be destroyed


	public override void OnLeftRoom()
	{
		Destroy(gameObject);
	}
}