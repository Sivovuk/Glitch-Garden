using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public const string SCORE_KEY = "score";

    private int _score;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private EnemySpawner _enemySpawner;

    private static ScoreManager instance;

    public static ScoreManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") 
        {
            _scoreText.text ="Score : " + PlayerPrefs.GetInt(SCORE_KEY).ToString();
        }
    }

    public void AddScore(int amount) 
    {
        _score += amount;
        _scoreText.text ="Score : " + _score.ToString();

        if (_score % 100 == 0) 
        {
            _enemySpawner.SpeedUpGame();
        }
    }

    public bool SaveScoreCheck() 
    {
        if (PlayerPrefs.GetInt(SCORE_KEY) < _score)
        {
            PlayerPrefs.SetInt(SCORE_KEY, _score);
            return true;
        }
        else return false;
    }

    public void SaveScore()
    {
        if (PlayerPrefs.GetInt(SCORE_KEY) < _score)
        {
            PlayerPrefs.SetInt(SCORE_KEY, _score);
        }
    }

    public int LoadScore() 
    {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }

    public int GetScore() 
    {
        return _score;
    }
}
