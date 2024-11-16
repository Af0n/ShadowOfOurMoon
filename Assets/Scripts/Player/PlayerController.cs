using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public PlayerInteract playerInteract;
    public FlareThrow flareThrow;
    public Flashlight flash;
    public PlayerControls inputActions;
    private InputAction _move; 
    private InputAction _look;
    private InputAction _flash;
    private InputAction _flare;
    private InputAction _interact;
    private CharacterController controller;
    private float xRotation;
    private float yVelocity;
    
    private void Awake()
    {
        inputActions = new PlayerControls();
        _move = inputActions.Movement.Move;
        _look = inputActions.Movement.Look;
        _flare = inputActions.Movement.Flare;
        _flash = inputActions.Movement.Flash;
        _interact = inputActions.Movement.Interact;
        controller = GetComponent<CharacterController>();
        xRotation = 0;
        yVelocity = 0;
        _interact.performed += _ => playerInteract.TryInteract();
        _flare.performed += _ => flareThrow.TryThrow();
        _flash.performed += _ => flash.TryToggle();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() => enableControls();
    private void OnDisable() => disableControls();

    public void enableControls() {
        _move.Enable();
        _look.Enable();
        _flare.Enable();
        _flash.Enable();
        _interact.Enable();
    }

    public void disableControls() {
        _move.Disable();
        _look.Disable();
        _flare.Disable();
        _flash.Disable();
        _interact.Disable();
    }

    private void Update()
    {
        DoLook();
        DoMove();
        DoGravity();
    }

    private void DoLook()
    {
        Vector2 lookInput = _look.ReadValue<Vector2>();

        float mouseX = lookInput.x * sens * Time.deltaTime;
        float mouseY = lookInput.y * sens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89, 89);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void DoMove()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        float forward = moveInput.y * speed * Time.deltaTime;
        float right = moveInput.x * speed * Time.deltaTime;

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
