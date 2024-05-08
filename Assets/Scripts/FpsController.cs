using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FpsController : MonoBehaviourPun
{
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] Transform head = null;
    [SerializeField] Transform cam = null;
    [SerializeField] float cameraSense = 2f;
    [SerializeField] float clampRotation = 80f;

    FpsAnimationContoller fpsAnimation;
    Rigidbody rb;

    public FixedJoystick movementJoystick; // Reference to your movement joystick
    public FixedJoystick rotationJoystick; // Reference to your rotation joystick

    private void Awake()
    {
        fpsAnimation = GetComponent<FpsAnimationContoller>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;

        if (!photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Use UIManager to access UI elements
        UIManager uiManager = UIManager.Instance;
        if (photonView.IsMine)
        {
            lookAround();
            Moving();
        }
    }

    void lookAround()
    {
        cam.position = head.position;

        float mouseY = rotationJoystick.Vertical; // Use joystick input for vertical camera movement
        float mouseX = rotationJoystick.Horizontal; // Use joystick input for horizontal camera rotation

        cam.localRotation = Quaternion.Euler(Mathf.Clamp(mouseY * cameraSense, -clampRotation, clampRotation), 0, 0);
        transform.Rotate(Vector3.up, mouseX * cameraSense);
    }

    void Moving()
    {
        float moveHorizontal = movementJoystick.Horizontal;
        float moveVertical = movementJoystick.Vertical;

        Debug.Log($"Horizontal: {moveHorizontal}, Vertical: {moveVertical}");

        // Get the camera's forward and right vectors
        Vector3 cameraForward = cam.forward;
        Vector3 cameraRight = cam.right;

        // Project the joystick input onto the camera's forward and right vectors
        Vector3 moveDirection = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        //Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        Debug.Log($"Move Direction: {moveDirection}");

        bool isMoving = moveDirection.magnitude > 0;

        if (isMoving)
        {
            // Set the velocity directly based on the move direction
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }
        else
        {
            // If not moving, stop the Rigidbody
            rb.velocity = Vector3.zero;
        }

        Debug.Log($"New Velocity: {rb.velocity}");

        fpsAnimation.playerAnimation(new Vector2(moveHorizontal, moveVertical));
    }

}