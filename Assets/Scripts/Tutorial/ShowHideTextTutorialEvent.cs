using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideTutorialTextEvent : TutorialEvent
{
    private GameObject _tutorialBox;
    private bool _shouldShow;
    
    public ShowHideTutorialTextEvent(GameObject tutorialBox, bool shouldShow)
    {
        _tutorialBox = tutorialBox;
        _shouldShow = shouldShow;
    }

    public override bool TryExecuteEvent()
    {
        _tutorialBox.SetActive(_shouldShow);
        return true;
    }
}
