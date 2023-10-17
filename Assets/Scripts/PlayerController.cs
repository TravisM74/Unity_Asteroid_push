using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal = 0;
    private float vertical = 0;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        ReadInput();
        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        transform.position += movement;
       
    }

    private void ReadInput() {
        // Read input from player
        horizontal += Input.GetAxis("Horizontal");
        vertical += Input.GetAxis("Vertical");
    }
}
