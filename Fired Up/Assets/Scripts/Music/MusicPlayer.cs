using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float volume;

    private CurrentLevelSaver levelSaver;

    public AudioSource musicPlayer;

    [SerializeField] private AudioClip elevatorMusic;
    [SerializeField] private AudioClip LevelMusic1;
    [SerializeField] private AudioClip LevelMusic2;
    [SerializeField] private AudioClip BossMusic;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        levelSaver = GameObject.FindGameObjectWithTag("LevelSaver").GetComponent<CurrentLevelSaver>();
        musicPlayer = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        musicPlayer.volume = volume;

        transform.position = Camera.main.transform.position;

        if (musicPlayer.isPlaying == false)
        {
            if (levelSaver.GetCurrentLevel() == "TutorialSetup" || levelSaver.GetCurrentLevel() == "LevelSelector")
            {
                musicPlayer.clip = elevatorMusic;
            }
            if (levelSaver.GetCurrentLevel() == "Tutorial" || levelSaver.GetCurrentLevel() == "Level1" || levelSaver.GetCurrentLevel() == "Level2")
            {
                int randomMusic = Random.Range(1, 3);
                if (randomMusic == 1)
                {
                    musicPlayer.clip = LevelMusic1;
                }
                else if (randomMusic == 2)
                {
                    musicPlayer.clip = LevelMusic2;
                }
            }
            musicPlayer.Play();
        }
    }
}
