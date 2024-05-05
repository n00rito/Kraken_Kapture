using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    public Transform[] waypoints; // Array of patrol waypoints
    public Transform player; // Reference to the player transform
    public float moveSpeed = 2f; // Speed at which the enemy moves
    public float chaseDistance = 5f; // Distance at which the enemy starts chasing the player
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private Animator animator; // Reference to the animator component

    private bool isChasing = false; // Flag to indicate if the enemy is currently chasing the player

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the animator component
    }

    void Update()
    {
        // Check if the player is within chase distance
        if (player != null && Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            // Start chasing the player
            isChasing = true;
        }

        // If chasing, move towards the player
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            // Add any additional chasing behavior here
        }
        else // Otherwise, patrol
        {
            Patrol();
        }

        // Update animator parameters
        animator.SetFloat("MoveSpeed", moveSpeed); // You might need to adjust this based on your animation setup
    }

    void Patrol()
    {
        // Check if there are waypoints
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to the enemy.");
            return;
        }

        // Move towards the current waypoint
        Transform currentWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}

