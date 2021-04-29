using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreUpdateListener : MonoBehaviour
{   
    private TMP_Text _scoreText;
    private int _score;     // use a second variable, so we don't have to convert strings to numbers often 
    
    void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        Score = 0;
        
        TileBehaviour2D.TileDestroyEvent.AddListener(UpdateScore);
    }

    private void UpdateScore(int points)
    {
        Score += points;
    }

    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreText.text = _score.ToString();
        }
    }
}
