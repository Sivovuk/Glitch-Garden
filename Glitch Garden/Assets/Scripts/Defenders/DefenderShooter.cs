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
    [SerializeField] private GameObject _laneSpawnPoint;
    [SerializeField] private GameObject _effect;

    private Animator _animator;

    void Start()
    {
        _laneSpawnPoint = GameObject.Find("Point"+transform.localPosition.y);
        _animator = GetComponent<Animator>();
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
            _animator.SetBool("isAttacking", true);
        }
        else 
        {
            isAttacking = false;
            _animator.SetBool("isAttacking", false);
        }
    }

    private void Shoot() 
    {
        Instantiate(_ammo, _shootPoint.position, Quaternion.identity) ;
    }

    public void TakeDamage(int damage)
    {
        Debug.LogError(damage);
        _health -= damage;

        if (_health <= 0) 
        {
            GameObject spawn = Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(spawn, 2);

            Destroy(gameObject);
        }
    }
}
