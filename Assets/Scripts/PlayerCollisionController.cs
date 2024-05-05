using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{

        public BoxCollider2D normalCollider; // Reference to the Collider for normal state
        public BoxCollider2D sharkCollider; // Reference to the Collider for crouching state
        public PlayerMovement playermovement;

    void Start()
        {
            // Ensure that the normalCollider is enabled by default
            normalCollider.enabled = true;
            // Ensure that the crouchingCollider is disabled by default
            sharkCollider.enabled = false;
        }

        void Update()
        {
            // Example: If the player is crouching (you can replace this condition with your actual logic)
            if (playermovement.isPlayerInside)
            {
                // Enable crouchingCollider and disable normalCollider
                sharkCollider.enabled = true;
                normalCollider.enabled = false;
            }
            else
            {
                // Enable normalCollider and disable crouchingCollider
                normalCollider.enabled = true;
                sharkCollider.enabled = false;
            }
        }
    }

