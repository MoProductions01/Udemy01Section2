using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    private Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // calculate movement velocity as a 3D vector
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement; // monote = more control schemes

        // final movement velocity vector
        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed; // monote - more velocity stuff

        // Apply movement
        Move(_movementVelocity);
    }

    void  FixedUpdate() // for RigidBody movement
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // does all physics automatically monote

        }
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }
}
