using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReplayEndMenu : MonoBehaviour
{
    private TextMeshProUGUI _scoreValueBox;
    
    private GameObject _newHighScore;
    private TextMeshProUGUI _scoreBox;
    
    private void Awake()
    {
        _scoreValueBox = GameObject.Find("ScoreValue").GetComponent<TextMeshProUGUI>();
        _newHighScore = gameObject.transform.Find("NewHighScore").gameObject;
        _scoreBox = gameObject.transform.Find("GameScore").gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _newHighScore.SetActive(CurrentReplayData.IsNewHighScore);
        _scoreBox.text = $"Score: {_scoreValueBox.text}";
    }

    public void BackToMenuClicked()
    {
        SceneLoader.Loader.LoadScene("MainMenu");
    }
}
