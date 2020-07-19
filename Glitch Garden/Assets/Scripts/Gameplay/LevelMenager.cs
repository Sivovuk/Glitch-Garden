using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{

    public float autoLoadNextLevelAfter;

    void Start(){
        if (autoLoadNextLevelAfter == 0){
            //Debug.Log("Autoload disable");
        }
        else{
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name) {
        Application.LoadLevel(name);
    }

    public void QuitRequest() {
        Application.Quit();
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
