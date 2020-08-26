using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnSpeed;

    private bool spawn = true;

    [SerializeField] private GameObject _prefab;
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

        GameObject spawn = Instantiate(_prefab, spawnPoints[random].transform.position, Quaternion.identity);
        spawn.transform.parent = spawnPoints[random];
    }
}
