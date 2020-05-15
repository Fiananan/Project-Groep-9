using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    [SerializeField] private float HP;

    [SerializeField] private GameObject DamagePopUp;

    void Start()
    {
        HP = MaxHP;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void RecieveDamage(int damage)
    {
        HP -= damage;
        GameObject PopUp = Instantiate(DamagePopUp, transform.position + new Vector3(0, 2, 0), transform.rotation);
        PopUp.GetComponent<DamagePopUp>().Setup(damage);
    }
}
