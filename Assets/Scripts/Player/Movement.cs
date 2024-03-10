using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerInputAction input;
    private Vector2 moveVector = Vector2.zero;
    public Rigidbody2D rb;
    public float moveSpeed = 8.5f;
    public Animator animator;

    private void Awake()
    {
        input = new PlayerInputAction();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.Attack.started += OnAttackStarted;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.Attack.started -= OnAttackStarted;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        animator.SetFloat("Horizontal", moveVector.x);
        animator.SetFloat("Vertical", moveVector.y);
        animator.SetFloat("Speed", moveVector.sqrMagnitude);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
    private void OnAttackStarted(InputAction.CallbackContext value)
    {
        Debug.Log("Button Pressed");
    }
}
