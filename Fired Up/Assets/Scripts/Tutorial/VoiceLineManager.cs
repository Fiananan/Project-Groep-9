using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] MaleVoiceLines;
    [SerializeField] private AudioClip[] FemaleVoiceLines;

    [SerializeField] private AudioClip[] MaleCompliments;
    [SerializeField] private AudioClip[] FemaleCompliments;

    [SerializeField] private AudioSource audio;

    public void NextVoiceLine(string gender, int index)
    {
        if (!audio.isPlaying)
        {
            if (gender == "male")
            {
                audio.clip = MaleVoiceLines[index];
            }
            else if (gender == "female")
            {
                audio.clip = FemaleVoiceLines[index];
            }
            audio.Play();
        }
    }

    public void Compliment(string gender)
    {
        if (!audio.isPlaying)
        {
            int ComplimentIndex = Random.Range(0, MaleCompliments.Length + 1);
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
