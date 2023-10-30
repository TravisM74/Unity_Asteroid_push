using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float shipRotation = 0f;
    public  float fuel {
        get;
        set;   
    } 
    private float idleConsumption = 0.1f;
    private float thrust = 0;
    private float thrustPower = 10000f;
    private float rotationPower = 150f;
    public bool gameOver { 
        get;
        private set;
    }

    // roataion speed usind in original turning method
    // private float rotationSpeed = 5f;
    private GameObject playBoard;
  

  
    private Rigidbody2D rb2D;


    private void Awake() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        fuel = 500;
    }
    public void Reset() {
        fuel = 500;
    }
    // Update is called once per frame
    void Update() {
        ReadInput();
        MovementControl();
        FuelLevel();

    }

    private void FuelLevel() {
        Debug.Log(fuel);
        if (fuel < 0) {
            gameOver = true;
            GameManager.Instance.Go(GameStateBase.Type.GameOver);
        }
    }


    private void MovementControl() {

        if (thrust > 0) {
            rb2D.AddForce(transform.right *  thrustPower * 2 * Time.deltaTime);
            fuel -= thrust  * 2 * Time.deltaTime;
        }
        if (thrust < 0) {
            rb2D.AddForce(transform.right * thrust * thrustPower * Time.deltaTime);
            fuel += thrust  * Time.deltaTime;

        }
        fuel -= idleConsumption * Time.deltaTime;
        //Debug.Log(thrust);
        // rb2D.rotation -= shipRotation * rotationSpeed * Time.deltaTime;
       
        float rotationalThrust = -shipRotation * rotationPower * Time.deltaTime;
        //Debug.Log(rotationalThrust);
        // converted to torque on rigid body rotation
        rb2D.AddTorque(rotationalThrust, ForceMode2D.Impulse);
    }

    private void ReadInput() {
        // Read input from player
        shipRotation = Input.GetAxis("Horizontal");
          
        thrust = Input.GetAxis("Vertical");
           
    }
}
