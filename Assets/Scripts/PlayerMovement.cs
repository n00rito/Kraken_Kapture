using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 4;
    public AudioClip walkingClip;
    private Vector2 movement;
    private Rigidbody2D rb;
    private float input;
    private Animator animator;
    public bool isPlayerInside; // Flag to track if the player is in the boat
    private BoatMovement boatMovement;
    private AudioSource audioSource; // Reference to AudioSource component


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component
        boatMovement = GetComponent<BoatMovement>();
        audioSource.clip = walkingClip;
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlayerInside)
            {
                boatMovement.Interact();
                audioSource.Stop();
                //animator.SetBool("IsWalking", false);
            }
            if (!isPlayerInside)
            {
                animator.SetBool("isPlayerInside", false);
            }
  
          
            else
            {
                animator.SetBool("isPlayerInside", false);
            }
            }
        }
    

    private void OnMovement(InputValue value)
    {
        {
            if (isPlayerInside)
            {
                //animator.SetBool("isPlayerInside", true);
                animator.SetBool("IsWalking", false);
                audioSource.Stop();


            } // Don't move if the player is inside the boat
            if (!isPlayerInside)
            {
                //animator.SetBool("isPlayerInside", true);
                animator.SetBool("IsWalking", true);
                audioSource.Play();


            } // Don't move if the p

            movement = value.Get<Vector2>();

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("X", movement.x);
                animator.SetFloat("Y", movement.y);
                animator.SetBool("IsWalking", true);
                    //audioSource.Play();
            }
        
            else
            {
                animator.SetBool("IsWalking", false);
                audioSource.Stop();
            }
            
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
       animator.SetBool("isPlayerInside", true);
        audioSource.Stop();
    }
}