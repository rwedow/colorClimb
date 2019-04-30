using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCan : MonoBehaviour
{
    // Start is called before the first frame update
    int canSize;
    public Sprite[] canSprite;
    public LayerMask whatIsRain;

    void Start()
    {
        whatIsRain = 10;
        canSize = Random.Range(1, 4);
        Debug.Log(canSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = canSprite[canSize];
        if (canSize < 3) canSize = 1;
        else canSize = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("On layer " + col.gameObject.layer);
        if (col.gameObject.layer == whatIsRain) { 
            col.gameObject.SendMessage("PickUpCan", canSize, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
