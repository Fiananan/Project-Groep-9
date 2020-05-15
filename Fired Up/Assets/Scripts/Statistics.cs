using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int Score;
    public int ScoreShowed;
    public int Deaths;
    public int ShotsFired;
    public int ShotsHit;
    public float Accuracy;

    [SerializeField] private int ScoreShowSpeed;

    void Update()
    {
        DontDestroyOnLoad(gameObject);

        if (ShotsHit != 0 && ShotsFired != 0)
        {
            Accuracy = ShotsHit / ShotsFired * 100;
        }
        else
        {
            Accuracy = 0f;
        }

        if (ScoreShowed < Score)
        {
            ScoreShowed += ScoreShowSpeed;
        }
    }

    void Died()
    {
        Deaths++;
    }

    void AddScore(int amount)
    {
        Score += amount;
    }
}
