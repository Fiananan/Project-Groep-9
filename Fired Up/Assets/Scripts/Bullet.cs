using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public string ShotBy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("KilledBy").GetComponent<KilledBy>().SetKilledBy(ShotBy);
        }
        collision.gameObject.SendMessage("RecieveDamage", new BulletParameters(Damage, ShotBy), SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
