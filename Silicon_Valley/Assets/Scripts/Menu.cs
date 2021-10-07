using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Setup");
    
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");

    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    
    }

    public void SplashLoad()
    {
        SceneManager.LoadScene("WelcomeSplash");

    }
}
