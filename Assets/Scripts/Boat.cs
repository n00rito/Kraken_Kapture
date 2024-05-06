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
        else
        {
            ExitBoat();
        }
        }



    private void ExitBoat()
{
    // Check if the player is inside the boat
    if (isPlayerInside)
    {
        // Move the player out of the boat
        player.transform.parent = null; // Remove player from being a child of the boat
        isPlayerInside = false; // Update flag to indicate the player is not inside the boat

            // Disable boat movement
            GetComponent<BoatMovement>().DisableMovement();


            // Update player movement script
            player.GetComponent<PlayerMovement>().SetPlayerInside(false);
    }
}
}

