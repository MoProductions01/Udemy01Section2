using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using JetBrains.Annotations;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;

    #region Unity Methods
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }
    #endregion

    #region Public Methiods
    public void ConnectToPhotonServer()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }

    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    #region Private Methods
    void CreateAndJoinRoom()
    {
        string randomRoomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }
    #endregion

    #region Photon Callbacks

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() NickName: " + PhotonNetwork.NickName + " joined room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //base.OnPlayerEnteredRoom(newPlayer); // monote - need to call base?
        Debug.Log("OnPlayerEnteredRoom() new player NickName: " + newPlayer.NickName + " joined room: " +
            PhotonNetwork.CurrentRoom.Name + " now with num players: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomRoomFailed() message: " + message);
        base.OnJoinRandomFailed(returnCode, message);
        CreateAndJoinRoom();
    }
    public override void OnConnectedToMaster() // master server is photon server
    {
        Debug.Log("NickName: " + PhotonNetwork.NickName + " is connected to Photon Servers (Master)");
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    public override void OnConnected() // will be called before OnConnectedToMaster because this is the internet connect check
    {
        Debug.Log("Connected to internet");
    }
    #endregion
}
