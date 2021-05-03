using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class ScoreChangeEvent : UnityEvent<int>
{
}

[RequireComponent(typeof(TMP_Text))]
public class ScoreUpdater : MonoBehaviour
{
    public static ScoreChangeEvent ScoreChangeEvent = new ScoreChangeEvent();
    private TMP_Text _scoreText;
    private int _score;     // use a second variable, so we don't have to convert strings to numbers often 
    
    
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        Score = 0;
        
        TileBehaviour.TileDestroyEvent.AddListener(UpdateScore);
    }

    private void UpdateScore(TileBehaviour tileBehaviour)
    {
        Score += tileBehaviour.NumStrikesToDisappear;
        ScoreChangeEvent.Invoke(Score);
    }

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            _scoreText.text = _score.ToString();
        }
    }
}
