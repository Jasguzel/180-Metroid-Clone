using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Guzeldere, Jasmine
 * 11/12/2025
 * Manages the end screen
 */
public class EndScreen : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
    /// 
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// Changes the current scene to the scene with a matching index
    /// </summary>
    /// <param name="sceneIndex">The Index of the scene to switch to</param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
