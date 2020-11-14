using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
//using Hashtable = ExitGames.Client.Photon.Hashtable;

public class MazeGameManager : GameManager
{
    public static MazeGameManager instance;
    // Start is called before the first frame update
    public int MutantPlayerCount = 0;
    public Text MutantCounter;
    public Text RunnerCounter;
    public GameObject QuitGameR=null;
    public GameObject QuitGameM=null;
    //public Hashtable PlayerScoreList;
    public Transform ScoreBoardContent;
    [SerializeField] GameObject roomListItemPrefab;
    private TimerScript timeCounter;
    private new void Awake()
    {
        timeCounter = GetComponent<TimerScript>();
        instance = this;
        base.Awake();
        // PlayerScoreList = new Hashtable();
        foreach (var player in PhotonNetwork.PlayerList)
        {
            //PlayerScoreList.Add(player.NickName, 0);
            if (player.IsMasterClient)
            {
                //Hashtable hash = new Hashtable();
                //hash.Add("score", 0);
                //player.CustomProperties = hash;
                ScoreList.Add(player, 0);
            }
            else {
                //Hashtable hash = new Hashtable();
                //hash.Add("score", 100);
                //player.CustomProperties = hash;
                ScoreList.Add(player, 100);
            }
            Instantiate(roomListItemPrefab, ScoreBoardContent).GetComponent<ScoreBoardItem>().SetUp(player);
        }
    }
    // Update is called once per frame

    public override void ReadyToPlay() {
        base.ReadyToPlay();
        timeCounter.StartCount();
    }


    void Update()
    {
        MutantCounter.text = "Mutant__"+MutantPlayerCount;
        RunnerCounter.text = "Runner__" +(currentPlayerLeft()-MutantPlayerCount);
       
    }
    int currentPlayerLeft() {

        if (PhotonNetwork.CurrentRoom != null)
        {
            return PhotonNetwork.CurrentRoom.PlayerCount;
        }
        else {
            return 0;
        }
       
    }


    public void IncreaseMutantCount() {
        PV.RPC("IncreaseMutantCountPun", RpcTarget.All, new object[] {  });
    }

    [PunRPC]
    void IncreaseMutantCountPun() {
        MutantPlayerCount = MutantPlayerCount + 1;
        if (MutantPlayerCount == currentPlayerLeft()) {
            EndGame();
        }
    }
    public void EndGame() {

        if (currentPlayerLeft() - MutantPlayerCount == 0)
        {
            QuitGameM.SetActive(true);
        }
        else
        {
            QuitGameR.SetActive(true);
        }
    }
    public void ScoreBeMutant(Player player)
    {
        PV.RPC("ScoreMutant", RpcTarget.All, new object[] { player });
    }
    [PunRPC]
    public void ScoreMutant(Player player)
    {
        int addAmount = (int)(100*(timeCounter.timerValue-(timeCounter.timeLeft))/timeCounter.timerValue);
        //int temp = (int)ScoreList[player];
        //Hashtable hash = new Hashtable();
        //hash.Add("score", addAmount);
        ScoreList[player] = addAmount;
        //player.CustomProperties = hash;
    }
}
