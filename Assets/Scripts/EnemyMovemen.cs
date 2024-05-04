using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class EnemyMovemen : MonoBehaviour
{
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public float moveSpeed = 3f;
    private Animator animator; // Animator component reference
    private bool isMoving = false; // Boolean to track movement state

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
        // Get the Animator component attached to this GameObject
    }

    void Update()
    {
        if (isChasing)
        {
            // Monster chase
            Vector3 moveDirection = (playerTransform.position - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // Check if player is out of chase distance
            if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
            {
                isChasing = false;
            }

            // Set movement parameters for blend tree
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);

            // Set isMoving to true when chasing
            animator.SetBool("isMoving", true);
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            // Include normal movements
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Set Animator parameters
            animator.SetFloat("Horizontal", horizontalInput);
            animator.SetFloat("Vertical", verticalInput);

            // Set isMoving based on whether the enemy is moving
            isMoving = Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0;
        }

        // Set isMoving parameter in Animator
        animator.SetBool("isMoving", isMoving);
    }
}
