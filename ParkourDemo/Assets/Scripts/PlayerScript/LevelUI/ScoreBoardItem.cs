using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
//using Hashtable = ExitGames.Client.Photon.Hashtable;
public class ScoreBoardItem : MonoBehaviourPunCallbacks
{
	[SerializeField] Text playername;
	[SerializeField] Text score;
	Player player;

	//when the player join the room the launcher will generate call back 
	// then it will generate this "Player List Item"
	public void SetUp(Player _player)
	{
		player = _player;
		playername.text = player.NickName;
		score.text = ":" +player.CustomProperties["score"];
	}
	public void SetUp(Player _player, int num)
	{
		player = _player;
		playername.text = _player.NickName;
		score.text = ":" + num;
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

    private void FixedUpdate()
    {
		score.text = ":" + player.CustomProperties["score"];
	}
}