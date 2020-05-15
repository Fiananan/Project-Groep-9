using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text text;
    private Statistics stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
    }

    void Update()
    {
        text.text = stats.ScoreShowed.ToString();
    }
}
