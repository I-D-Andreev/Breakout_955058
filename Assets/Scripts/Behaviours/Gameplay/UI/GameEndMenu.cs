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
    private GameObject _newHighScore;
    
    private void Awake()
    {
        _scoreUpdater = GameObject.Find("ScoreValue").GetComponent<ScoreUpdater>();
        _gameEndScoreTextBox = _gameEndMenu.transform.Find("GameScore").gameObject.GetComponent<TextMeshProUGUI>();
        _newHighScore = _gameEndMenu.transform.Find("NewHighScore").gameObject;
        
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
        _newHighScore.SetActive(Database.GameData.IsNewHighScore(score));
        _gameEndMenu.SetActive(true);
    }

    public void NewGameButtonClicked()
    {
        Time.timeScale = 1;
        SceneLoader.Loader.LoadScene("Gameplay");
    }

    public void ReplayButtonClicked()
    {
        Time.timeScale = 1;
        SceneLoader.Loader.LoadScene("GameReplay");

    }
    public void QuitToMenuButtonClicked()
    {
        Time.timeScale = 1;
        SceneLoader.Loader.LoadScene("MainMenu");
    }
}
