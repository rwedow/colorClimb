using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject main;
    public GameObject plat1;
    public GameObject plat2;
    public GameObject plat3;
    public GameObject plat4;

    float lastPos;
    int numPlat;

    private void Start()
    {
        lastPos = main.GetComponent<Transform>().position.y + 15.25f;
        numPlat = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.GetComponent<Transform>().position.y > (lastPos + 30.5))
        {
            GameObject newChild = new GameObject();
            if (numPlat % 4 == 0)
            {
                newChild = plat4;
            }
            else if (numPlat % 4 == 1)
            {
                newChild = plat3;
            }
            else if (numPlat % 4 == 2)
            {
                newChild = plat1;
            }
            else if (numPlat % 4 == 3)
            {
                newChild = plat2;
            }
            newChild.transform.parent = transform;
            Vector3 position = new Vector3(0, 30.5f + (15.25f * numPlat), 0);
            newChild.transform.localPosition = position;
            Vector3 scale = new Vector3(2.5f, 2, 1);
            newChild.transform.localScale = scale;
            numPlat++;
            lastPos = main.GetComponent<Transform>().position.y;

        }
    }
}
