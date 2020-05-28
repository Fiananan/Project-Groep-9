using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{
    [SerializeField] private Transform cam;

    void Update()
    {
        transform.rotation = cam.rotation;
    }
}
