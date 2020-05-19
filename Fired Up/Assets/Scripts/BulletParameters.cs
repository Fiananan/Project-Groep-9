using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParameters
{
    public int Damage;
    public string ShotBy;

    public BulletParameters(int Damage, string ShotBy)
    {
        this.Damage = Damage;
        this.ShotBy = ShotBy;
    }
}
