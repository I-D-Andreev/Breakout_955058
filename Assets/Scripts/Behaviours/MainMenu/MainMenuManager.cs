using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneLoader.Loader.LoadScene("Gameplay");
    }
    
    public void Tutorial()
    {
        Debug.Log("Tutorial");
    }

    public void TopScores()
    {
        SceneLoader.Loader.LoadScene("Scores");
    }

    public void SwitchProfile()
    {
        SceneLoader.Loader.LoadScene("ChooseProfile");
    }

    public void Credits()
    {
        Debug.Log("Credits");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
