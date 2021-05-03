using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    [SerializeField] private GameObject achievementPrefab;
    
    private static AchievementsManager _classInstance;
    
    public static AchievementsManager Manager
    {
        get
        {
            if (_classInstance == null)
            {
                GameObject gameObj = new GameObject("AchievementsManager");
                gameObj.AddComponent<AchievementsManager>();
                // - Awake called -
            }
            
            return _classInstance;
        }
    }
    
    private void Awake()
    {
        if (_classInstance == null)
        {
            _classInstance = this;
            InitAchievementManager();    
            DontDestroyOnLoad(gameObject);
        }
        else if (_classInstance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitAchievementManager()
    {
        
        ScoreUpdater.ScoreChangeEvent.AddListener(CheckScoreAchievements);
    }

    private void CheckScoreAchievements(int score)
    {
        foreach (ScoreAchievement achievement in Database.GameData.LoggedInProfile.PlayerAchievements.ScoreAchievements)
        {
            achievement.TryAchieve(score);
        }
    }

    public void ShowAchievement(Achievement achievement)
    {
        CanvasGroup canvasGroup = achievementPrefab.GetComponent<CanvasGroup>();
        achievementPrefab.transform.Find("AchievementText").gameObject.GetComponent<TextMeshProUGUI>().text =
            achievement.AchievementText();

        canvasGroup.alpha = 1;
        
        StartCoroutine(FadeAchievement(canvasGroup, 3));
    }

    private IEnumerator FadeAchievement(CanvasGroup canvasGroup, float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }

        yield return null;
    }
}
