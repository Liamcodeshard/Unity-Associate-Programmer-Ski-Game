 using System.Collections;
using System.Collections.Generic;
 using System.Runtime.CompilerServices;
 using Cinemachine;
 using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speeed = 60;
    private Rigidbody rb;
    public float speedIncrease = 0;
    public float speed = 9.81f;
    private float rotationY;
    public float rotationSpeed =20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }


    }

    void MoveForward()
    {
       // float move_x = Input.GetAxis("Horizontal");
        float move_z = Input.GetAxis("Vertical");
        Vector3 Up = new Vector3(0f, rb.velocity.y, 0f);

        rb.velocity = (transform.forward * move_z).normalized * speed + Up;
        Debug.Log("Velocity altered");
    }
}
