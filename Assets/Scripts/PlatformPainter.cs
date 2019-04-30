using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformPainter : MonoBehaviour
{
    Tilemap platforms;
    Tilemap paint;
    public Sprite wetPaint;

    // Start is called before the first frame update
    void Start()
    {
        platforms = GetComponent<Tilemap>();
        paint = transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(0).transform.Find("Paint").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        //Debug.Log("Collided with Tilemap");
        if (col.gameObject.tag == "Painter")
        {
            Vector3 painterPos = col.gameObject.GetComponent<Transform>().position;
            //Debug.Log(playerPos);
            Vector3Int pos = platforms.WorldToCell(painterPos);
            pos.y -= 2;
            TileBase tileAtPos = platforms.GetTile(pos);
            if (tileAtPos.ToString().Substring(0, 6) == "floor ")
            {
                //monochrome tile, switch to colored
                Debug.Log("Colored tile at " + painterPos);
                Tile newPaint = new Tile();
                newPaint.sprite = wetPaint;
                //newPaint.color = col.getComponent<Painter>.color;
                newPaint.color = Color.blue;
                paint.SetTile(pos, newPaint);
            }
        }

        else if (col.gameObject.tag == "Enemy")
        {
            /*
            //tell the enemy what's in front of it
            Vector3 enemyPos = col.gameObject.GetComponent<Transform>().position;
            int left = tileAtPosition(enemyPos, false);
            int right = tileAtPosition(enemyPos, true);
            Vector2Int result = new Vector2Int(left, right);
            //Debug.Log(result);
            if (result != null)
            {
                Debug.Log(result);
                col.gameObject.SendMessage("CanMove", result, SendMessageOptions.DontRequireReceiver);
            }
            */
        }
    }
}
