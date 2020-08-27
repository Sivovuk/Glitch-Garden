using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _stars;
    [SerializeField] private int _lives;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _menuBtn;
    [SerializeField] private GameObject _resumeBtn;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _endGameText;
    [SerializeField] private TextMeshProUGUI _starsText;
    [SerializeField] private TextMeshProUGUI _livesText;

    [SerializeField] private EnemySpawner _enemySpawner;

    private static GameManager instance;

    public static GameManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        _starsText.text = _stars.ToString();

        yield return new WaitForSeconds(12);

        _enemySpawner.enabled = true;
    }

    #region Stars
    public void AddStars(int amount) 
    {
        _stars += amount;
        _starsText.text = _stars.ToString();
    }

    public bool CheckForStars(int amount) 
    {
        if (_stars >= amount)
        {
            return true;
        }

        else return false;
    }

    public void UseStars(int amount) 
    {
        _stars -= amount; 
        _starsText.text = _stars.ToString();
    }
    #endregion

    #region Lives
    public void TakeLife() 
    {
        _lives--;
        _livesText.text = "Lives \n" + _lives.ToString();

        if (_lives <= 0) 
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManagerScript.Instance.PauseGame();
        _menu.SetActive(true);
        _menuBtn.SetActive(false);
        _resumeBtn.SetActive(false);
        _scoreText.text = ScoreManager.Instance.GetScore().ToString();

        bool check = ScoreManager.Instance.SaveScoreCheck();
        if (check)
        {
            _endGameText.text = "Congrats! You set a new highscore!";
        }
        else
        {
            _endGameText.text = "Sorry! You didn't set a new highscore! Lets try again?";
        }

        AudioManager.Instance.PlayAudio(AudioManager.Instance.questSound);
    }
    #endregion
}
