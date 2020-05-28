using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject CreditsText;
    [SerializeField] private GameObject Background;

    [SerializeField] private AudioClip[] MusicClip;
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
                int randomSong = Random.Range(0, 2);
                print(randomSong);
                Music.clip = MusicClip[randomSong];
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
            Background.SetActive(false);
            CreditsText.SetActive(false);
        }
    }
}
