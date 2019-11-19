using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] public  float gameSpeed = 1f;
    public int pointsPerBlocks = 83;
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) // singleton pattern
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlocks;
        scoreText.text = currentScore.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}