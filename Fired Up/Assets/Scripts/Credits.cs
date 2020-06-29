using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject CreditsText;
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject OptionsButton;

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
            OptionsButton.SetActive(false);
            FindObjectOfType<MusicPlayer>().musicPlayer.Pause();
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
            FindObjectOfType<MusicPlayer>().musicPlayer.UnPause();
            OptionsButton.SetActive(true);
            Background.SetActive(false);
            CreditsText.SetActive(false);
        }
    }
}
