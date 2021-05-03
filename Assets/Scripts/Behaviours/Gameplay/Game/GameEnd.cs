using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private ScoreUpdater _scoreUpdater;
    private GameChangeMonitor _gameChangeMonitor;
    
    private void Awake()
    {
        _scoreUpdater = GameObject.Find("ScoreValue").GetComponent<ScoreUpdater>();
        _gameChangeMonitor = new GameChangeMonitor();
        BottomWallHit.BottomWallHitEvent.AddListener(CheckGameEnd);
    }
    
    private void CheckGameEnd(GameObject obj)
    {
        if (obj.CompareTag("Ball"))
        {
            _gameChangeMonitor.SaveAndMakeGameChange(new BallDestroyChange(Time.timeSinceLevelLoad), obj);
            
            UpdateGameData();
        }
    }

    private void UpdateGameData()
    {
        CurrentReplayData.ReplayData = GameChangeMonitor.GameChanges;
        CurrentReplayData.IsNewHighScore = Database.GameData.IsNewHighScore(_scoreUpdater.Score);

        Database.GameData.LoggedInProfile.EndedGame(_scoreUpdater.Score, GameChangeMonitor.GameChanges);
        GameChangeMonitor.NullifyGameChangeData();
    }
}
