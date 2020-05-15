using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private float MovementSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Player.transform.position + new Vector3(5.83f, 8.780001f, -5.83f);
    }
}
