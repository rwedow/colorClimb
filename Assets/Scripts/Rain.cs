using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain : MonoBehaviour
{

    private float startHealth = 100;
    private float health;
    public int points;
    public Animator anim;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update() {
    }

    public void TakeDamage(int damage) {
        if (!anim.GetBool("Umbrella")) {
            health -= damage;
            healthBar.fillAmount = health / startHealth;;
        }
    }
}
