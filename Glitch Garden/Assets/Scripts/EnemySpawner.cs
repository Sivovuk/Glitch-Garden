using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnSpeed;

    private bool spawn = true;

    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    IEnumerator Start()
    {
        while (spawn) 
        {
            yield return new WaitForSeconds(_spawnSpeed);
            SpawnEnemy();
        }
    }

    public void SpawnEnemy() 
    {
        int random = Random.Range(0,5);

        GameObject spawn = Instantiate(prefabs[Random.Range(0, prefabs.Count)], spawnPoints[random].transform.position, Quaternion.identity);
        spawn.transform.parent = spawnPoints[random];
    }

    public void SpeedUpGame() 
    {
        if (_spawnSpeed > 0.5) 
        {
            _spawnSpeed -= 0.25f;
        }
    }
}
