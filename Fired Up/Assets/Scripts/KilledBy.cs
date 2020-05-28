using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KilledBy : MonoBehaviour
{
    public string KilledByText = "Dark Magic";
    private Text text;

    void Awake()
    {
        text = GameObject.FindGameObjectWithTag("KilledByText").GetComponent<Text>();
    }

    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        if (text == null)
        {
            if (text.text == "Dark Magic")
            {
                text.text = KilledByText;
                Destroy(gameObject);
            }
        }
    }

    public void SetKilledBy(string KilledBy)
    {
        KilledByText = KilledBy;
    }
}
