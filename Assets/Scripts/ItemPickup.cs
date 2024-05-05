using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool spearHandEquippable;

    private Transform spearHand;

    // Start is called before the first frame update
    void Start()
    {
        spearHand = GameObject.Find("SpearHand").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")

                if(spearHandEquippable == true)
            {
                transform.SetParent(spearHand);
            }
            else
            {
                transform.localPosition = Vector2.zero;
            }
    }

}
