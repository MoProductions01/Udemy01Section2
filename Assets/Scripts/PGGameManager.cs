using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PGGameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
