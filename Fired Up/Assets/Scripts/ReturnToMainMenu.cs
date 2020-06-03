using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    float Timer;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
