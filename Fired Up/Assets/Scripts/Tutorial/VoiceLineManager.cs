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

    public void NextVoiceLine(int index, string gender)
    {
        if (gender == "male")
        {
            audio.clip = MaleVoiceLines[index];
        }
        else if (gender == "female")
        {
            audio.clip = FemaleVoiceLines[index];
        }
        audio.PlayOneShot(audio.clip);
    }

    public int Compliment(string gender)
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
        audio.PlayOneShot(audio.clip);
        return ComplimentIndex;
    }
}
