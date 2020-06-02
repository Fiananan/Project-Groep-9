using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KilledBy : MonoBehaviour
{
    public static string KilledByText;
    private Text text;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        text = GameObject.FindGameObjectWithTag("KilledByText").GetComponent<Text>();
    }

    void Update()
    {
        text.text = KilledByText;
    }

    public void SetKilledBy(string KilledBy)
    {
        KilledByText = KilledBy;
    }
}
