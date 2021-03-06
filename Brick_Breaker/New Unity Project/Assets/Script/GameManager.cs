﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for the text(cause ui)
using UnityEngine.SceneManagement; // gives access to scene maeagmant 

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text ScoreText;
    public Text highScoreText;

    public bool gameOver = false; //is still playing or not
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberOfBricks;
    public Transform[] levels; // contains all levels of the game 
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        ScoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        // check for no lives left and trigger the end of the game
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;
        ScoreText.text = "Score: " + score;

    }

    public void upDateNumberOfBricks()
    {
        numberOfBricks--; 
        if(numberOfBricks <= 0)
        {
         if(currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            } else //if we have more levels to load
            {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level" + (currentLevelIndex + 2);
                gameOver = true;
                Invoke("loadLevel", 3f);
            }
           
        }
    }

    void loadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }
   
    void GameOver()
    {
        gameOver = true; //game is now over
        gameOverPanel.SetActive(true);
        int HighScore = PlayerPrefs.GetInt("HIGHSCORE");
        if( score > HighScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoreText.text = "New High Score! " + score;
        }
        else
        {
            highScoreText.text = "High score: " + HighScore + "\n" + "Can you beat it?";
        }
    }

    public void PlayAgain() //reload the game
    {
        SceneManager.LoadScene("Scenes/main"); //Scenes/main
    }

    public void Quit()
    {
        SceneManager.LoadScene("Scenes/Start Menu"); //go back to start menu

    }
}

