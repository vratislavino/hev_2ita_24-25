using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShooterMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 1000f;

    [SerializeField]
    private float mouseSensitivity = 1f;

    [SerializeField]
    private Transform cameraHolder;
    
    [SerializeField]
    private Transform groundCheck;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!cameraHolder)
        {
            Debug.LogError("Don't forget to assign camera holder in Inspector");
            enabled = false;
        }
        if (!groundCheck)
        {
            Debug.LogError("Don't forget to assign ground check in Inspector");
            enabled = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CheckGrounded();
        DoMovement();
        DoRotation();
    }

    private void CheckGrounded()
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hit, 0.03f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    private void DoRotation()
    {
        var xrot = Input.GetAxis("Mouse X") * mouseSensitivity;
        var yrot = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * xrot);
        var currentXRotation = cameraHolder.localRotation.eulerAngles.x;
        if (currentXRotation > 180)
            currentXRotation -= 360;
        var newXRot = currentXRotation - yrot;
        newXRot = Mathf.Clamp(newXRot, -70, 90);
        cameraHolder.localRotation = Quaternion.Euler(newXRot, 0, 0);
    }

    private void DoMovement()
    {
        var horMove = Input.GetAxis("Horizontal");
        var verMove = Input.GetAxis("Vertical");
        var jump = Input.GetButtonDown("Jump");

        var tempVelocity = rb.linearVelocity.y;

        if (jump && isGrounded)
            tempVelocity = jumpForce;

        var movement = new Vector3(horMove, 0, verMove) * speed;
        var rotatedMovement = transform.rotation * movement;

        rotatedMovement.y = tempVelocity;

        rb.linearVelocity = rotatedMovement;
    }
}
