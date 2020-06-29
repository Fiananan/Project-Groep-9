using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorButtonActivator : MonoBehaviour
{
    [SerializeField] private LevelSelector Levels;

    [SerializeField] private Button Tutorial;
    [SerializeField] private Button Level1;
    [SerializeField] private Button Level2;
    [SerializeField] private Button Level3;

    void Start()
    {
        Levels = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<LevelSelector>();
    }

    void Update()
    {
        if (Levels.TutorialCompleted == false)
        {
            Level1.interactable = false;
        }
        else
        {
            Level1.interactable = true;
        }

        if (Levels.Level1Completed == false)
        {
            Level2.interactable = false;
        }
        else
        {
            Level2.interactable = true;
        }

        if (Levels.Level2Completed == false)
        {
            Level3.interactable = false;
        }
        else
        {
            Level3.interactable = true;
        }
    }
}
