using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float shipRotation = 0f;

    private float thrust = 0;
    [SerializeField] private float thrustPower = 1000f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private GameObject playBoard;
    private float topBoarder = 8f;
    private float bottomBorder = -8f;
    private float leftBoarder = -4.5f;
    private float rightBoarder = 4.5f;

  
    private Rigidbody2D rb2D;


    private void Awake() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update() {
        ReadInput();
        MovementControl();
        BoarderBoundsCheck();

    }

    private void Setup() {

        float height = playBoard.transform.localScale.y;
        float width = playBoard.transform.localScale.x;
        Debug.Log(height+ " : " +width);
        topBoarder = 8f;
        bottomBorder = -8f;
        leftBoarder = -4.5f;
        rightBoarder = 4.5f;

}

    private void BoarderBoundsCheck() {
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

    private void MovementControl() {

        if (thrust > 0) {
            rb2D.AddForce(transform.right * thrust * thrustPower * 2);
        }
        if (thrust < 0) {
            rb2D.AddForce(transform.right * thrust * thrustPower);

        }
        //Debug.Log(thrust);
        rb2D.rotation -= shipRotation * rotationSpeed * Time.deltaTime;
    }

    private void ReadInput() {
        // Read input from player
        shipRotation += Input.GetAxis("Horizontal");
          
        thrust = Input.GetAxis("Vertical");
           
    }
}
