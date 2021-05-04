using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAchievements
{
    private List<ScoreAchievement> _scoreAchievements;
    private List<TotalTilesAchievement> _totalTilesAchievements;
    private List<Achievement> _allAchievements;
    
    public PlayerAchievements()
    {
        CreateScoreAchievements();
        CreateTotalTilesAchievements();
        
        // Must be after the others;
        CreateAllAchievements();
    }

    private void CreateScoreAchievements()
    {
        _scoreAchievements = new List<ScoreAchievement>();

        // (score achieved, achievement points earned)
        (int, int)[] scoresPointsTuples = {(10, 5), (20, 10), (50, 20), (100, 40), (250, 100)};

        for (int i = 0; i < scoresPointsTuples.Length; i++)
        {
            _scoreAchievements.Add(new ScoreAchievement(scoresPointsTuples[i].Item2, scoresPointsTuples[i].Item1));
        }
    }

    private void CreateTotalTilesAchievements()
    {
        _totalTilesAchievements = new List<TotalTilesAchievement>();
        
        // (total tiles destroyed, achievement points)
        (int, int)[] tilesPointsTuples = {(10,5), (20, 10), (50, 25), (100, 50), (200, 100), (500, 250), (1000, 500)};

        for (int i = 0; i < tilesPointsTuples.Length; i++)
        {
            _totalTilesAchievements.Add(new TotalTilesAchievement(tilesPointsTuples[i].Item2, tilesPointsTuples[i].Item1));
        }
    }
    
    public void CreateAllAchievements()
    {
        _allAchievements = new List<Achievement>();
        _allAchievements.AddRange(_scoreAchievements);
        _allAchievements.AddRange(_totalTilesAchievements);
    }

    public int TotalAchievementPoints()
    {
        int points = 0;
        foreach (var achievement in _allAchievements)
        {
            if (achievement.IsAchieved)
            {
                points += achievement.AchievementPoints;
            }
        }
        
        return points;
    }


    public List<ScoreAchievement> ScoreAchievements => _scoreAchievements;
    public List<TotalTilesAchievement> TotalTileAchievements => _totalTilesAchievements;

    public List<Achievement> AllAchievements => _allAchievements;
}