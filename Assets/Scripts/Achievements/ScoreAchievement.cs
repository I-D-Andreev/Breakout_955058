﻿using System.Collections;
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

    public override string AchievementEarnedText()
    {
        return $"You achieved a score of {_scoreNeeded}!\nYou earned +{AchievementPoints} points!";
    }

    public override string AchievementText()
    {
        return $"Achieve a score of {_scoreNeeded}";
    }

    public void TryAchieve(int score)
    {
        if (!IsAchieved && score >= _scoreNeeded)
        {
            Achieve();
        }
    }
}
