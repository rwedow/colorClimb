using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAttack : MonoBehaviour {
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Animator anim;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;

    void Update() {
        if (timeBtwAttack <= 0) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                anim.SetBool("Attacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++ ) {
                    enemiesToDamage[i].GetComponent<PatrollingEnemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        } else {
            anim.SetBool("Attacking", false);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
