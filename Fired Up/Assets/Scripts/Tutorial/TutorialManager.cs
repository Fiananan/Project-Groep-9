using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TutorialState
{
    Intro = 0,
    PlayingIntro,
    WASD,
    PlayingWASD,
    Enemy,
    PlayingEnemy,
    NextLocation,
    PlayingNextLocation,
    KeycardPickup,
    PlayingKeycardPickup,
    MoveToDoor,
    PlayingMoveToDoor,
    WrongDoor,
    PlayingWrongDoor,
    MoveToDoor2,
    PlayingMoveToDoor2,
    Finish,
    PlayingFinish,
}

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialState tutorial = TutorialState.Intro;

    [SerializeField] private string gender = "female";

    [SerializeField] private VoiceLineManager voiceLine;

    [SerializeField] private float[] VoiceLineTimesMale;
    [SerializeField] private float[] VoiceLineTimesFemale;
    [SerializeField] private float VoiceLineTime;

    [SerializeField] private float[] ComplimentTimesMale;
    [SerializeField] private float[] ComplimentTimesFemale;
    [SerializeField] private float ComplimentTime;
    int ComplimentIndex;

    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private Keycard PlayerKeycard;
    public bool MoveToLocation = false;
    public bool MoveToDoor = false;
    public bool MoveToDoor2 = false;
    public bool InLift = false;
    [SerializeField] private TutorialEnemy enemy;
    [SerializeField] private GameObject DoorTrigger;

    [SerializeField] private GameObject Arrow;
    [SerializeField] private Transform[] ArrowLocations;
    private GameObject CurrentArrow;

    void Update()
    {
        if (tutorial == TutorialState.Intro)
        {
            voiceLine.NextVoiceLine(0, gender);
            tutorial = TutorialState.PlayingIntro;

        }
        else if (tutorial == TutorialState.PlayingIntro)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(0, gender))
            {
                tutorial = TutorialState.WASD;
                VoiceLineTime = 0f;
            }
        }
        else if (tutorial == TutorialState.WASD)
        {
            voiceLine.NextVoiceLine(1, gender);
            CurrentArrow = Instantiate(Arrow, ArrowLocations[0].position, Arrow.transform.rotation);
            tutorial = TutorialState.PlayingWASD;
        }
        else if (tutorial == TutorialState.PlayingWASD)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(1, gender))
            {
                if (MoveToLocation)
                {
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.Enemy;
                }
            }
        }
        else if (tutorial == TutorialState.Enemy)
        {
            voiceLine.NextVoiceLine(2, gender);
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            tutorial = TutorialState.PlayingEnemy;
        }
        else if (tutorial == TutorialState.PlayingEnemy)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(2, gender))
            {
                if (enemy.Died)
                {
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.KeycardPickup;
                }
            }
        }
        else if (tutorial == TutorialState.KeycardPickup)
        {
            voiceLine.NextVoiceLine(3, gender);
            tutorial = TutorialState.PlayingKeycardPickup;
        }
        else if (tutorial == TutorialState.PlayingKeycardPickup)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(3, gender))
            {
                if (PlayerKeycard.HasRedCard)
                {
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.MoveToDoor;
                }
            }
        }
        else if (tutorial == TutorialState.MoveToDoor)
        {
            voiceLine.NextVoiceLine(4, gender);
            CurrentArrow = Instantiate(Arrow, ArrowLocations[1].position, Arrow.transform.rotation);
            tutorial = TutorialState.PlayingMoveToDoor;
        }
        else if (tutorial == TutorialState.PlayingMoveToDoor)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(4, gender))
            {
                if (MoveToDoor)
                {
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.WrongDoor;
                }
            }
        }
        else if (tutorial == TutorialState.WrongDoor)
        {
            voiceLine.NextVoiceLine(5, gender);
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            tutorial = TutorialState.PlayingWrongDoor;
        }
        else if (tutorial == TutorialState.PlayingWrongDoor)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(5, gender))
            {
                if (PlayerKeycard.HasGreenCard)
                {
                    DoorTrigger.SetActive(true);
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.MoveToDoor2;
                }
            }
        }
        else if (tutorial == TutorialState.MoveToDoor2)
        {
            voiceLine.NextVoiceLine(6, gender);
            CurrentArrow = Instantiate(Arrow, ArrowLocations[1].position, Arrow.transform.rotation);
            tutorial = TutorialState.PlayingMoveToDoor2;
        }
        else if (tutorial == TutorialState.PlayingMoveToDoor2)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(6, gender))
            {
                if (MoveToDoor2)
                {
                    VoiceLineTime = 0f;
                    tutorial = TutorialState.Finish;
                }
            }
        }
        else if (tutorial == TutorialState.Finish)
        {
            voiceLine.NextVoiceLine(7, gender);
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            tutorial = TutorialState.PlayingFinish;
        }
        else if (tutorial == TutorialState.PlayingFinish)
        {
            VoiceLineTime += Time.deltaTime;
            if (VoiceLineTime >= GetVoiceLineTime(7, gender))
            {
                if (InLift)
                {
                    VoiceLineTime = 0f;
                    SceneManager.LoadScene(0);
                }
            }
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
}
