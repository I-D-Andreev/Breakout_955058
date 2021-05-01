﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool _isGamePaused = false;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = gameObject.AddComponent<SceneLoader>();
    }

    public void Resume()
    {
        ResumeGame();
    }

    public void QuitToMenu()
    {
        // todo1: take score, recording?, etc
        Time.timeScale = 1;
        _sceneLoader.LoadScene("MainMenu");
    }
  
    public void OnPause(InputValue _)
    {
        if (_isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void ResumeGame()
    {
        menu.SetActive(false);
        _isGamePaused = false;
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        _isGamePaused = true;
    }
}