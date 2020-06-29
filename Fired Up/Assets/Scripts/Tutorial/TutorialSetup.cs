using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSetup : MonoBehaviour
{
    [SerializeField] private string genderSelected;
    [SerializeField] private CurrentLevelSaver levelSaver;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        levelSaver = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
    }

    public string GetVoice()
    {
        return genderSelected;
    }

    public void SetMaleVoice()
    {
        genderSelected = "male";
        levelSaver.SetCurrentLevel("Tutorial");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }

    public void SetFemaleVoice()
    {
        genderSelected = "female";
        levelSaver.SetCurrentLevel("Tutorial");
        SceneManager.LoadScene(levelSaver.GetCurrentLevel());
    }
}
