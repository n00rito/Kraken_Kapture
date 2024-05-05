using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _interactSprite;
    [SerializeField] private float speed = 4f; // Speed of the boat
    public AudioClip sailingClip;
    private Transform _playerTransform;
    private const float INTERACT_DISTANCE = 3F;
    private Vector2 movement; // Direction of movemen
    public Rigidbody2D rb; // Rigidbody component of the boat
    private Animator animator; // Animator component of the boat
    private bool isMovementEnabled = false; // Flag to track if movement is enabled
    private bool isPlayerInside = false;
    private AudioSource audioSource; // Reference to AudioSource component


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component
        audioSource.clip = sailingClip;
    }

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //animator.SetBool("IsSailing", false);
       // animator.SetBool("isPlayerInside", false);
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && IsWithinInteractDistance())
        {
            // Interact with the boat
            Interact();
        }

        if (_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            // Turn off the sprite
            _interactSprite.gameObject.SetActive(false);
        }

        else if (!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            // Turn on the sprite
            _interactSprite.gameObject.SetActive(true);
        }
    }




    private bool IsWithinInteractDistance()
    {
        return Vector2.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE;
    }

    public void Interact()
    {
        if (!isPlayerInside)
        {
            // Move the player inside the boat
            _playerTransform.position = transform.position;
            _playerTransform.parent = transform;
            isPlayerInside = true;

            // Enable boat movement
            EnableMovement();

            // Update player movement script
            var playerMovement = _playerTransform.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.SetPlayerInside(true);
        }
    }

    public void EnableMovement()
    {
        isMovementEnabled = true;
    }

    private void OnMovement(InputValue value)
    {
        if (isPlayerInside)
        {
            movement = Vector2.zero;
           // animator.SetBool("isPlayerInside", true);
            //animator.SetBool("IsSailing", true);
            _interactSprite.gameObject.SetActive(false);


        } // Don't move if the player is inside the boat

        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
            if (isMovementEnabled)
            {
                animator.SetFloat("X", movement.x);
                animator.SetFloat("Y", movement.y);
                animator.SetBool("IsSailing", true);
                animator.SetBool("isMovementEnabled", true);
                animator.SetBool("isPlayerInside", true);


                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            else
            {
                animator.SetBool("IsSailing", false);
                animator.SetBool("isMovementEnabled", false);
                animator.SetBool("isPlayerInside", false);
                audioSource.Stop();// Change animation state to not sailing
                                   //animator.SetBool("isPlayerInside", false);
            }
}


    private void FixedUpdate()
    {
        if (!isMovementEnabled) return; // Exit if movement is not enabled

        // Move the boat based on the input direction and speed
        //rb.MovePosition(rb.position + Vector2.one);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Debug.Log($"delta movement {movement * speed * Time.fixedDeltaTime}");
    }
}