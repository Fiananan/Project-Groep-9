using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public bool Died;

    [SerializeField] private float MaxHP;
    public float HP;

    [SerializeField] private GameObject DamagePopUp;

    private GameObject stats;

    private bool GaveDeathScore = false;
    [SerializeField] private GameObject RedKeyCard;
    private bool KeyCardEnabled = false;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Statistics");

        HP = MaxHP;
    }

    void Update()
    {
        if (!Died && HP <= 0)
        {
            if (!GaveDeathScore)
            {
                stats.SendMessage("AddScore", 100, SendMessageOptions.DontRequireReceiver);
                GaveDeathScore = true;
            }
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Died = true;
        }
        if (Died && !KeyCardEnabled)
        {
            RedKeyCard.SetActive(true);
            KeyCardEnabled = true;
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
