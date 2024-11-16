using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float sens;
    public float speed;
    public float gravity;
    [Header("Unity Set Up")]
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float checkRadius;

    private CharacterController controller;
    private float xRotation;
    public float yVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        xRotation = 0;
        yVelocity = 0;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        DoLook();
        DoMove();
        DoGravity();
    }

    private void DoLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89, 89);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void DoMove()
    {
        float forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float right = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        controller.Move(forward * transform.forward);
        controller.Move(right * transform.right);
    }

    private void DoGravity()
    {
        if (Physics.CheckSphere(groundCheck.position, checkRadius, groundMask))
        {
            yVelocity = 2;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        controller.Move(Time.deltaTime * yVelocity * Vector3.down);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, checkRadius);
    }
}
