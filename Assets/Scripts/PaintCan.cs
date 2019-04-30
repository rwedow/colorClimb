using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCan : MonoBehaviour
{
    // Start is called before the first frame update
    int canSize;
    public int canRadius;
    int canColor; // 0 = red 1 = yellow 2 = blue 3 = all
    public Sprite[] canSprite;
    public LayerMask whatIsRain;

    void Start()
    {
        whatIsRain = 10;
        canSize = Random.Range(0, 3);
        //canSprite = new Sprite[4];
        gameObject.GetComponent<SpriteRenderer>().sprite = canSprite[canSize];
        canColor = canSize;
    }

    public void Gone() {
        Destroy(gameObject);
    }

    //void Update()
    //{
    //    Collider2D[] isRain = Physics2D.OverlapCircleAll(transform.position, canRadius, whatIsRain);
    //    for (int i = 0; i < isRain.Length; i++) {
    //        isRain[i].GetComponent<Rain>().PickUpCan(1);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == whatIsRain)
        {
            //int [] info = { canColor, canSize };
            //col.gameObject.SendMessage("PickUpCan", info, SendMessageOptions.DontRequireReceiver);
            Debug.Log("gotCan");
            col.gameObject.SendMessage("PickUpCan", canColor, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
