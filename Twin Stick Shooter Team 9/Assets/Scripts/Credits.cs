using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private Transform CreditsStartlocation;
    [SerializeField] private GameObject CreditsText;
    [SerializeField] private GameObject Background;

    [SerializeField] private AudioSource Music;
    private bool MusicPlaying = false;

    public bool RollCredits = false;
    [SerializeField] private float CreditsTime;
    [SerializeField] private float CreditsTimer;

    void Update()
    {
        if (RollCredits)
        {
            Background.SetActive(true);
            CreditsText.SetActive(true);
            if (!MusicPlaying)
            {
                Music.Play();
                MusicPlaying = true;
            }

            CreditsTime += Time.deltaTime;
            if (CreditsTime >= CreditsTimer)
            {
                RollCredits = false;
                CreditsTime = 0f;
            }
        }
        else
        {
            if (Music.isPlaying)
            {
                Music.Stop();
            }
            MusicPlaying = false;
            CreditsText.transform.position = CreditsStartlocation.position;
            Background.SetActive(false);
            CreditsText.SetActive(false);
        }
    }
}
