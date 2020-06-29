using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] float MovementSpeed;

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float BulletSpeed;
    private float FireTimer;
    private float FireRate = 2;

    [SerializeField] private Transform[] PatrolPoints;
    private int PatrolIndex;
    private string PatrolDirection = "forward";
    
    [SerializeField] private float WaitTimer;
    private float WaitTime;

    private bool FollowingPlayer = false;

    void Update()
    {
        if (FollowingPlayer == false)
        {
            Patrol();
        }
        else if (FollowingPlayer == true)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));

            float Distance = Vector3.Distance(transform.position, Player.transform.position);

            if (Distance >= 7.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MovementSpeed * Time.deltaTime);
                FireTimer -= Time.deltaTime;
            }
            else
            {
                FireTimer -= Time.deltaTime;
                if (FireTimer <= 0)
                {
                    Shoot();
                    FireTimer = FireRate;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject Bullet = (GameObject) Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet.transform.Rotate(new Vector3(90f, FirePoint.rotation.y, 0f));
        Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.up * BulletSpeed, ForceMode.Impulse);
        Bullet.GetComponent<Bullet>().Damage = 10;
        Bullet.GetComponent<Bullet>().ShotBy = gameObject.name;
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[PatrolIndex].position, MovementSpeed * Time.deltaTime);
        transform.LookAt(new Vector3(PatrolPoints[PatrolIndex].position.x, transform.position.y, PatrolPoints[PatrolIndex].position.z));
        if (Vector3.Distance(transform.position, PatrolPoints[PatrolIndex].position) < 0.2f)
        {
            if (WaitTime >= WaitTimer)
            {
                if (PatrolDirection == "forward")
                {
                    PatrolIndex++;
                }
                else if (PatrolDirection == "backward")
                {
                    PatrolIndex--;
                }

                if (PatrolDirection == "forward" && PatrolIndex >= (PatrolPoints.Length - 1))
                {
                    PatrolDirection = "backward";
                }
                else if (PatrolDirection == "backward" && PatrolIndex <= 0)
                {
                    PatrolDirection = "forward";
                }
                WaitTime = 0f;
            }
            else
            {
                WaitTime += Time.deltaTime;
                transform.Rotate(new Vector3(0, 2.5f, 0));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FollowingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FollowingPlayer = false;
        }
    }
}
