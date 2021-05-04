using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenderAchievements : MonoBehaviour
{
    [SerializeField] private GameObject achievementRow;
    private void Awake()
    {
        foreach (var achievement in Database.GameData.LoggedInProfile.PlayerAchievements.AllAchievements)
        {
            CreateAchievementRow(achievement.AchievementText(), achievement.AchievementPoints, achievement.IsAchieved);
        }
    }

    private void CreateAchievementRow(string text, int points, bool isAchieved)
    {
        GameObject row = Instantiate(achievementRow, achievementRow.transform);
        row.transform.SetParent(gameObject.transform);

        row.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = text;
        row.transform.Find("Points").GetComponent<TextMeshProUGUI>().text = points.ToString();
        row.GetComponent<Image>().color = isAchieved ? Color.green : Color.red;
        row.SetActive(true);
    }
}
