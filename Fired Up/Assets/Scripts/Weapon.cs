using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public int ID;
    public string Type;

    public int Damage;
    public float FireRate;
    public int MagazineSize;
    public float ReloadTime;
}
