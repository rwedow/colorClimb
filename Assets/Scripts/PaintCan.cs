using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCan : MonoBehaviour
{
    // Start is called before the first frame update
    int canSize;
    public Sprite[] canSprite;

    void Start()
    {

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
        col.gameObject.SendMessage("PickUpCan", canSize, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
