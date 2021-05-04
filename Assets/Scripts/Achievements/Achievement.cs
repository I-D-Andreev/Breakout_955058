using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Achievement
{
    private bool _isAchieved;
    private int _achievementPoints;

    public Achievement(int achievementPoints)
    {
        _isAchieved = false;
        _achievementPoints = achievementPoints;
    }

    public bool IsAchieved => _isAchieved;

    public int AchievementPoints => _achievementPoints;

    public void Achieve()
    {
        _isAchieved = true;
        ShowAchievement();
    }

    private void ShowAchievement()
    {
        AchievementsManager.Manager.ShowAchievement(this);
    }

    public abstract string AchievementEarnedText();
    public abstract string AchievementText();
}
