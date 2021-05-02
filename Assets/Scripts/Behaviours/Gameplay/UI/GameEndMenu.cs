using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using TMPro;
using UnityEngine;

public class GameEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndMenu;
    private ScoreUpdater _scoreUpdater;
    private TextMeshProUGUI _gameEndScoreTextBox;
    
    private void Awake()
    {
        _scoreUpdater = GameObject.Find("ScoreValue").GetComponent<ScoreUpdater>();
        _gameEndScoreTextBox = _gameEndMenu.transform.Find("GameScore").gameObject.GetComponent<TextMeshProUGUI>();
        
        BottomWallHit.BottomWallHitEvent.AddListener(CheckGameEnd);
    }

    private void CheckGameEnd(GameObject obj)
    {
        if (obj.CompareTag("Ball"))
        {
            ShowMenu();
        }
    }

    private void ShowMenu()
    {
        int score = _scoreUpdater.Score;
        _gameEndScoreTextBox.text = $"Score: {score}";
        _gameEndMenu.SetActive(true);
    }

    public void NewGameButtonClicked()
    {
        SceneLoader.Loader.LoadScene("Gameplay");
    }

    public void QuitToMenuButtonClicked()
    {
        SceneLoader.Loader.LoadScene("MainMenu");
    }
}
