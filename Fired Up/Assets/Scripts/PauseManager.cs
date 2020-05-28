using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool Paused = false;

    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject QuitButton;
    [SerializeField] private GameObject PausedText;
    [SerializeField] private GameObject Stats;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Paused = false;
        Time.timeScale = 1f;

        Background.SetActive(false);
        PausedText.SetActive(false);
        ResumeButton.SetActive(false);
        QuitButton.SetActive(false);
        Stats.SetActive(false);
    }

    public void Pause()
    {
        Paused = true;
        Time.timeScale = 0f;

        Background.SetActive(true);
        PausedText.SetActive(true);
        ResumeButton.SetActive(true);
        QuitButton.SetActive(true);
        Stats.SetActive(true);
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
