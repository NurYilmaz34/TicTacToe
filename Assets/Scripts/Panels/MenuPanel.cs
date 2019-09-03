using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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
    

    void Start()
    {
        PlayButton.onClick.AddListener(() => PlayButtonOnClik());
        SettingsButton.onClick.AddListener(() => SettingsButtonOnClick());
        ExitButton.onClick.AddListener(() => ExitButtonOnClick());

        //NumberText.keyboardType = TouchScreenKeyboardType.NumberPad;
        NumberText.characterValidation = InputField.CharacterValidation.Integer;

        NewNumber = int.Parse(NumberText.text);
        GameManager.GetGameTime(NewNumber);
    }
    
    private void PlayButtonOnClik()
    {
        gameObject.SetActive(false);
    }
    private void SettingsButtonOnClick()
    {
        TimePanel.SetActive(true);
    }
    private void ExitButtonOnClick()
    {
        Application.Quit();
    }

    
}
