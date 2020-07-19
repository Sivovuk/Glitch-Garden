using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject[] spawners;
    public List<int> check = new List<int>();
    public int time = 5;

    void Start()
    {
        for(int i = 0; i < spawners.Length; i++) {
            spawners[i].GetComponent<Spawner>().spawnTime = check[i];
        }
    }

    void Update() {
        if (Time.time >= time ) {
            time += 3;
            print("Promena");
            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].GetComponent<Spawner>().spawnTime = SpawnTimeRandomGeneration();
            }
        }
	}

    public int SpawnTimeRandomGeneration() {
        int random = Random.Range(5, 10);
        for (int i = 0; i <= check.Count; i++)
        {
            if (check[i] == random)
            {
                return SpawnTimeRandomGeneration();
            }
            else
            {
                print(random);
                check[i] = random;
                return random;
            }
        }
        return random;
    }
}
