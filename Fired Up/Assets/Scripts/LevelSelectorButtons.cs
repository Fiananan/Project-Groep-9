using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorButtons : MonoBehaviour
{
    private CurrentLevelSaver levelSaver;

    void Start()
    {
        levelSaver = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
    }

    public void StartTutorial()
    {
        levelSaver.SetCurrentLevel("Tutorial Setup");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }

    public void StartLevel1()
    {
        levelSaver.SetCurrentLevel("LevelOne");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }

    public void StartLevel2()
    {
        levelSaver.SetCurrentLevel("LevelTwo");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }

    public void StartLevel3()
    {
        levelSaver.SetCurrentLevel("LevelThree");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }
}
