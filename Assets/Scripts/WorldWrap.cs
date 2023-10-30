using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrap : MonoBehaviour
{
    private float topBoarder = 8f;
    private float bottomBorder = -8f;
    private float leftBoarder = -4.5f;
    private float rightBoarder = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x; 
        float y = transform.position.y;

        if (x > topBoarder) {
            transform.position = new Vector2(bottomBorder, y);
        }
        if (x < bottomBorder) {
            transform.position = new Vector2(topBoarder, y);
        }
        if (y > rightBoarder) {
            transform.position = new Vector2(x, leftBoarder);
        }
        if (y < leftBoarder) {
            transform.position = new Vector2(x, rightBoarder);
        }
    }
}
