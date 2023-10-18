using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour, ITimer
{

    private float time;
    private float startTime;
    public bool IsCompleted {
        get {
            if (this.time <= 0) {
                this.time = 0;
                return true;
            }
            return false;
        }
    }

    public bool IsRunning {
        get; private set;
    }

    private void Update() {
        if (IsRunning) {
            this.time -= Time.deltaTime;
            if (IsCompleted) {
                Stop();
            }
        }
    }

    public void Reset() {
        Stop();
        this.time = this.startTime;
    }

    public void Run() {
        IsRunning = true;
    }

    public void Set(float time) {
       this.time = time;
       this.startTime = time;
       Stop();

    }

    public void Stop() {
        IsRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsRunning = true;  
    }

    
}
