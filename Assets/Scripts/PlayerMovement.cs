using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float JumpChargeTime = 0;
    public float JumpVelocity = 5f;
    public Vector3 move;
    public float gravity = 10.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;

    public float inAirSpeed = 2.0f; // The movementspeed in air
    public float inAirRotation = 0.8f; // Rotation speed in air

    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public bool canMove = true;

    private bool camMode = true;
    private bool _isAiming = false;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    private float verticalVelocity = 0;
    private bool _isCharging;
    private bool _isJumping;
    private Rigidbody _rb;
    private CapsuleCollider _col;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        firstPersonCamera.enabled = false;
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        Vector3 input = GetPlayerInput();
        if (controller.isGrounded)
        {

            // We are grounded, so update move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                //
            }
            move = moveDirection;

        }
        else
        {
            // We are not grounded. We can influence the movementspeed with the vertical axis

            moveDirection += input * speed * 0.006f / (Time.deltaTime+ 2f);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;
        // Move the Player
        controller.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }

        // Camera modes
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeCamera();
        }
        if (camMode)
        {
            if (Input.GetButton("Fire2"))
                firstPersonCamera.enabled = true;
            else
                firstPersonCamera.enabled = false;

        }

    }
    public void changeCamera()
    {
        if (camMode == true)
        {
            thirdPersonCamera.enabled = false;
            firstPersonCamera.enabled = true;
            camMode = false;
        }
        else
        {
            thirdPersonCamera.enabled = true;
            firstPersonCamera.enabled = false;
            camMode = true;
        }

    }
    private Vector3 GetPlayerInput()
    {
        Vector3 output = new Vector3();
        output.x = Input.GetAxisRaw("Horizontal");
        output.z = Input.GetAxisRaw("Vertical");
        output = Vector3.ClampMagnitude(output, 1f);
        output = transform.rotation * output;
        output.y = 0;
        return (output);
    }
}
