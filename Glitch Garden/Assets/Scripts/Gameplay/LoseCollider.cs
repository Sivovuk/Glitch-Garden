using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelMenager levelMenager;
    
	void Start () {
        levelMenager = GameObject.FindObjectOfType<LevelMenager>();
	}

    void OnTriggerEnter2D(Collider2D collision){
        levelMenager.LoadLevel("03a Lose");
        //Destroy(collision.gameObject);
    }
}
