﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBaricade : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
