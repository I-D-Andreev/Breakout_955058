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
            Destroy(obj);
            UpdateGameData();
        }
    }

    private void UpdateGameData()
    {
        Database.GameData.LoggedInProfile.EndedGame(_scoreUpdater.Score);
    }
}
