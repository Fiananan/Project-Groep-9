using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    [SerializeField] private float DisappearTimer;
    [SerializeField] private float DisappearTime;

    [SerializeField] private Transform Cam;
 
    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
    }

    void Update()
    {
        transform.rotation = Cam.rotation;

        transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;

        DisappearTime += Time.deltaTime;
        if (DisappearTime >= DisappearTimer)
        {
            float DisappearSpeed = 3f;
            textColor.a -= DisappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
