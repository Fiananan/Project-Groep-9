using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode forwards;
    public KeyCode backwards;
    public KeyCode right;
    public KeyCode left;

    public float MovementSpeed;
    private Vector3 Direction;
    private Rigidbody rb;
    private Vector3 MousePos;

    private Camera mainCamera;

    [SerializeField] private PauseManager Pause;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (!Pause.Paused)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rotate();
            MoveInput();
        }
    }

    void FixedUpdate()
    {
        if (!Pause.Paused)
        {
            Movement();
        }
    }

    void MoveInput()
    {
        if (Input.GetKey(forwards) && Input.GetKey(backwards))
        {
            Direction = Vector3.zero;
        }
        else if (Input.GetKey(right) && Input.GetKey(left))
        {
            Direction = Vector3.zero;
        }
        else if (Input.GetKey(forwards) && Input.GetKey(right))
        {
            Direction.z = MovementSpeed;
            Direction.x = 0f;
        }
        else if (Input.GetKey(forwards) && Input.GetKey(left))
        {
            Direction.z = 0f;
            Direction.x = -MovementSpeed;
        }
        else if (Input.GetKey(backwards) && Input.GetKey(right))
        {
            Direction.z = 0f;
            Direction.x = MovementSpeed;
        }
        else if (Input.GetKey(backwards) && Input.GetKey(left))
        {
            Direction.z = -MovementSpeed;
            Direction.x = 0f;
        }
        else if (Input.GetKey(forwards))
        {
            Direction.z = MovementSpeed;
            Direction.x = -MovementSpeed;
        }
        else if (Input.GetKey(backwards))
        {
            Direction.z = -MovementSpeed;
            Direction.x = MovementSpeed;
        }
        else if (Input.GetKey(right))
        {
            Direction.z = MovementSpeed;
            Direction.x = MovementSpeed;
        }
        else if (Input.GetKey(left))
        {
            Direction.z = -MovementSpeed;
            Direction.x = -MovementSpeed;
        }
        else
        {
            Direction = Vector3.zero;
        }
    }

    void Movement()
    {
        rb.velocity = Direction;



        //if (Input.GetKey(forwards) && Input.GetKey(backwards))
        //{

        //}
        //else if (Input.GetKey(forwards))
        //{
        //    transform.position += new Vector3(-MovementSpeed, 0, MovementSpeed);
        //}
        //else if (Input.GetKey(backwards))
        //{
        //    transform.position += new Vector3(MovementSpeed, 0, -MovementSpeed);
        //}

        //if (Input.GetKey(right) && Input.GetKey(left))
        //{

        //}
        //else if (Input.GetKey(right))
        //{
        //    transform.position += new Vector3(MovementSpeed, 0, MovementSpeed);
        //}
        //else if (Input.GetKey(left))
        //{
        //    transform.position += new Vector3(-MovementSpeed, 0, -MovementSpeed);
        //}
    }

    void Rotate()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        //Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        //transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
