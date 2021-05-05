using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    private static AchievementsManager _classInstance;
    public static bool ShouldMonitor = false;

    [SerializeField] private GameObject achievementPrefab;
    
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
        TileBehaviour.TileDestroyEvent.AddListener(CheckTotalTilesAchievements);
    }

    private void CheckScoreAchievements(int score)
    {
        if (ShouldMonitor)
        {
            foreach (ScoreAchievement achievement in GetLoggedInProfile().PlayerAchievements.ScoreAchievements)
            {
                achievement.TryAchieve(score);
            }
        }
    }

    private void CheckTotalTilesAchievements(TileBehaviour _)
    {
        if (ShouldMonitor)
        {
            GetLoggedInProfile().TotalTilesDestroyed++;
            foreach (TotalTilesAchievement achievement in GetLoggedInProfile().PlayerAchievements.TotalTileAchievements)
            {
                achievement.TryAchieve(GetLoggedInProfile().TotalTilesDestroyed);
            }
        }
    }

    public void ShowAchievement(Achievement achievement)
    {
        CanvasGroup canvasGroup = achievementPrefab.GetComponent<CanvasGroup>();
        achievementPrefab.transform.Find("AchievementText").gameObject.GetComponent<TextMeshProUGUI>().text =
            achievement.AchievementEarnedText();

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

    private PlayerProfile GetLoggedInProfile()
    {
        return Database.GameData.LoggedInProfile;
    }
}
