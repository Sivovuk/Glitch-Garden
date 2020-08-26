using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed;

    private bool isWalking = false;

    void Update()
    {
        if (isWalking)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _walkingSpeed);
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
}
