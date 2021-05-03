using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private ScoreUpdater _scoreUpdater;
    
    private void Awake()
    {
        _scoreUpdater = GameObject.Find("ScoreValue").GetComponent<ScoreUpdater>();
        BottomWallHit.BottomWallHitEvent.AddListener(CheckGameEnd);
    }
    
    private void CheckGameEnd(GameObject obj)
    {
        if (obj.CompareTag("Ball"))
        {
            GameChangeMonitor.SaveAndMakeGameChange(new BallDestroyChange(Time.timeSinceLevelLoad), obj);
            
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
