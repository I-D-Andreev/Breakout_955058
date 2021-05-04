using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentUser : MonoBehaviour
{
    private TextMeshProUGUI _textBox;

    private void Awake()
    {
        _textBox = gameObject.GetComponent<TextMeshProUGUI>();
        _textBox.text = $"User: {Database.GameData.LoggedInProfile.PlayerName}";
    }
}
