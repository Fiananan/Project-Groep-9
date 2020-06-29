using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInXSeconds : MonoBehaviour
{
    [SerializeField] float duration;

    void Start()
    {
        Invoke("DestroyObject", duration);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
