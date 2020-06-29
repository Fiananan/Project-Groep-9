using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private float HitTimer;
    private float HitTime;
    private bool CanDealDamage = false;

    [SerializeField] private int Damage;

    void Update()
    {
        if (!CanDealDamage)
        {
            HitTime += Time.deltaTime;
            if (HitTime >= HitTimer)
            {
                CanDealDamage = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CanDealDamage)
            {
                other.SendMessage("RecieveLazerDamage", Damage, SendMessageOptions.DontRequireReceiver);
                CanDealDamage = false;
                HitTime = 0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CanDealDamage)
            {
                other.SendMessage("RecieveLazerDamage", Damage, SendMessageOptions.DontRequireReceiver);
                CanDealDamage = false;
                HitTime = 0f;
            }
        }
    }
}
