using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCan : MonoBehaviour
{
    // Start is called before the first frame update
    int canSize;
    int canColor; // 0 = red 1 = yellow 2 = blue 3 = all
    public Sprite[] canSprite;
    public LayerMask whatIsRain;

    void Start()
    {
        whatIsRain = 10;
        canSize = Random.Range(0, 3);
        //scanSprite = new Sprite[4];
        gameObject.GetComponent<SpriteRenderer>().sprite = canSprite[canSize];
        canColor = canSize;
    }

    void Update()
    {

    }

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
