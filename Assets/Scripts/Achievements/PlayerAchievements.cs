using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAchievements
{
    private List<ScoreAchievement> _scoreAchievements;

    public PlayerAchievements()
    {
        CreateScoreAchievements();
    }

    private void CreateScoreAchievements()
    {
        _scoreAchievements = new List<ScoreAchievement>();
        
        int[] scores = {10, 20, 50, 100, 250};
        int[] points = {5, 10, 20, 40, 100};

        for (int i = 0; i < scores.Length; i++)
        {
            _scoreAchievements.Add(new ScoreAchievement(points[i], scores[i]));
        }
    }

    public int TotalAchievementPoints()
    {
        int points = 0;
        foreach (var achievement in _scoreAchievements)
        {
            if (achievement.IsAchieved)
            {
                points += achievement.AchievementPoints;
            }
        }

        return points;
    }
    
    
    public List<ScoreAchievement> ScoreAchievements => _scoreAchievements;
}
