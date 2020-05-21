using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit button pushed");
    }

    public void StartGame()
    {
          SceneManager.LoadScene("Scenes/main"); //Scenes/main
    }
}
