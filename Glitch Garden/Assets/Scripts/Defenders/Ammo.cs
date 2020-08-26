using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            collision.GetComponent<IDamageable>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
