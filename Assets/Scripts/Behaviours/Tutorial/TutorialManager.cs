using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

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
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject ball;

    private TutorialTileManager _tutorialTileManager;

    private TextMeshProUGUI _infoTextBox;
    private TextMeshProUGUI _commandTextBox;

    private List<TutorialEvent> _events;
    private int _currentIndex;

    private BoolWrapper _paddleHit;

    private void Awake()
    {
        GameChangeMonitor.ShouldMonitor = false;
    }

    private void Start()
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
                "Welcome to the Tutorial",
                "Press the Space Key to Continue"),
            new ShowHideTutorialTextEvent(tutorialText, true),
            new WaitKeyPressTutorialEvent(Key.Space),

            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can exit the tutorial by pressing the Esc Key",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),

            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can move the Paddle with the Left and Right Arrows",
                "Press the Left Arrow Key to Continue"),

            new WaitKeyPressTutorialEvent(Key.LeftArrow),

            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You can move the Paddle with the Left and Right Arrows",
                "Press the Right Arrow Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.RightArrow),

            new ShowBallEvent(ball),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "This is the Ball",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),

            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Move the Paddle to hit the Ball. Do not let it reach the ground!",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),

            new SetBallMovementTutorialEvent(ball, new Vector2(-1, -1)),

            new ShowHideTutorialTextEvent(tutorialText, false),
            new WaitBallHitTileTutorialEvent(_paddleHit),

            new WaitSecondsTutorialEvent(1.3f),
            new SetBallMovementTutorialEvent(ball, new Vector2(0, 0)),


            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesRect),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "You should use the ball to hit the provided tiles",
                "Press the Space Key to Continue"),
            new ShowHideTutorialTextEvent(tutorialText, true),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "The tiles may appear in a Rectangle form as shown now",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesMosaic),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or they may appear in a Mosaic form",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesColumns),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or in Columns",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new DestroyTilesTutorialEvent(),
            new CreateTilesTutorialEvent(_tutorialTileManager.TileFactory.CreateTilesRandomRect),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Or in a Random Shape",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "To destroy a green tile, you will need one hit",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "While yellow and red ones require 2 and 3 hits respectively",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "If you destroy all tiles, new ones will be created in one of the patterns shown",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Finally, each destroyed tile gives you points equal to the number of required hits",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            
            new ShowHideTutorialTextEvent(scoreText, true),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "Your current score will be shown in the top right corner",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            
            new ShowHideTutorialTextEvent(scoreText, true),
            new SetTextTutorialEvent(_infoTextBox, _commandTextBox,
                "This concludes the tutorial. You may return to the Main Menu or continue playing.",
                "Press the Space Key to Continue"),
            new WaitKeyPressTutorialEvent(Key.Space),
            new ShowHideTutorialTextEvent(tutorialText, false),
            new SetBallMovementTutorialEvent(ball, new Vector2(-1, 1)),
        };
    }

    private void PaddleWasHit()
    {
        _paddleHit.Value = true;
    }

    private void Update()
    {
        if (_currentIndex < _events.Count && _events[_currentIndex].TryExecuteEvent())
        {
            _currentIndex++;
        }
    }
}