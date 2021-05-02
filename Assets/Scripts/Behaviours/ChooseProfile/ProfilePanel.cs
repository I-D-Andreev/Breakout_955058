using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    private int _profilePanelPosition;
    private PlayerProfile _playerProfile;

    private GameObject _plusButton;
    private GameObject _profileInfo;
    private GameObject _buttonsPanel;
    

    private void Awake()
    {
        _profilePanelPosition = gameObject.transform.GetSiblingIndex();
        _playerProfile = Database.GameData.FindPlayerByPanelPosition(_profilePanelPosition);
        
        _plusButton = gameObject.transform.Find("InfoPanel/PlusButton").gameObject;
        _profileInfo = gameObject.transform.Find("InfoPanel/ProfileInfo").gameObject;
        _buttonsPanel = gameObject.transform.Find("ButtonsPanel").gameObject;
        RenderProfile();
    }

    private void RenderProfile()
    {
        if (_playerProfile is null)
        {
            ShowCreateProfileScreen();
        }
        else
        {
            ShowProfileInfoScreen();
        }
    }

    
    private void ShowCreateProfileScreen()
    {
        _plusButton.SetActive(true);
        _profileInfo.SetActive(false);
        _buttonsPanel.SetActive(false);
    }
    
    private void ShowProfileInfoScreen()
    {
        _plusButton.SetActive(false);
        _profileInfo.SetActive(true);
        _buttonsPanel.SetActive(true);
        
        _profileInfo.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
        // _profileInfo.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = $"Highest Score: {_playerProfile}";
        // _profileInfo.transform.Find("PlayedTime").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
        // _profileInfo.transform.Find("Achievements").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
    }


    public void PlusButtonClicked()
    {
        
    }

    public void DeleteButtonClicked()
    {
        
    }

    public void PlayButtonClicked()
    {
        Database.GameData.LogIn(_playerProfile);
        SceneLoader.Loader.LoadScene("MainMenu");   
    }
}