using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LoginPanel : MonoBehaviour
{

    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private Button SettingsButton;
    [SerializeField]
    private Button ExitButton;
    [SerializeField]
    private GameObject MuteButton;

    void Start()
    {
        PlayButton.onClick.AddListener(() => PlayButtonOnClik());
        SettingsButton.onClick.AddListener(() => SettingsButtonOnClick());
        ExitButton.onClick.AddListener(() => ExitButtonOnClick());
    }
    
    private void PlayButtonOnClik()
    {
        gameObject.SetActive(false);
    }
    private void SettingsButtonOnClick()
    {
        MuteButton.SetActive(true);
    }
    private void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
