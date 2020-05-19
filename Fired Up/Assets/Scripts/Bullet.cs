using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public string ShotBy;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("RecieveDamage", new BulletParameters(Damage, ShotBy), SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
