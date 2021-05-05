using UnityEngine;

public class SetBallMovementTutorialEvent : TutorialEvent
{
    private GameObject _ball;
    private Vector2 _direction;
    private const float DefaultBallSpeed = 2f;
    
    public SetBallMovementTutorialEvent(GameObject ball, Vector2 direction)
    {
        _ball = ball;
        _direction = direction;
    }
    
    public override bool TryExecuteEvent()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = _direction * DefaultBallSpeed;
        return true;
    }
}
