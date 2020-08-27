using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _damage;
    [SerializeField] protected int _score;

    [Space]

    [SerializeField] protected float _timePass;
    [SerializeField] protected float _attackSpeed;

    [Space]

    [SerializeField] protected bool isAttacking = false;

    [Space]

    [SerializeField] protected GameObject _target;
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected MovementController _movementController;
    [SerializeField] protected Animator _animator;

    private void Start()
    {
        _timePass = _attackSpeed;
    }

    public virtual void Update()
    {
        if (isAttacking)
        {
            _timePass += Time.deltaTime;
            if (_timePass >= _attackSpeed)
            {
                _timePass = 0;
                _target.GetComponent<IDamageable>().TakeDamage(_damage);
            }
        }
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Gravestone"))
        {
            _target = collision.gameObject;
            _movementController.SetWait();
            _animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Gravestone"))
        {
            _target = null;
            _movementController.SetWalk();
            _animator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            GameObject spawn = Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(spawn, 2);

            ScoreManager.Instance.AddScore(_score);

            Destroy(gameObject);
        }
    }
}
