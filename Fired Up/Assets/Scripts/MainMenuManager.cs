using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Credits credits;
    [SerializeField] private bool Options = false;
    [SerializeField] private GameObject OptionsObject;
    private CurrentLevelSaver currentLevel;

    [SerializeField] private Text OptionsButtonText;

    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject CreditsButton;
    [SerializeField] private GameObject QuitButton;

    void Start()
    {
        currentLevel = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(currentLevel.GetCurrentLevel());
    }

    public void RollCredits()
    {
        credits.RollCredits = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        if (!Options)
        {
            OptionsButtonText.text = "close";
            Options = true;
            OptionsObject.SetActive(true);
            StartButton.SetActive(false);
            CreditsButton.SetActive(false);
            QuitButton.SetActive(false);
        }
        else if(Options)
        {
            OptionsButtonText.text = "options";
            Options = false;
            OptionsObject.SetActive(false);
            StartButton.SetActive(true);
            CreditsButton.SetActive(true);
            QuitButton.SetActive(true);
        }
    }
}
