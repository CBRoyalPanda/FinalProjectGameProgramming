using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    // The scene is changed to the game state when function is called
    public void changemenuscene()
    {
        SceneManager.LoadScene("LevelOne");
    }
    // The application exists when this function is called
    public void StopPlaying()
    {
        Application.Quit();
    }
}
