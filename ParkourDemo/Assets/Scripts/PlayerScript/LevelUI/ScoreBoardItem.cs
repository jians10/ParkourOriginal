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
	int scorePoints;

	//when the player join the room the launcher will generate call back 
	// then it will generate this "Player List Item"
	public void SetUp(Player Targetplayer)
	{
		player = Targetplayer;
		scorePoints = (int)GameManager.basicinstance.ScoreList[player];
		playername.text = player.NickName;
		score.text = scorePoints + "Point";
	}

    public void FixedUpdate()
    {
        scorePoints= (int)GameManager.basicinstance.ScoreList[player];
		score.text = ":"+scorePoints + "Point";
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