using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private void Awake()
    {
        _sceneLoader = gameObject.AddComponent<SceneLoader>();
    }

    public void BackToMainMenu()
    {
        _sceneLoader.LoadScene("MainMenu");
    }
}
