﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private string Type;
    [SerializeField] private string KeyColor;
    [SerializeField] private GameObject KeycardTop;

    void Start()
    {
        if (Type == "HP")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (Type == "Armor")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (Type == "Keycard")
        {
            if (KeyColor == "green")
            {
                KeycardTop.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (KeyColor == "red")
            {
                KeycardTop.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (KeyColor == "blue")
            {
                KeycardTop.GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (KeyColor == "yellow")
            {
                KeycardTop.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Type == "HP")
            {
                other.gameObject.SendMessage("PickUpHealth", 75, SendMessageOptions.DontRequireReceiver);
            }
            else if (Type == "Armor")
            {
                other.gameObject.SendMessage("PickUpArmor", 100, SendMessageOptions.DontRequireReceiver);
            }
            else if (Type == "Ammo")
            {
                other.gameObject.SendMessage("PickupAmmo", 100, SendMessageOptions.DontRequireReceiver);
            }
            else if (Type == "Keycard")
            {
                if (KeyColor == "green")
                {
                    other.gameObject.SendMessage("PickupKeycard", "green", SendMessageOptions.DontRequireReceiver);
                }
                else if (KeyColor == "red")
                {
                    other.gameObject.SendMessage("PickupKeycard", "red", SendMessageOptions.DontRequireReceiver);
                }
                else if (KeyColor == "blue")
                {
                    other.gameObject.SendMessage("PickupKeycard", "blue", SendMessageOptions.DontRequireReceiver);
                }
                else if (KeyColor == "yellow")
                {
                    other.gameObject.SendMessage("PickupKeycard", "yellow", SendMessageOptions.DontRequireReceiver);
                }
            }
            Destroy(gameObject);
        }
    }
}