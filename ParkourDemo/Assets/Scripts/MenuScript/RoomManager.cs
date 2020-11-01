using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;


public class RoomManager : MonoBehaviourPunCallbacks
{

    // provide an singleton pattern for this class
    public static RoomManager Instance;

    void Awake()
    {
        if (Instance) //check if another roommanger exist
        {
            Destroy(gameObject); // if there is then destroy itself
            return;
        }
        DontDestroyOnLoad(gameObject);
        //this let the roomManager remain when sence is changed
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        //whenever we switch the sence the onsceneLoad will be called 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1 || scene.buildIndex == 2) // We're in the game scene
        {
            //we need to instantiate the player manager prefab
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
