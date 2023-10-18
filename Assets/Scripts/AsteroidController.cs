using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private Timer asteroidTimer;
    private Timer hostileTimer;
    private GameObject asteroid;
    public float timeBetweenAsteroids = 10.0f;
    public float timeBetweenHostiles = 25.0f;


    // Start is called before the first frame update
    void Start()
    {
        CreateAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        TimedEvents();

    }

    private void Awake() {
        asteroidTimer = gameObject.AddComponent<Timer>();
        hostileTimer =  new Timer();
        SetTimer();
    }

    private void SetTimer() {
        asteroidTimer.Set(timeBetweenAsteroids);
        asteroidTimer.Run();
        hostileTimer.Set(timeBetweenHostiles);
        hostileTimer.Run(); 
    }

    private void TimedEvents() {
        if (asteroidTimer.IsCompleted) {
            CreateAsteroid();
            SetTimer();
        }
        if (hostileTimer.IsCompleted) {
            CreateHostile();
            SetTimer();
        }
    }


    private void CreateAsteroid() {
        Debug.Log("Create asteroid");
    }

    private void CreateHostile() {
        Debug.Log("create Hostile");
    }

}
