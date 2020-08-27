using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;

    private float _speed;

    private bool isWalking = true;

    void Update()
    {
        _speed = _walkingSpeed;

        if (isWalking)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
    }

    public void SetWalk() 
    {
        isWalking = true;
    }

    public void SetWait() 
    {
        isWalking = false;
    }

    public void SetRunningSpeed() 
    {
        _speed = _runningSpeed;
    }

    public void SetWalkingSpeed() 
    {
        _speed = _walkingSpeed;
    }
}
