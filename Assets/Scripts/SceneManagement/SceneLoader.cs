using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image blackImg;
    public Animator animator;
    
    private static SceneLoader _classInstance;
    private static readonly int Fade = Animator.StringToHash("FadeOut");

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

    public void LoadSceneFade(string sceneName)
    {
        StartCoroutine(FadeLoad(sceneName));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator FadeLoad(string sceneName)
    {
        blackImg.color = new Color(0, 0, 0, 0);
        blackImg.gameObject.SetActive(true);
        yield return new WaitUntil(() => blackImg.color.a  == 1);
        StartCoroutine(LoadSceneAsync(sceneName));

    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        blackImg.gameObject.SetActive(false);
    }
}
