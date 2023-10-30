using UnityEngine;

public class asteroid : MonoBehaviour
{

    private Rigidbody2D rb;


    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup() {
        // give the asteroid a random spin direction.
        rb.AddTorque(Random.Range(-1200,1200), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
