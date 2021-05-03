using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreAchievement : Achievement
{
    private int _scoreNeeded;

    public ScoreAchievement(int achievementPoints, int scoreNeeded) : base(achievementPoints)
    {
        _scoreNeeded = scoreNeeded;
    }

    public override string AchievementText()
    {
        return $"Achieved a score of {_scoreNeeded}!\nYou earned +{AchievementPoints} points!";
    }

    public void TryAchieve(int score)
    {
        if (!IsAchieved && score >= _scoreNeeded)
        {
            Achieve();
        }
    }
}
