using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _stars;

    [SerializeField] private TextMeshProUGUI _starsText;


    void Start()
    {
        _starsText.text = _stars.ToString();
    }

    public void AddStars(int amount) 
    {
        _stars += amount;
        _starsText.text = _stars.ToString();
    }
}
