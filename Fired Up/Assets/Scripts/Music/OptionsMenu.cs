using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider audioSlider;
    private MusicPlayer MusicPlayer;

    void Start()
    {
        MusicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayer>();
    }

    void Update()
    {
        MusicPlayer.volume = audioSlider.value;
    }
}
