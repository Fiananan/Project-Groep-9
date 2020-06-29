using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private string Type;
    [SerializeField] private string KeyColor;

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
                other.gameObject.SendMessage("PickupAmmo", 21, SendMessageOptions.DontRequireReceiver);
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
