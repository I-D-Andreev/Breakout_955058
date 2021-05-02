using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    private int _profilePanelPosition;
    private PlayerProfile _playerProfile;

    private GameObject _plusButton;
    private GameObject _profileInfo;
    private GameObject _buttonsPanel;
    
    private GameObject _createProfilePanel;
    private GameObject _createProfileNameInput;
    private GameObject _createProfileErrorTextBox;
    

    private void Awake()
    {
        _profilePanelPosition = gameObject.transform.GetSiblingIndex();
        _playerProfile = Database.GameData.FindPlayerByPanelPosition(_profilePanelPosition);
        
        _plusButton = gameObject.transform.Find("InfoPanel/PlusButton").gameObject;
        _profileInfo = gameObject.transform.Find("InfoPanel/ProfileInfo").gameObject;
        _buttonsPanel = gameObject.transform.Find("ButtonsPanel").gameObject;
        
        _createProfilePanel = gameObject.transform.Find("InfoPanel/CreateProfile").gameObject;
        _createProfileNameInput = _createProfilePanel.transform.Find("Input/NameInput").gameObject;
        _createProfileErrorTextBox = _createProfilePanel.transform.Find("ErrorText").gameObject;
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
        _createProfilePanel.SetActive(false);
    }
    
    private void ShowProfileInfoScreen()
    {
        _plusButton.SetActive(false);
        _profileInfo.SetActive(true);
        _buttonsPanel.SetActive(true);
        _createProfilePanel.SetActive(false);
        
        _profileInfo.transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
        // _profileInfo.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = $"Highest Score: {_playerProfile}";
        // _profileInfo.transform.Find("PlayedTime").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
        // _profileInfo.transform.Find("Achievements").GetComponent<TextMeshProUGUI>().text = $"Name: {_playerProfile.PlayerName}";
    }


    public void PlusButtonClicked()
    {
        _plusButton.SetActive(false);
        _createProfilePanel.SetActive(true);
        _createProfileErrorTextBox.SetActive(false);
        TMP_InputField inputField = _createProfileNameInput.GetComponent<TMP_InputField>();
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void CreateProfileClicked()
    {
        string playerName = _createProfileNameInput.GetComponent<TMP_InputField>().text;

        if (string.IsNullOrEmpty(playerName))
        {
            _createProfileErrorTextBox.GetComponent<TextMeshProUGUI>().text = "Please choose a name!";
            _createProfileErrorTextBox.SetActive(true);
            return;
        }

        (PlayerProfile profile, string msg) = Database.GameData.CreateNewProfile(playerName, _profilePanelPosition);

        if (profile is null)
        {
            _createProfileErrorTextBox.GetComponent<TextMeshProUGUI>().text = msg;
            _createProfileErrorTextBox.SetActive(true);
            return;
        }

        _playerProfile = profile;
        ShowProfileInfoScreen();
    }

    public void CreateProfileCancelClicked()
    {
        _createProfilePanel.SetActive(false);
        ShowCreateProfileScreen();
    }

    public void DeleteButtonClicked()
    {
        bool result = EditorUtility.DisplayDialog("Are you sure?",
            "Deleting this profile will remove all the data associated with it.",
            "Delete", "Cancel");

        if (result)
        {
            Database.GameData.DeleteProfile(_playerProfile);
            ShowCreateProfileScreen();
        }
    }

    public void PlayButtonClicked()
    {
        Database.GameData.LogIn(_playerProfile);
        SceneLoader.Loader.LoadScene("MainMenu");   
    }
}