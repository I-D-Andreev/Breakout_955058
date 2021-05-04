using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextTutorialEvent : TutorialEvent
{
    private TextMeshProUGUI _infoTextBox;
    private TextMeshProUGUI _commandTextBox;
    private string _infoText;
    private string _commandText;
    
    public SetTextTutorialEvent(TextMeshProUGUI infoTextBox, TextMeshProUGUI commandTextBox, string infoText, string commandText)
    {
        _infoTextBox = infoTextBox;
        _commandTextBox = commandTextBox;
        
        _infoText = infoText;
        _commandText = commandText;
    }
    
    public override bool TryExecuteEvent()
    {
        _infoTextBox.text = _infoText;
        _commandTextBox.text = _commandText;
        return true;
    }
}
