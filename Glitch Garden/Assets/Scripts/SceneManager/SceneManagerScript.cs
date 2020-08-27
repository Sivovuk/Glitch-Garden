using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    private static SceneManagerScript instance;

    public static SceneManagerScript Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
    }
}
