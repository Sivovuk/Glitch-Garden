using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProduction : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    [SerializeField] private float _prodactionSpeed;
    private float _timePass;

    [SerializeField] private GameObject _star;
    [SerializeField] private Transform _starPoint;
    [SerializeField] private GameObject _effect;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        _timePass += Time.deltaTime;

        if (_timePass >= _prodactionSpeed) 
        {
            _timePass = 0;

            _animator.SetTrigger("isMaking");

            SpawnStar();
        }
    }

    public void SpawnStar() 
    {
        GameObject spawn = Instantiate(_star, _starPoint.localPosition, Quaternion.identity, transform);
        Destroy(spawn, 2);
        GameManager.Instance.AddStars(10);
    }

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
