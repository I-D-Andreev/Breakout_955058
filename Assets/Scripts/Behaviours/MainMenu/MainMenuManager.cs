﻿using System;
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
