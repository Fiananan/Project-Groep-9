using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private Vector3 Offset;

    void Update()
    {
        transform.position = Player.transform.position + new Vector3(5.83f, 8.780001f, -5.83f);
    }
}
