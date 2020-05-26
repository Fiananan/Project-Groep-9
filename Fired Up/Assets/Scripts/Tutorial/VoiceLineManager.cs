using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] MaleVoiceLines;
    [SerializeField] private AudioClip[] FemaleVoiceLines;
    public int VoiceLineIndex = 0;

    [SerializeField] private AudioClip[] MaleCompliments;
    [SerializeField] private AudioClip[] FemaleCompliments;
    public int ComplimentIndex = 0;

    [SerializeField] private AudioSource audio;

    public void NextVoiceLine(string gender)
    {
        if (!audio.isPlaying)
        {
            if (gender == "male")
            {
                audio.clip = MaleVoiceLines[VoiceLineIndex];
            }
            else if (gender == "female")
            {
                audio.clip = FemaleVoiceLines[VoiceLineIndex];
            }
            audio.Play();
            VoiceLineIndex++;
        }
    }

    public void Compliment(string gender)
    {
        if (!audio.isPlaying)
        {
            ComplimentIndex = Random.Range(0, MaleCompliments.Length + 1);
            if (gender == "male")
            {
                audio.clip = MaleCompliments[ComplimentIndex];
            }
            else if (gender == "female")
            {
                audio.clip = FemaleCompliments[ComplimentIndex];
            }
            audio.Play();
        }
    }
}
