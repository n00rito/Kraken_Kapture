using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Boat : MonoBehaviour, IInteractable
{
    public GameObject player; // Reference to the player GameObject
    private bool isPlayerInside = false; // Flag to track if the player is inside the boat

    public void Interact()
    {
        // Check if the player is already inside the boat
        if (!isPlayerInside)
        {
            // Move the player inside the boat
            player.transform.position = transform.position; // Teleport the player to the boat's position
            player.transform.parent = transform; // Make the player a child of the boat
            isPlayerInside = true; // Update flag to indicate the player is inside the boat

            // Enable boat movement
            GetComponent<BoatMovement>().EnableMovement();

            // Update player movement script
            player.GetComponent<PlayerMovement>().SetPlayerInside(true);
        }
    }
}