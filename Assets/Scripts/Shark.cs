using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the shark moves
    private Transform player; // Reference to the player's transform
    private bool canFollowPlayer = false; // Flag to indicate if the shark can follow the player

    void Start()
    {
        // Find the player GameObject and get its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
 
    void Update()
    {
        if (canFollowPlayer && player != null)
        {
            // Calculate direction from shark to player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move shark towards the player
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }


// Called when the object becomes visible to any camera
    void OnBecameVisible()

    {
        // Start delay coroutine
        StartCoroutine(StartMovingDelay(2f)); // Wait for 4 seconds before starting to move
    }

    IEnumerator StartMovingDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        canFollowPlayer = true;
    }

    // Called when the object becomes invisible to any camera
    void OnBecameInvisible()
    {
        canFollowPlayer = false;
    }

}
