using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevelSaver : MonoBehaviour
{
    [SerializeField] private string CurrentLevel = "TutorialSetup";

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string GetCurrentLevel()
    {
        return CurrentLevel;
    }

    public void SetCurrentLevel(string levelName)
    {
        CurrentLevel = levelName;
    }
}
