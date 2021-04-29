using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreUpdateListener : MonoBehaviour
{   
    private TMP_Text scoreText;
    private ulong score;
    
    void Awake()
    {
        score = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
