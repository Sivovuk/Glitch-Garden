using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProduction : MonoBehaviour
{
    [SerializeField] private float _prodactionSpeed;
    private float _timePass;

    [SerializeField] private GameObject _star;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _prodactionSpeed += Time.deltaTime;

        if (_timePass >= _prodactionSpeed) 
        {
            _prodactionSpeed = 0;
            SpawnStar();
        }
    }

    public void SpawnStar() 
    {
        GameObject spawn = Instantiate(_star, transform.position, Quaternion.identity);
        Destroy(spawn, 2);
        GameManager.insa
    }
}
