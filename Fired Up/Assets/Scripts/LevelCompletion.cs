using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    private CurrentLevelSaver levelSaver;

    public int EnemyCount;

    [SerializeField] private int EnemiesLevel1;
    [SerializeField] private int EnemiesLevel2;
    [SerializeField] private int EnemiesLevel3;

    [SerializeField] private bool AllEnemiesDied = false;

    float Timer;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        Timer = 0f;
        AllEnemiesDied = false;
        Debug.Log("OnLevelWasLoaded Called");
        if (levelSaver.GetCurrentLevel() == "LevelOne")
        {
            EnemyCount = EnemiesLevel1;
        }
        else if (levelSaver.GetCurrentLevel() == "LevelTwo")
        {
            EnemyCount = EnemiesLevel2;
        }
        else if (levelSaver.GetCurrentLevel() == "LevelThree")
        {
            EnemyCount = EnemiesLevel3;
        }
    }

    void Start()
    {
        levelSaver = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
    }

    void Update()
    {
        if (levelSaver.GetCurrentLevel() == "LevelOne" || levelSaver.GetCurrentLevel() == "LevelTwo" || levelSaver.GetCurrentLevel() == "LevelThree")
        {
            Timer += Time.deltaTime;
            if (Timer >= 2.5f)
            {
                if (EnemyCount <= 0)
                {
                    if (levelSaver.GetCurrentLevel() == "LevelOne")
                    {
                        FindObjectOfType<LevelSelector>().Level1Completed = true;
                    }
                    else if (levelSaver.GetCurrentLevel() == "LevelTwo")
                    {
                        FindObjectOfType<LevelSelector>().Level2Completed = true;
                    }
                    else if (levelSaver.GetCurrentLevel() == "LevelThree")
                    {
                        FindObjectOfType<LevelSelector>().Level3Completed = true;
                    }

                    levelSaver.SetCurrentLevel("LevelSelector");
                    SceneManager.LoadScene(levelSaver.GetCurrentLevel());
                }
            }
        }
    }
}
