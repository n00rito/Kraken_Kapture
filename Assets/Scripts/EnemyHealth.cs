using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 15;
    public Rigidbody2D enemyRb;
    public float delayTime = .15f;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();


    }
    public void TakeDamage(int amount, bool facingRight, float KBForce)
    {
        if (facingRight)
        {
            enemyRb.AddForce(Vector2.right * KBForce, ForceMode2D.Impulse);
        }
        else
        {
            enemyRb.AddForce(Vector2.left * KBForce, ForceMode2D.Impulse);
        }
    

        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        enemyRb.velocity = Vector2.zero;
    }
}
