using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplayButton : MonoBehaviour
{
    // Assigned by RenderScores when Instantiating the Prefab.
    public List<GameChange> GameChanges = new List<GameChange>();
    
    public void ReplayClicked()
    {
        CurrentReplayData.ReplayData = GameChanges;
        CurrentReplayData.IsNewHighScore = true;
        SceneLoader.Loader.LoadScene("GameReplay");
    }
}
