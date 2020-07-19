using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicMenager musicMenager;

	void Start () {
        musicMenager = GameObject.FindObjectOfType<MusicMenager>();
        if (musicMenager){
            float volume = PlayerPrefsMenager.GetMasterVolume();
            musicMenager.ChangeVolume(volume);
        }
        else {
            Debug.LogWarning("No music menager found!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
