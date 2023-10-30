using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Current {
        get;
        private set;
    }

    private void Start() {
        Current = this;


        //setup and start moved from gamemanager (AsteroidController)
        // LevelController.Current.CreateAsteroid();
    }

}
