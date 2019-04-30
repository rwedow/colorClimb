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
    }

    public void TakeDamage(int damage) {
        if (!anim.GetBool("Umbrella")) {
            health -= damage;
            healthBar.fillAmount = health / startHealth;
        }
    }

    public void GetPoints(int newPoints) {
        points += newPoints;
        pointsBar.fillAmount = points;
    }

    //add get paint bucket here
    //paintBar.fillAmount = points;
}
