using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private Timer asteroidTimer;
    private GameObject asteroid;
    [SerializeField] private GameObject playBoard;
    public GameObject asteroidPrefab;
    private List<GameObject> asteroids = new List<GameObject>();
    public float timeBetweenAsteroids = 10.0f;
    public float timeBetweenHostiles = 25.0f;

    private float spawnRangeX = 7f;
    private float spawnRangeY = 3f;
    public GameObject capturePoint;
    private float xBound = 0.5f;
    private float yBound = 0.5f;
    public int numberOfAsteroids = 1;

    public int score { get;
            set; } 

    

 


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        CreateAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        // TimedEvents();
        CheckAsteroidCapture();


        if (asteroids.Count == 0){
            // TODO Next Wave Window Scene added 

            numberOfAsteroids++;
            for (int i = 0; i < numberOfAsteroids; i++){
                CreateAsteroid();
            }
        }

    }
    private void Awake() {
        asteroidTimer = gameObject.AddComponent<Timer>();
     
        SetTimer();
    }

    public void Reset(){
        asteroids.Clear();
        numberOfAsteroids = 1;
        score = 0;
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

        Vector3 position = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0);
        asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity, transform);
        asteroids.Add(asteroid);
    }

    private void CheckAsteroidCapture(){
        foreach (GameObject asteroid in asteroids){
            float x = asteroid.transform.position.x;
            float y = asteroid.transform.position.y;
            if (x > -xBound && x < xBound && y > -yBound && y < yBound){
                asteroids.Remove(asteroid);
                Debug.Log("Remove asteroid from list ");

                Destroy(asteroid);
                Debug.Log("Destroy asteroid Object");
                score++;

            } 
        }
        
    }


}
