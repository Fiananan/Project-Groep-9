using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public int Score;
    public int ScoreShowed;
    public int Deaths;
    public float ShotsFired;
    public float ShotsHit;
    public float Accuracy;

    [SerializeField] private int ScoreShowSpeed;

    void Update()
    {
        DontDestroyOnLoad(gameObject);

        Accuracy = ShotsHit * 100 / ShotsFired;

        if (ScoreShowed < Score)
        {
            ScoreShowed += ScoreShowSpeed;
        }
    }

    void ShotFired()
    {
        ShotsFired++;
    }

    void ShotHit()
    {
        ShotsHit++;
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
