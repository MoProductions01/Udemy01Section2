using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PGGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject playerPrefab;

    public static PGGameManager instance; // make this a singleton so there's only one instance in the scene at a time // monote

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        // instantiate player
        if(PhotonNetwork.IsConnected)
        {
            if(playerPrefab != null)
            {
                int randomPoint = Random.Range(-20, 20);
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(randomPoint, 0, randomPoint), Quaternion.identity);
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() NickName: " + PhotonNetwork.NickName + " joined room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("OnPlayerEnteredRoom() newPlayer NickName: " + newPlayer.NickName + " joined room: " + PhotonNetwork.CurrentRoom.Name + " room count now: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncher");
    }

    public void LeaveRoom()
    {
        Debug.Log("LeaveRoom()");
        PhotonNetwork.LeaveRoom();
    }
}
