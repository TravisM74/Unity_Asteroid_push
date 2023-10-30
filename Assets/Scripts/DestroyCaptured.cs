using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCaptured : MonoBehaviour
{

    private float xBound = 0.5f;
    private float yBound = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = transform.position.x;
        float y = transform.position.y;
        if (x > -xBound && x < xBound && y > -yBound && y < yBound){
            //AsteroidContoller.RemoveAsteroid(gameObject);
            Destroy(gameObject);
        } 
    }
}
