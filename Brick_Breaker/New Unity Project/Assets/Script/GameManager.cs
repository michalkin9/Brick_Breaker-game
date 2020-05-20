using System.Collections;
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
    public bool gameOver = false; //is still playing or not
    public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        ScoreText.text = "Score: " + score;
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
    void GameOver()
    {
        gameOver = true; //game is now over
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() //reload the game
    {
        SceneManager.LoadScene("Scenes/main"); //Scenes/main
    }

    public void Quit()
    {
        Application.Quit(); //wont work in the editor. 
        Debug.Log("Game Quit");
    }
}

