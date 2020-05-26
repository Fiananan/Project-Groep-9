using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState
{
    Intro = 0,
    WASD,
    Enemy,
    NextLocation,
    KeycardPickup,
    MoveToDoor,
    WrongDoor,
    MoveToDoor2,
    Finish
}

public class TutorialManager : MonoBehaviour
{
    private TutorialState tutorial = TutorialState.Intro;

    [SerializeField] private string gender = "female";

    [SerializeField] private VoiceLineManager voiceLine;

    [SerializeField] private float[] VoiceLineTimesMale;
    [SerializeField] private float[] VoiceLineTimesFemale;
    [SerializeField] private float VoiceLineTime;

    [SerializeField] private float[] ComplimentTimesMale;
    [SerializeField] private float[] ComplimentTimesFemale;
    [SerializeField] private float ComplimentTime;

    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private Keycard PlayerKeycard;
    private bool MoveToLocation = false;
    private bool MoveToDoor = false;
    private bool MoveToDoor2 = false;
    private GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if (tutorial == TutorialState.Intro)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(0, gender))
            {
                tutorial = TutorialState.WASD;
                VoiceLineTime = 0f;
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.WASD)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(1, gender))
            {
                if (Input.GetKey(PlayerController.forwards) || Input.GetKey(PlayerController.backwards) || Input.GetKey(PlayerController.right) || Input.GetKey(PlayerController.left))
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.NextLocation;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.NextLocation)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(2, gender))
            {
                if (MoveToLocation)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.KeycardPickup;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.Enemy)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(3, gender))
            {
                if (enemy = null)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.KeycardPickup;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.KeycardPickup)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(4, gender))
            {
                if (PlayerKeycard.HasRedCard)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.MoveToDoor;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.MoveToDoor)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(5, gender))
            {
                if (MoveToDoor)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.WrongDoor;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.WrongDoor)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(6, gender))
            {
                if (PlayerKeycard.HasGreenCard)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.MoveToDoor2;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.MoveToDoor2)
        {
            voiceLine.NextVoiceLine(gender);
            if (VoiceLineTime >= GetVoiceLineTime(7, gender))
            {
                if (MoveToDoor2)
                {
                    VoiceLineTime = 0f;
                    voiceLine.Compliment(gender);
                    if (ComplimentTime >= GetComplimentTime(voiceLine.ComplimentIndex, gender))
                    {
                        tutorial = TutorialState.Finish;
                        ComplimentTime = 0f;
                    }
                    else
                    {
                        ComplimentTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                VoiceLineTime += Time.deltaTime;
            }
        }
        else if (tutorial == TutorialState.Finish)
        {
            voiceLine.NextVoiceLine(gender);
        }
    }

    float GetVoiceLineTime(int index, string gender)
    {
        if (gender == "male")
        {
            return VoiceLineTimesMale[index];
        }
        else if (gender == "female")
        {
            return VoiceLineTimesFemale[index];
        }

        return 0f;
    }

    float GetComplimentTime(int index, string gender)
    {
        if (gender == "male")
        {
            return ComplimentTimesMale[index];
        }
        else if (gender == "female")
        {
            return ComplimentTimesFemale[index];
        }

        return 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TutorialNextLocation")
        {
            MoveToLocation = true;
        }
        else if (other.tag == "TutorialMoveToDoor")
        {
            MoveToDoor = true;
        }
        else if (other.tag == "TutorialMoveToDoor2")
        {
            MoveToDoor2 = true;
        }
    }
}
