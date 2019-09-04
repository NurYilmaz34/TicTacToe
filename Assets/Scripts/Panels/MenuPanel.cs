using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TicTacToe.Data;

public class MenuPanel : MonoBehaviour
{

    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private Button SettingsButton;
    [SerializeField]
    private Button ExitButton;
    [SerializeField]
    private GameObject TimePanel;
    [SerializeField]
    public InputField NumberText;
    [SerializeField]
    private int NewNumber;
    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    private Text TimeText;
    [SerializeField]
    private Button SaveButton;

    void Start()
    {
        PlayButton.onClick.AddListener(() => OnClickPlayButton());
        SettingsButton.onClick.AddListener(() => OnClickSettingsButton());
        ExitButton.onClick.AddListener(() => OnClickExitButton());
        SaveButton.onClick.AddListener(() => OnClickSaveButton());
    }

    private void OnClickSaveButton()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.TimeKey, Convert.ToInt32(NumberText.text));
        //PlayerPrefs.GetFloat(PlayerPrefConstants.TimeKey, Convert.ToInt32(TimeText.text));
        NewNumber = PlayerPrefs.GetInt(PlayerPrefConstants.TimeKey, Convert.ToInt32(NumberText.text));
        GameManager.GetGameTime(NewNumber);
    }

    private void OnClickPlayButton()
    {
        gameObject.SetActive(false);
    }
    private void OnClickSettingsButton()
    {
        TimePanel.SetActive(true);
        NumberText.characterValidation = InputField.CharacterValidation.Integer;
    }
    private void OnClickExitButton()
    {
        Application.Quit();
    }

    
}
