using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difSlider;
    public LevelMenager levelMenager;

    private MusicMenager musicMenager;

	void Start () {
        musicMenager = GameObject.FindObjectOfType<MusicMenager>();
        volumeSlider.value = PlayerPrefsMenager.GetMasterVolume();
        difSlider.value = PlayerPrefsMenager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicMenager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit() {
        PlayerPrefsMenager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsMenager.SetDifficulty(difSlider.value);
        levelMenager.LoadLevel("01a Start Menu");
    }

    public void SetDefault() {
        volumeSlider.value = 0.8f;
        difSlider.value = 2f;
        Debug.Log("default");
    }
}
