using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;


public class PlayerInputHandler : MonoBehaviour {
    public PlayerController playerController;
    public PlayerInteract playerInteract;
    public FlareThrow flareThrow;
    public Flashlight flashlight;
    public PlayerInputActions inputActions;
    // Mouse and Keyboard or Controller? 
    public InputType inputType = InputType.MK;

    private InputAction _move;
    private InputAction _look;
    private InputAction _flashlight;
    private InputAction _flare;
    private InputAction _pause;
    private InputAction _jump;
    private InputAction _interact;
    private void OnEnable() => EnableControls();
    private void OnDisable() => DisableControls();
    private void Awake() {
        inputActions = new PlayerInputActions();

        // set the refrences
        _move = inputActions.Movement.Moving;
        _look = inputActions.Movement.Looking;
        _flashlight = inputActions.Movement.Flashlight;
        _flare = inputActions.Movement.Flare;
        _pause = inputActions.Movement.Pause;
        _jump = inputActions.Movement.Jump;
        _interact = inputActions.Movement.Interact;

        _interact.performed += _ => playerInteract.TryInteract();
        _flashlight.performed += _ => flashlight.TryToggle();
        _flare.performed += _ => flareThrow.TryThrow();
    }

    private void Update() {
        if(_move.enabled) playerController.DoMove(_move.ReadValue<Vector2>());
        if(_look.enabled) playerController.DoLook(_look.ReadValue<Vector2>());
    }
    public void EnableControls() {
        _move.Enable();
        _look.Enable();
        _flashlight.Enable();
        _flare.Enable();
        _move.Enable();
        _pause.Enable();
        _jump.Enable();
        _interact.Enable();
    }

    public void DisableControls() {
        _move.Disable();
        _look.Disable();
        _flashlight.Disable();
        _flare.Disable();
        _move.Disable();
        _pause.Disable();
        _jump.Disable();
        _interact.Disable();
    }
}   