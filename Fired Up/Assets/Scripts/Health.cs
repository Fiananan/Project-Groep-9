using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    public float HP;

    [SerializeField] private GameObject DamagePopUp;

    private GameObject stats;

    private LevelCompletion levelCompletion;

    void Start()
    {
        levelCompletion = FindObjectOfType<LevelCompletion>();

        stats = GameObject.FindGameObjectWithTag("Statistics");

        HP = MaxHP;
    }

    void Update()
    {
        if (HP <= 0)
        {
            stats.SendMessage("AddScore", 100, SendMessageOptions.DontRequireReceiver);
            levelCompletion.EnemyCount--;
            Destroy(transform.parent.gameObject);
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
