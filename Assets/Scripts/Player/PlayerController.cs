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
    public float multiplier;

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
        DoGravity();
    }

    public void DoLook(Vector2 input)
    {
        float mouseX = input.x * sens * Time.deltaTime;
        float mouseY = input.y * sens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89, 89);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void DoMove(Vector2 input)
    {
        float forward = input.y * speed * Time.deltaTime;
        float right = input.x * speed * Time.deltaTime;

        controller.Move(multiplier * forward * transform.forward);
        controller.Move(multiplier * right * transform.right);
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
