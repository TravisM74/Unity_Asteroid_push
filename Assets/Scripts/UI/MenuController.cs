using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    private void Start() {
        
    }
    public void StartGame(){
        Debug.Log("Starts the game");
        GameManager.Instance.Go(GameStateBase.Type.Level);

   }
   public void ToOptions(){
        Debug.Log("GoTo Options");
        GameManager.Instance.Go(GameStateBase.Type.Options);
   }

   public void Quit(){
        Application.Quit();
   }
}
