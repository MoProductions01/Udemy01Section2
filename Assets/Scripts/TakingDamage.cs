using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Image healthBar;

    private float health;
    public float startHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;

        healthBar.fillAmount = health/startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void TakeDamage(float _damage)
    {
        health -= _damage;
        Debug.Log("TakeDamage() health: " + health);
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Die();
        }
    }

    void OnGUI()
    {
        if (photonView.IsMine == false) return;

        if(GUI.Button(new Rect(0,0,300,100), PhotonNetwork.NickName + ": take 1000 dmg"))
        {
            TakeDamage(1000);
        }
    }

    void Die()
    {
        if(photonView.IsMine)
        {
            PGGameManager.instance.LeaveRoom();
        }
    }
}
