using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject ball;
    
    private TextMeshProUGUI _infoTextBox;
    private TextMeshProUGUI _commandTextBox;


    private List<TutorialEvent> _events;
    private int _currentIndex;

    private void Awake()
    {
        _infoTextBox = tutorialText.transform.Find("InfoText").GetComponent<TextMeshProUGUI>();
        _commandTextBox = tutorialText.transform.Find("Panel/CommandText").GetComponent<TextMeshProUGUI>();

        _currentIndex = 0;
        _events = new List<TutorialEvent>
        {
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Welcome to the Tutorial!", 
                "Press the Space Key to Continue!"),
            new ShowHideTutorialTextEvent(tutorialText, true),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can exit the tutorial by pressing the Esc Key!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can move the Paddle with the Left and Right Arrows",
                "Press the Left Arrow Key to Continue!"),
            
            new WaitKeyPressTutorialEvent(Key.LeftArrow),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can move the Paddle with the Left and Right Arrows",
                "Press the Right Arrow Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.RightArrow),
            
            new ShowBallEvent(ball),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "This is the Ball!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Move the Paddle to hit the Ball. Do not let it reach the ground!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new StartBallMovementTutorialEvent(ball),

            
            
            
        };
    }


    private void Update()
    {
        if (_currentIndex < _events.Count && _events[_currentIndex].TryExecuteEvent())
        {
            Debug.Log($"Event {_currentIndex} done!");
            _currentIndex++;
        }
    }
}