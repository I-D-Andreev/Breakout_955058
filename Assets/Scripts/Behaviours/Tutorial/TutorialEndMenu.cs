using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using TMPro;
using UnityEngine;

public class TutorialEndMenu : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialEndMenu;
    private ScoreUpdater _scoreUpdater;
    [SerializeField]private TextMeshProUGUI _gameEndScoreTextBox;
    
    private void Awake()
    {
        _scoreUpdater = GameObject.Find("ScoreValue").GetComponent<ScoreUpdater>();
        _gameEndScoreTextBox = _tutorialEndMenu.transform.Find("GameScore").gameObject.GetComponent<TextMeshProUGUI>();
        
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
        Time.timeScale = 0;
        _tutorialEndMenu.SetActive(true);
    }
    
    public void QuitToMenuButtonClicked()
    {
        Time.timeScale = 1;
        SceneLoader.Loader.LoadScene("MainMenu");
    }
}