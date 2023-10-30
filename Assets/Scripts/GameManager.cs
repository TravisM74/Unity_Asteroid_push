using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance {
        get {
            if (instance == null) {
                GameManager prefab = Resources.Load<GameManager>("GameManager");
                if (prefab == null) {
                    Debug.LogError(" cant find a prefab for singelton game manager from resources");
                    return null;
                }
                instance = Instantiate(prefab);
            }
            return instance;
        }
    }

    private void Awake() {
                
        gameStates.Add(new MenuState());
        gameStates.Add(new OptionsState());
        gameStates.Add(new GameOverState());

        // TODO: Only one level at this moment add support for multiuple Levels.
        gameStates.Add(new LevelState(1));

        foreach(GameStateBase state in gameStates) {
            if (GameStateBase.IsCurrentScene(state.SceneName)) {
                // Activates the State for the scene we are currently in
                CurrentState = state;
                CurrentState.Activate();
                break;
            }
        }
    }

    public PlayerController Player {
        get;
        private set;
    }
    public AsteroidController Asteroids {
        get;
        private set;
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerController>();
        Asteroids = GameObject.FindObjectOfType<AsteroidController>();

        Player.Reset();
        Asteroids.Reset();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Reset() {
        
    }



    public GameStateBase CurrentState { 
        get; 
        private set; 
    }

    private List<GameStateBase> gameStates = new List<GameStateBase>();
    


    public bool Go(GameStateBase.Type targetStateType) {
        if (!CurrentState.IsValidTargetState(targetStateType)) {
            return false;
        }
        GameStateBase nextState = GetStateByType(targetStateType);
        if (nextState == null) {
             return false; // A state for the targetstateType could not be found
        }
        CurrentState.Deactivate(); // Deactivates the current state
        CurrentState = nextState;
        CurrentState.Activate(); // activate the next state
        return true;

    }

    private GameStateBase GetStateByType(GameStateBase.Type stateType) { 
        foreach(GameStateBase state in gameStates) {
            if (state.StateType == stateType) {
                return state;
            }
        }
        return null;
    }
}
