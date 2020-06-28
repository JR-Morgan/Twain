using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{
    /// <summary>
    /// Load next scene in the build index
    /// </summary>
    public void NewGame()
    {
        Debug.Log("Loading new scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Exit the game
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}