using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start the game, go to the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Arena");
    }

    // Quit the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Changing to settings or go back to menu
    public void GoToSettingMenu() 
    {
        SceneManager.LoadScene("SettingMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
