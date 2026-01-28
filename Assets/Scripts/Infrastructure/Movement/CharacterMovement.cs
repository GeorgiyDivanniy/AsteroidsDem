using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CharacterMovement : MonoBehaviour
{
    private GameInput _controls;
    private Vector2 _moveInput;

    public event Action<Vector2> OnMoveInputChanged;

    private void Awake()
    {
        _controls = new GameInput();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.Gameplay.Movement.performed += OnMovementPerformed;
        _controls.Gameplay.Movement.canceled += OnMovementPerformed;
    }

    private void OnDisable()
    {
        _controls.Gameplay.Movement.performed -= OnMovementPerformed;
        _controls.Gameplay.Movement.canceled -= OnMovementPerformed;
        _controls.Gameplay.Disable();
    }

    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        OnMoveInputChanged?.Invoke(_moveInput);
    }
    
    public Vector2 GetCurrentInput() => _moveInput;
}

