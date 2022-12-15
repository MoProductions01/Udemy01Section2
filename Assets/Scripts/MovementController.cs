using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    GameObject fpsCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float CameraUpAndDownRotation = 0f;
    private float CurrentCameraUpAndDownRotation = 0f;

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

        // calculate rotation as a 3D vector
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _roationVector = new Vector3(0, _yRotation, 0) * lookSensitivity;

        // Apply rotation
        Rotate(_roationVector);

        // Calculate look up and down camera rotation
        float _cameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Apply rotation
        RotateCamera(_cameraUpDownRotation);
    }

    void FixedUpdate() // for RigidBody movement
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // does all physics automatically monote
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(fpsCamera != null)
        {
            CurrentCameraUpAndDownRotation -= CameraUpAndDownRotation; // monote - figure this out 
            CurrentCameraUpAndDownRotation = Mathf.Clamp(CurrentCameraUpAndDownRotation, -85, 85);
            fpsCamera.transform.localEulerAngles = new Vector3(CurrentCameraUpAndDownRotation, 0f, 0f);
        }
    }

    void Rotate( Vector3 rotationVector)
    {
        rotation = rotationVector;
    }

    void RotateCamera(float cameraUpAndDownRotation)
    {
        CameraUpAndDownRotation = cameraUpAndDownRotation;
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }
}
