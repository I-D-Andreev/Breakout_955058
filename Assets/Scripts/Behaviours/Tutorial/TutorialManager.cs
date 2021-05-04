using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// So that a boolean value can be passed by reference.
public class BoolWrapper
{
    public bool Value;

    public BoolWrapper(bool v)
    {
        Value = v;
    }
}

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject ball;
    
    private TextMeshProUGUI _infoTextBox;
    private TextMeshProUGUI _commandTextBox;
    
    private List<TutorialEvent> _events;
    private int _currentIndex;

    private BoolWrapper _paddleHit;
    
    private void Awake()
    {
        _paddleHit = new BoolWrapper(false);
        BallEvents.BallHitsPaddleEvent.AddListener(PaddleWasHit);
        
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
            
            new SetBallMovementTutorialEvent(ball),
            
            new ShowHideTutorialTextEvent(tutorialText, false),
            new WaitBallHitTileTutorialEvent(_paddleHit),
            
            new WaitSecondsTutorialEvent(1),
            new SetBallMovementTutorialEvent(ball, 0),
            new ShowHideTutorialTextEvent(tutorialText, true),

        };
    }

    private void PaddleWasHit()
    {
        Debug.Log("Paddle was hit");
        _paddleHit.Value = true;
    }

    private void Update()
    {
        if (_currentIndex < _events.Count && _events[_currentIndex].TryExecuteEvent())
        {
            Debug.Log($"Event {_currentIndex} done!");
            _currentIndex++;
            if (_currentIndex == _events.Count) Debug.Log("Finished");
        }
    }
}