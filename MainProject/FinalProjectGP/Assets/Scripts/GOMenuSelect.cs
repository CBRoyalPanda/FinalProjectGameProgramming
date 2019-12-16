using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOMenuSelect : MonoBehaviour
{
    // The scene changes to the game state when this function is called
    public void RetryOption()
    {
        SceneManager.LoadScene("LevelOne");
    }

    // The scene changes to the Main Menu when this function is called
    public void MainMenuOption()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
