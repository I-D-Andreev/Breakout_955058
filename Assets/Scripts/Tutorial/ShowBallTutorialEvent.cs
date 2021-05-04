using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBallEvent : TutorialEvent
{
    private GameObject _ball;

    public ShowBallEvent(GameObject ball)
    {
        _ball = ball;
    }
    
    public override bool TryExecuteEvent()
    {
        _ball.SetActive(true);
        return true;
    }
}
