using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public bool HasGreenCard = false;
    public bool HasRedCard = false;
    public bool HasBlueCard = false;
    public bool HasYellowCard = false;

    void PickupKeycard(string Color)
    {
        if (Color == "green")
        {
            HasGreenCard = true;
        }
        else if (Color == "red")
        {
            HasRedCard = true;
        }
        else if (Color == "blue")
        {
            HasBlueCard = true;
        }
        else if (Color == "yellow")
        {
            HasYellowCard = true;
        }
    }
}
