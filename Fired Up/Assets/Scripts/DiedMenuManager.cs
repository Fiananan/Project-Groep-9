using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenuManager : MonoBehaviour
{
    private CurrentLevelSaver currentLevel;

    void Start()
    {
        currentLevel = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
    }

    public void Retry()
    {
        SceneManager.LoadScene(currentLevel.GetCurrentLevel());
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}