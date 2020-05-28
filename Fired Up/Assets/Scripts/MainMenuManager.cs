using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Credits credits;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RollCredits()
    {
        credits.RollCredits = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
