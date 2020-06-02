using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitDetection : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TutorialNextLocation")
        {
            tutorial.MoveToLocation = true;
        }
        else if (other.tag == "TutorialMoveToDoor")
        {
            tutorial.MoveToDoor = true;
        }
        else if (other.tag == "TutorialMoveToDoor2")
        {
            tutorial.MoveToDoor2 = true;
        }
        else if (other.tag == "Lift")
        {
            tutorial.InLift = true;
        }
    }
}
