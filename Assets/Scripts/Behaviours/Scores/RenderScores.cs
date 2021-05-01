using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenderScores : MonoBehaviour
{
    [SerializeField] private GameObject scoreRowPrefab;
    private GameObject _scoresHolder;

    private void Awake()
    {
        _scoresHolder = gameObject;
        RenderTop10();
    }

    private void RenderTop10()
    {
        for (var i = 1; i <= 10; i++)
        {
            RenderScoresRow(i, "Peter", (10 - i) * 10);
        }
    }

    private void RenderScoresRow(int rank, string playerName, int score)
    {
        GameObject row = Instantiate(scoreRowPrefab, _scoresHolder.transform);

        row.transform.Find("rank").GetComponent<TextMeshProUGUI>().text = $"{rank}.";
        row.transform.Find("name").GetComponent<TextMeshProUGUI>().text = playerName;
        row.transform.Find("score").GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}