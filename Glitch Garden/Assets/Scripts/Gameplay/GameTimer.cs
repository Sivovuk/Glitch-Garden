using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds;
        
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelMenager levelMenager;
    private GameObject winLable;
    
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelMenager = GameObject.FindObjectOfType<LevelMenager>();
        FindYouWin();
        winLable.SetActive(false);
    }

    void FindYouWin() {
        winLable = GameObject.Find("You Win");
        if (!winLable)
        {
            Debug.LogWarning("Please create you win object!");
        }
    }
	
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
            audioSource.Play();
            winLable.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
	}

    void LoadNextLevel() {
        levelMenager.LoadNextLevel();
    }

}
