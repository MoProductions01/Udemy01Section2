using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToPhotonServer()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster() // master server is photon server
    {
        Debug.Log("NickName: " + PhotonNetwork.NickName + " is connected to Photon Servers (Master)");
    }

    public override void OnConnected() // will be called before OnConnectedToMaster because this is the internet connect check
    {
        Debug.Log("Connected to internet");
    }
}
