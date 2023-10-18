using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileController : MonoBehaviour
{

   
    private Timer hostileTimer;
    public GameObject hotsilePrefab;
    private GameObject hostile;
    private List<GameObject> hostiles = new List<GameObject>();
    public float timeBetweenHostiles = 25.0f;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        TimedEvents();

    }

    private void Awake() {
       
        hostileTimer = gameObject.AddComponent<Timer>();
        SetTimer();
    }

    private void SetTimer() {
       
        hostileTimer.Set(timeBetweenHostiles);
        hostileTimer.Run();
    }

    private void TimedEvents() {
      
        if (hostileTimer.IsCompleted) {
            CreateHostile();
            SetTimer();
        }
    }


    private void CreateHostile() {
        Debug.Log("create Hostile");
        Vector3 position = new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f), 0);
       //hostile = Instantiate(hostilePrefab, position, Quaternion.identity, transform);
        //hostiles.Add(hostile);
    }

}
