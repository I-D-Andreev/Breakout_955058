using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneLoader.Loader.LoadSceneFade("Gameplay");
    }
    
    public void Tutorial()
    {
        SceneLoader.Loader.LoadSceneFade("Tutorial");
    }

    public void TopScores()
    {
        SceneLoader.Loader.LoadSceneFade("Scores");
    }

    public void Achievements()
    {
        SceneLoader.Loader.LoadSceneFade("Achievements");
    }

    public void SwitchProfile()
    {
        SceneLoader.Loader.LoadSceneFade("ChooseProfile");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
