using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatButton : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    public void OnButtonClick()
    {
        health.HP = 1000000f;
        health.HPBar.maxValue = 1000000f;
        health.HPBar.value = 1000000f;
        health.Armor = 1000000f;
        health.ArmorBar.maxValue = 1000000f;
        health.ArmorBar.value = 1000000f;
    }
}
