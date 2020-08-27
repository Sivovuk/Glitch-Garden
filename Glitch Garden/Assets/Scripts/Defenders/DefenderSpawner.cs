using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private int _selectedDefenderIndex;

    [SerializeField] private Animator _starWarning;
    [SerializeField] private GameObject _selectedDefender;
    [SerializeField] private List<GameObject> defenders = new List<GameObject>();
    [SerializeField] private List<int> prices = new List<int>();

    private bool isAllowedTOBuild = false;

    private void OnMouseDown()
    {
        if (_selectedDefender != null) 
        {
            SpawnDefender();
        }
    }

    private void SpawnDefender() 
    {
        if (GameManager.Instance.CheckForStars(prices[_selectedDefenderIndex]))
        {
            isAllowedTOBuild = true;
        }

        if (isAllowedTOBuild)
        {
            GameManager.Instance.UseStars(prices[_selectedDefenderIndex]);

            Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            spawnPosition = SnapToGrid(spawnPosition);

            GameObject spawn = Instantiate(_selectedDefender, spawnPosition, Quaternion.identity, transform);

            isAllowedTOBuild = false;
        }
        else 
        {
            _starWarning.Play("Warning");
        }
    }

    public Vector2 SnapToGrid(Vector2 mousePos) 
    {
        float x = Mathf.RoundToInt(mousePos.x);
        float y = Mathf.RoundToInt(mousePos.y);
        return new Vector2(x,y);
    }

    public void SelectDefender(int index) 
    {
        _selectedDefender = defenders[index];
        _selectedDefenderIndex = index;
        
    }
}
