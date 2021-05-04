using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBallMovementTutorialEvent : TutorialEvent
{
    private GameObject _ball;

    public StartBallMovementTutorialEvent(GameObject ball)
    {
        _ball = ball;
    }
    
    public override bool TryExecuteEvent()
    {
        BallMovement2D ballMovement = _ball.GetComponent<BallMovement2D>();
        ballMovement.speed = 2.3f;
        return true;
    }
}
