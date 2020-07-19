using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
    public GameObject bushOnSpawnerLane;
    public float spawnTime;

    void Start () {
        
	}
	
	void Update () {
        foreach (GameObject thisAttacker in attackerPrefabArray) {

            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject myGameObject) {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
        if (myGameObject.name.Equals("Fox")) {
            myGameObject.GetComponent<Animator>().Play("Jump");
        }
        bushOnSpawnerLane.GetComponent<Animator>().Play("Bush 1");
    }

    bool isTimeToSpawn(GameObject attackerGameObject) {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        
        float spawnsPerSecond = 1 / spawnTime;

        if (Time.deltaTime > spawnTime) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float trashold = spawnsPerSecond * Time.deltaTime;

        return (Random.value < trashold) ;
        
    }
}
