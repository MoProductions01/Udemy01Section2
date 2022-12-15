using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Camera fpsCamera;

    public float fireRate = 0.1f;
    public float fireTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // hit scan, projectile ballistics are the two main shooting mechanis
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        if(Input.GetButton("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0f;
            RaycastHit _hit;
            Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out _hit, 100))
            {
                Debug.Log("_hit collider name: " + _hit.collider.gameObject.name);
                if (_hit.collider.gameObject.CompareTag("Player") && _hit.collider.gameObject.GetComponent<PhotonView>().IsMine == true)                    
                {   // monote - if you want to have this call also happen for players who join later make it make RpcTarget buffered (see 2nd line below);                   
                    //_hit.collider.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All); // monote - RPC's!!                        
                    Debug.Log("shot a player so make them take damage");
                    _hit.collider.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.AllBuffered, 10f); // monote - RPC's!!                        
                }                
            }
        }
    }
}
