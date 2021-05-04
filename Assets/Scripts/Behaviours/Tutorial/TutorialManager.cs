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

[RequireComponent(typeof(TutorialTileManager))]
public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject ball;
    
    private TutorialTileManager _tutorialTileManager;

    private TextMeshProUGUI _infoTextBox;
    private TextMeshProUGUI _commandTextBox;
    
    private List<TutorialEvent> _events;
    private int _currentIndex;

    private BoolWrapper _paddleHit;
    
    private void Awake()
    {
        _tutorialTileManager = gameObject.GetComponent<TutorialTileManager>();
        _paddleHit = new BoolWrapper(false);
        BallEvents.BallHitsPaddleEvent.AddListener(PaddleWasHit);
        
        _infoTextBox = tutorialText.transform.Find("InfoText").GetComponent<TextMeshProUGUI>();
        _commandTextBox = tutorialText.transform.Find("Panel/CommandText").GetComponent<TextMeshProUGUI>();

        _currentIndex = 0;
        _events = CreateTutorialEvents();
    }

    private List<TutorialEvent> CreateTutorialEvents()
    {
        return new List<TutorialEvent>
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
            
            
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesRect),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You should use the ball to hit the provided tiles!", 
                "Press the Space Key to Continue!"),
            new ShowHideTutorialTextEvent(tutorialText, true),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "The tiles may appear in a Rectangle form as shown now!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesMosaic),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or they may appear in a Mosaic form!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            

            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesColumns),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or in Columns!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),

            
            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesRandomRect),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or in a Random Shape!", 
                "Press the Space Key to Continue!"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
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