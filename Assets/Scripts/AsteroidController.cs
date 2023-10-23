using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private Timer asteroidTimer;
    private Timer hostileTimer;
    private GameObject asteroid;
    [SerializeField] private GameObject playBoard;
    public GameObject asteroidPrefab;
    private List<GameObject> asteroids = new List<GameObject>();
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
        RotationUpdate();

    }
    private void Awake() {
        asteroidTimer = gameObject.AddComponent<Timer>();
     
        SetTimer();
    }

    private void SetTimer() {
        asteroidTimer.Set(timeBetweenAsteroids);
        asteroidTimer.Run();
       
    }

    private void TimedEvents() {
        if (asteroidTimer.IsCompleted) {
            CreateAsteroid();
            SetTimer();
        }
      
    }


    private void CreateAsteroid() {
        Debug.Log("Create asteroid");

        Vector3 position = new Vector3(Random.Range(8f, -8f), Random.Range(4.5f, -4.5f), 0);
        asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity, transform);
        asteroids.Add(asteroid);
    }

    private void RotationUpdate() {
       foreach(GameObject asteroid in asteroids) {
            RotateAsteroid(asteroid);
        }
       
    }


    private void RotateAsteroid(GameObject asteroid) {
        asteroid.transform.Rotate(0, 0, 0.1f);
    }

}
