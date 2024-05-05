using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    public Health playerHealth;
    public BoatHealth boatHealth;
    public GameObject popUpPrefab;
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided");

           // playerMovement.KBCounter = playerMovement.KBTotalTime;

           // if (collision.transform.position.x <= transform.position.x)
           // {
            //    playerMovement.KnockFromRight = true;
            //}
           // else
           // {
               // playerMovement.KnockFromRight = false;
           // }

            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<Health>();
            }

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            if (boatHealth == null)
            {
                boatHealth = collision.gameObject.GetComponent<BoatHealth>();
            }

            if (boatHealth != null)
            {
                boatHealth.TakeDamage(damage);
            }


            GameObject popUp = Instantiate(popUpPrefab, collision.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();

            if (transform.position.x > collision.transform.position.x)
            {
                popUp.GetComponent<PopUpDamage>();
            }
        }
    }
}
