using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBaricade : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _effect;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) 
        {
            GameObject spawn = Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(spawn, 2);

            Destroy(gameObject);
        }
    }
}
