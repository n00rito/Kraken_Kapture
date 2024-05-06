using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class MeleeAttack : MonoBehaviour
{
    public Animator playerAnim;
    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;
    public ParticleSystem attackParticles;

    public float KBForce;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("SpearSlash"))
        {
            StartCoroutine(Attack());
        }

    }

    IEnumerator Attack()
    {
        playerAnim.Play("SpearSlash");
        Collider2D enemy = Physics2D.OverlapCircle(weaponTransform.position, weaponRange, enemyLayer);
        yield return new WaitForSeconds(attackDelay);
        bool facingRight = (transform.position.x < enemy.transform.position.x);
        enemy.GetComponent<EnemyHealth>().TakeDamage(weaponDamage, facingRight, KBForce);
    }
 
}
