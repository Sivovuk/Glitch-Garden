using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    [SerializeField] private float _timePass;
    [SerializeField] private float _attackSpeed;

    private bool isAttacking = false;

    [SerializeField] private GameObject _ammo;
    [SerializeField] private Transform _shootPoint;
    public GameObject _laneSpawnPoint;

    void Start()
    {
        _laneSpawnPoint = GameObject.Find("Point"+transform.localPosition.y);
    }


    void Update()
    {
        if (isAttacking) 
        {
            _timePass += Time.deltaTime;

            if (_timePass >= _attackSpeed) 
            {
                _timePass = 0;
                Shoot();
            }
        }

        if (_laneSpawnPoint != null && _laneSpawnPoint.transform.childCount > 0)
        {
            isAttacking = true;
        }
        else 
        {
            isAttacking = false;
        }
    }

    private void Shoot() 
    {
        Instantiate(_ammo, _shootPoint.position, Quaternion.identity) ;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
