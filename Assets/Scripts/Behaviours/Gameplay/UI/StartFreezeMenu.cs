using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class StartFreezeMenu : MonoBehaviour
{
    [SerializeField] private GameObject freezeMenu;
    private bool _gameStopped;
    
    private void Awake()
    {
        StopGame();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        freezeMenu.SetActive(true);
        _gameStopped = true;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        freezeMenu.SetActive(false);
    }
    
    public void OnSpace(InputValue _)
    {
        if (_gameStopped)
        {
            StartGame();
        }
    }
}
