using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormRain : MonoBehaviour
{
    public float rainRange;
    public LayerMask whoIsRain;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] playerDamage = Physics2D.OverlapCircleAll(transform.position, rainRange, whoIsRain);
        for (int i = 0; i < playerDamage.Length; i++) {
            playerDamage[i].GetComponent<Rain>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rainRange);
    }
}
