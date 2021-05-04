using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TotalTilesAchievement: Achievement
{
    private int _tilesNeeded;

    public TotalTilesAchievement(int achievementPoints, int tilesNeeded) : base(achievementPoints)
    {
        _tilesNeeded = tilesNeeded;
    }

    public override string AchievementEarnedText()
    {
        return $"You destroyed a total of {_tilesNeeded} tiles!\nYou earned +{AchievementPoints} points!";

    }

    public override string AchievementText()
    {
        return $"Destroy a total of {_tilesNeeded} tiles";
    }

    public void TryAchieve(int tiles)
    {
        if (!IsAchieved && tiles >= _tilesNeeded)
        {
            Achieve();
        }
    }
}
