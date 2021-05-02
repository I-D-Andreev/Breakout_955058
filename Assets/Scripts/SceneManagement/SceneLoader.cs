using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _classInstance;
    // public static SceneLoader Loader=> _classInstance;
 
    public static SceneLoader Loader
    {
        get
        {
            if (_classInstance == null)
            {
                GameObject gameObj = new GameObject("SceneLoader");
                gameObj.AddComponent<SceneLoader>();
                // - Awake called -
                // where "this" variable is the currently added SceneLoader
            }
            
            return _classInstance;
        }
 
    }

    private void Awake()
    {
        if (_classInstance == null)
        {
            _classInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_classInstance != this)
        {
            Destroy(gameObject);
        }
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
