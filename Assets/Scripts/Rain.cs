using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain : MonoBehaviour
{

    private float startHealth = 100;
    private float health;
    private float startPoints = 0;
    public Transform attackPosition;
    public float attackRange;
    private float points;
    public Animator anim;
    public int[] paintColors;
    public bool isDead = false;
    public LayerMask whatIsItems;

    public Image healthBar;
    public Image pointsBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        points = startPoints;
        
    }

    // Update is called once per frame
    void Update() {
        GetComponent<Transform>().SetPositionAndRotation(GetComponent<Transform>().position, new Quaternion());

        //Collider2D[] paintToGrab = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsItems);
        //Debug.Log(paintToGrab);
        //for (int i = 0; i < paintToGrab.Length; i++)
        //{
        //    Debug.Log("GOT CAN!");
        //    health += 1;
        //    healthBar.fillAmount = health / startHealth;
        //    points++;
        //    Debug.Log(health);
        //    paintToGrab[i].GetComponent<PaintCan>().Gone();
        //}
    }

    public void TakeDamage(int damage) {
        if (!anim.GetBool("Umbrella")) {
            health -= damage;
            healthBar.fillAmount = health / startHealth;
        }
        if (health <= 0) {
            isDead = true;
        }
    }

    public void PickUpCan(int canSize) {
        Debug.Log("Got Paint (Size: " + canSize + ")");
        health += 1;
        healthBar.fillAmount = health / startHealth;
        points++;
    }

}
