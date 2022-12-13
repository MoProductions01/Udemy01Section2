using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInputManager : MonoBehaviour
{
    public void SetPlayerName(string value)
    {
        //Debug.Log("SetPlayerName(): " + value);             
        if(string.IsNullOrEmpty(value))
        {
            Debug.LogWarning("player name is empty");
            return;
        }

        PhotonNetwork.NickName = value;
    }
}
