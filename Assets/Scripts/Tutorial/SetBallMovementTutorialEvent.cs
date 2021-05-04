using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SetBallMovementTutorialEvent : TutorialEvent
{
    private GameObject _ball;
    private float _speed;
    
    public SetBallMovementTutorialEvent(GameObject ball, float speed = 2.3f)
    {
        _ball = ball;
        _speed = speed;
    }
    
    public override bool TryExecuteEvent()
    {
        BallMovement2D ballMovement = _ball.GetComponent<BallMovement2D>();
        ballMovement.speed = _speed;
        ballMovement.InitBall();
        
        return true;
    }
}
