using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int stage = 1;
    [SerializeField] private float Stage1HP;
    [SerializeField] private float Stage2HP;
    [SerializeField] private float Stage3HP;
    public float HP;

    [SerializeField] private GameObject DamagePopUp;

    private GameObject stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics");

        HP = Stage1HP;

        ChangeColor(stage);
    }

    void Update()
    {
        if (HP <= 0)
        {
            stats.SendMessage("AddScore", 100, SendMessageOptions.DontRequireReceiver);
            if (stage == 1)
            {
                stage++;
                HP = Stage2HP;
                ChangeColor(stage);
            }
            else if (stage == 2)
            {
                stage++;
                HP = Stage3HP;
                ChangeColor(stage);
            }
            else if (stage == 3)
            {
                Destroy(gameObject);
                ChangeColor(stage);
            }
        }
    }

    void ChangeColor(int stage)
    {
        switch (stage)
        {
            case 1:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 3:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    void RecieveDamage(BulletParameters BulletParams)
    {
        int damage = BulletParams.Damage;
        string ShotBy = BulletParams.ShotBy;

        if (ShotBy == "Player")
        {
            stats.SendMessage("ShotHit", SendMessageOptions.DontRequireReceiver);
            stats.SendMessage("AddScore", 25, SendMessageOptions.DontRequireReceiver);
        }

        HP -= damage;
        GameObject PopUp = Instantiate(DamagePopUp, transform.position + new Vector3(0, 2, 0), transform.rotation);
        PopUp.GetComponent<DamagePopUp>().Setup(damage);
    }
}
