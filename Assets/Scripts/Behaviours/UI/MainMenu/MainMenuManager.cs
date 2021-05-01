﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private void Awake()
    {
        _sceneLoader = gameObject.AddComponent<SceneLoader>();
    }

    public void StartGame()
    {
        _sceneLoader.LoadScene("Play");
    }
    
    public void Tutorial()
    {
        Debug.Log("Tutorial");
    }

    public void TopScores()
    {
        Debug.Log("Top Scores");
    }

    public void SwitchProfile()
    {
        Debug.Log("Switch Profile");
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