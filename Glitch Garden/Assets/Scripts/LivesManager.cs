using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            GameManager.Instance.TakeLife();
        }
    }
}
