using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public KeyCode forwards;
    public KeyCode backwards;
    public KeyCode right;
    public KeyCode left;

    public float MovementSpeed;

    [SerializeField] private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        if (Input.GetKey(forwards) && Input.GetKey(backwards))
        {

        }
        else if (Input.GetKey(forwards))
        {
            transform.position += new Vector3(-MovementSpeed, 0, MovementSpeed);
        }
        else if (Input.GetKey(backwards))
        {
            transform.position += new Vector3(MovementSpeed, 0, -MovementSpeed);
        }

        if (Input.GetKey(right) && Input.GetKey(left))
        {

        }
        else if (Input.GetKey(right))
        {
            transform.position += new Vector3(MovementSpeed, 0, MovementSpeed);
        }
        else if (Input.GetKey(left))
        {
            transform.position += new Vector3(-MovementSpeed, 0, -MovementSpeed);
        }
    }

    void Rotate()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
