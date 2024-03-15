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
    public BoxCollider2D cd;

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
        if (moveVector.y != 0)
        {
            animator.SetFloat("LookVertical", moveVector.y);
            animator.SetFloat("LookHorizontal", moveVector.x);
        }
        else if (moveVector.y == 0 && moveVector.x != 0)
        {
            animator.SetFloat("LookHorizontal", moveVector.x);
            animator.SetFloat("LookVertical", 0);
        }
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
        Debug.Log("Attacking");
        animator.SetTrigger("Attacking");
    }
}
