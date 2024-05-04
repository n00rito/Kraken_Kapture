using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    public Health playerHealth;
    public GameObject popUpPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<Health>();

                playerHealth.TakeDamage(damage);
            }

           GameObject popUp = Instantiate (popUpPrefab, collision.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();

            if(transform.position.x > collision.transform.position.x)
            {
                popUp.GetComponent<PopUpDamage>().hitFromRight = true;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
