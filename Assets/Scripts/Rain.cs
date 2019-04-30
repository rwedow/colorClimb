using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain : MonoBehaviour
{

    private float startHealth = 100;
    private float health;
    private float startPoints = 0;
    private float points;
    public Animator anim;
    public int[] paintColors;
    public bool isDead = false;

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
