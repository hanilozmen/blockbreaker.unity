using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentScene;

    public void LoadStart()
    {
        FindObjectOfType<GameStatus>().Destroy();
        currentScene = 0;
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadPreviousScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadGameOver()
    {
        currentScene = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(currentScene);
    }
}