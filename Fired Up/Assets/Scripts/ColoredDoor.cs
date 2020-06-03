using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredDoor : MonoBehaviour
{
    [SerializeField] private Keycard Keycard;
    [SerializeField] private GameObject DoorR;
    [SerializeField] private GameObject DoorL;
    [SerializeField] private GameObject InteractText;
    [SerializeField] private string DoorColor;

    [SerializeField] private float Speed;

    [SerializeField] private bool IsOpen = false;
    [SerializeField] private bool Opening = false;
    [SerializeField] private bool Closing = false;

    private bool OpenDoorBool = false;
    private Collider other;

    void Start()
    {
        if (DoorColor == "green")
        {
            DoorR.GetComponent<Renderer>().material.color = Color.green;
            DoorL.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (DoorColor == "red")
        {
            DoorR.GetComponent<Renderer>().material.color = Color.red;
            DoorL.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (DoorColor == "blue")
        {
            DoorR.GetComponent<Renderer>().material.color = Color.blue;
            DoorL.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (DoorColor == "yellow")
        {
            DoorR.GetComponent<Renderer>().material.color = Color.yellow;
            DoorL.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    void Update()
    {
        if (OpenDoorBool)
        {
            if (other.tag == "Player")
            {
                InteractText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (DoorColor == "green" && Keycard.HasGreenCard)
                    {
                        if (IsOpen)
                        {
                            Closing = true;
                        }
                        else
                        {
                            Opening = true;
                        }
                    }
                    else if (DoorColor == "red" && Keycard.HasRedCard)
                    {
                        if (IsOpen)
                        {
                            Closing = true;
                        }
                        else
                        {
                            Opening = true;
                        }
                    }
                    else if (DoorColor == "blue" && Keycard.HasBlueCard)
                    {
                        if (IsOpen)
                        {
                            Closing = true;
                        }
                        else
                        {
                            Opening = true;
                        }
                    }
                    else if (DoorColor == "yellow" && Keycard.HasYellowCard)
                    {
                        if (IsOpen)
                        {
                            Closing = true;
                        }
                        else
                        {
                            Opening = true;
                        }
                    }
                    OpenDoorBool = false;
                }
            }
        }

        if (Opening)
        {
            DoorL.transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            DoorR.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            if (DoorL.transform.localPosition.x <= -3.41)
            {
                Opening = false;
                IsOpen = true;
            }
        }
        else if (Closing)
        {
            DoorL.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            DoorR.transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            if (DoorL.transform.localPosition.x >= -1.122)
            {
                Closing = false;
                IsOpen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        OpenDoorBool = true;
        other = col;
    }

    private void OnTriggerStay(Collider col)
    {
        OpenDoorBool = true;
        other = col;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractText.SetActive(false);
        }
    }
}
