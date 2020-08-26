using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardManager : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _attackSpeed;

    private float _timePass;

    private bool isAttacking = false;

    [SerializeField] private GameObject _target;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private Animator _animator;

    void Start()
    {
        
    }

    void Update()
    {
        if (isAttacking) 
        {
            _timePass += Time.deltaTime;
            if (_timePass >= _attackSpeed) 
            {
                _target.GetComponent<IDamageable>().TakeDamage(_damage);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            _movementController.SetWait();
            _animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _movementController.SetWalk();
            _animator.SetBool("isAttacking", false);
        }
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
