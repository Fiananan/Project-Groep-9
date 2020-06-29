using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actions
{
    Move = 0,
    Teleport,
    Attack,
    Dodge,
    Special,
}

public enum MoveDirection
{
    up = 0,
    right,
    down,
    left,
}

public class BossActions : MonoBehaviour
{
    [Header("General")]
    private BossHealth Health;

    private bool cooldown;
    private float attackTimer;
    [SerializeField] private float attackTimerShort, attackTimerMid, attackTimerLong;
    [SerializeField] private int BossProjectileDamage;

    [Header("Move")]
    [SerializeField] private float moveDistance;
    [SerializeField] private int BossMeleeDamage;

    [Header("Teleport Behind Player")]
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private GameObject teleportParticle;
    private Transform tpLocation;

    [Header("Attack")]
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform[] FirePoints;
    [SerializeField] private float BulletSpeed;

    [Header("Random TP")]
    [SerializeField] private Transform[] bossRandomTPLocations;

    [Header("BulletStorm")]
    [SerializeField] private float BulletStormRotateSpeed;
    private bool BulletStormActive = false;
    [SerializeField] private float BulletStormTimer;
    private float BulletStormTime;
    [SerializeField] private float BulletStormFireTimer;
    private float BulletStormFireTime;

    void Start()
    {
        Health = GetComponent<BossHealth>();
        ChooseAction();
    }

    void Update()
    {
        if (!BulletStormActive)
        {
            if (cooldown)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer < 0)
                {
                    ChooseAction();
                }
            }
        }
        else
        {
            transform.Rotate(0, BulletStormRotateSpeed * Time.deltaTime, 0);
            BulletStormTime += Time.deltaTime;
            if (BulletStormTime >= BulletStormTimer)
            {
                transform.Rotate(0, BulletStormRotateSpeed * Time.deltaTime, 0);
                BulletStormActive = false;
                BulletStormTime = 0f;
                BulletStormFireTime = 0f;
            }

            BulletStormFireTime += Time.deltaTime;
            if (BulletStormFireTime >= BulletStormFireTimer)
            {
                for (int i = 0; i < FirePoints.Length; i++)
                {
                    GameObject Bullet = Instantiate(BulletPrefab, FirePoints[i].position, FirePoints[i].rotation);
                    Bullet.GetComponent<Rigidbody>().AddForce(-(Bullet.transform.forward.normalized) * BulletSpeed, ForceMode.Impulse);
                    Bullet.GetComponent<Bullet>().Damage = BossProjectileDamage;
                    Bullet.GetComponent<Bullet>().ShotBy = "Boss";
                    Bullet.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                }
                BulletStormFireTime = 0f;
            }
        }
    }

    void ChooseAction()
    {
        cooldown = false;

        int randomAction;

        switch (Health.stage)
        {
            case 1:
                randomAction = Random.Range(0, 10);
                ChangeAction(randomAction < 7 ? 0 : randomAction - 7);
                break;
            case 2:
                randomAction = Random.Range(0, 11);
                ChangeAction(randomAction < 7 ? 0 : randomAction - 7);
                break;
            case 3:
                randomAction = Random.Range(0, 12);
                ChangeAction(randomAction < 7 ? 0 : randomAction - 7);
                break;
        }
    }

    void ChangeAction(int actionIndex)
    {
        switch (actionIndex)
        {
            case 0:
                MoveDirection randomDirection = (MoveDirection)Random.Range(0, 4);
                Move(randomDirection);
                attackTimer = attackTimerShort;
                cooldown = true;
                break;
            case 1:
                StartCoroutine(TeleportBehindPlayer());
                attackTimer = attackTimerLong;
                cooldown = true;
                break;
            case 2:
                Attack();
                attackTimer = attackTimerMid;
                cooldown = true;
                break;
            case 3:
                StartCoroutine(Dodge());
                attackTimer = attackTimerMid;
                cooldown = true;
                break;
            case 4:
                BulletStorm();
                attackTimer = attackTimerLong;
                cooldown = true;
                break;
        }
    }

    void BulletStorm()
    {
        BulletStormActive = true;
    }

    IEnumerator Dodge()
    {
        int randomLocation = Random.Range(0, bossRandomTPLocations.Length);
        GameObject Particle = Instantiate(teleportParticle, bossRandomTPLocations[randomLocation].position, teleportParticle.transform.rotation);
        yield return new WaitForSeconds(1.3f);
        transform.position = Particle.transform.position;
    }

    void Attack()
    {
        for (int i = 0; i < FirePoints.Length; i++)
        {
            GameObject Bullet = Instantiate(BulletPrefab, FirePoints[i].position, FirePoints[i].rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(-(Bullet.transform.forward.normalized) * BulletSpeed, ForceMode.Impulse);
            Bullet.GetComponent<Bullet>().Damage = BossProjectileDamage;
            Bullet.GetComponent<Bullet>().ShotBy = "Boss";
            Bullet.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

    IEnumerator TeleportBehindPlayer()
    {
        Transform tpLoc = teleportPoint;
        tpLocation = teleportPoint;
        GameObject Particle = Instantiate(teleportParticle, tpLocation.position, teleportParticle.transform.rotation);
        yield return new WaitForSeconds(1.3f);
        transform.position = Particle.transform.position;
    }

    private void Move(MoveDirection direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 target = Vector3.zero;
        switch (direction)
        {
            case MoveDirection.up:
                target = Vector3.forward;
                break;
            case MoveDirection.left:
                target = Vector3.left;
                break;
            case MoveDirection.right:
                target = Vector3.right;
                break;
            case MoveDirection.down:
                target = Vector3.back;
                break;
        }
        transform.position = Vector3.MoveTowards(transform.position, startPosition + (target * moveDistance), 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BulletParameters tempBullet = new BulletParameters(BossMeleeDamage, "Boss");
            collision.gameObject.SendMessage("RecieveDamage", tempBullet, SendMessageOptions.DontRequireReceiver);
            GameObject.FindGameObjectWithTag("KilledBy").GetComponent<KilledBy>().SetKilledBy("Boss");
        }
    }
}
