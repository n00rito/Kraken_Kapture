using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 4;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isPlayerInside = false; // Flag to track if the player is in the boat

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        if (isPlayerInside)
        {
            movement = Vector2.zero;
            animator.SetBool("isPlayerInside", true);


        } // Don't move if the player is inside the boat

        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInside) return; // Don't move if the player is inside the boat

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    // Method to set whether the player is inside the boat or not
    public void SetPlayerInside(bool inside)
    {
        isPlayerInside = inside;
        rb.isKinematic = inside;

        // Update animation based on player inside the boat
        animator.SetBool("isPlayerInside", isPlayerInside);
    }
}