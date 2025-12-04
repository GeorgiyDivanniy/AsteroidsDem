using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour, IMovable
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private GameInput controls;

    private void Awake()
    {
        controls = new GameInput();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Movement.performed += OnMovementPerformed;
        controls.Gameplay.Movement.canceled += OnMovementPerformed;
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
        controls.Gameplay.Movement.performed -= OnMovementPerformed;
        controls.Gameplay.Movement.canceled -= OnMovementPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       Move(moveInput);
    }
}
