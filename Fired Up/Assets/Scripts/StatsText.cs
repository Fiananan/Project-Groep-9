using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    [SerializeField] private Text text;
    private Statistics stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
    }

    void Update()
    {
        text.text = "Deaths: " + stats.Deaths + "\nShots Fired: " + stats.ShotsFired + "\nShots Hit: " + stats.ShotsHit + "\nAccuracy: " + Mathf.Round(stats.Accuracy) + "%";
    }
}
