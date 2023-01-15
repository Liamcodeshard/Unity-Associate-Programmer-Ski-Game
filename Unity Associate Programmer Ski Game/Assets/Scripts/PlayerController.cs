 using System.Collections;
using System.Collections.Generic;
 using System.Runtime.CompilerServices;
 using Cinemachine;
 using DG.Tweening;
 using UnityEngine;
 using UnityEngine.UI;

 public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speedIncrease = 0;
    public float speed = 9.81f;
    private float rotationInput;
    private float rotationMax = 100;
    private float rotationMin = -10;
    public float rotationSpeed =20;
    public float minSpeed = 0;
    public float maxSpeed = 20;
    public float downWardSpeed;
    public Animator anim;
    private bool isGrounded = true;
    public Transform groundCheck;

    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        RotatePlayer();
        GroundCheck();
        // Debug.Log(downWardSpeed);

    }

    private void RotatePlayer()
    {
        /*
        ==================does not clamp 
        rotationInput = Input.GetAxis("Horizontal");

         direction = new Vector2(Mathf.Clamp(rotationInput * rotationSpeed * Time.deltaTime, -90, 90),
             0);
         transform.Rotate(0,direction.x, 0);

        ======closest to working===== but you canmot feed a negative number into euerangles

         Vector3 playerEuler = transform.rotation.eulerAngles;
         playerEuler.y = Mathf.Clamp(playerEuler.y, -90, 2);
         //playerEuler.y = Mathf.Clamp(playerEuler.y, -190, -90 );
         transform.rotation = Quaternion.Euler(playerEuler);
        ===========Does not clamp =====

         transform.localEulerAngles = new Vector3(Mathf.Clamp((transform.localEulerAngles.x <= 180) ? transform.localEulerAngles.x :
                                                -(360 - transform.localEulerAngles.x), rotationMin, rotationMax), 
                                                transform.localEulerAngles.y,
                                                transform.localEulerAngles.z);


         */
        if(isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
        }




    }

    public void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);
        anim.SetBool("grounded", isGrounded);


    }


    void MoveForward()
    {
        // float move_x = Input.GetAxis("Horizontal");
        // Replace this with something else - a counter that has a clamp maybe
        // use Time.deltaTime
        // float move_z = Input.GetAxis("Vertical");
        downWardSpeed += Time.deltaTime;
        if (isGrounded)
        {
            anim.SetFloat("playerSpeed", downWardSpeed);
            downWardSpeed = Mathf.Clamp(downWardSpeed, minSpeed, maxSpeed);

            Vector3 Up = new Vector3(0f, rb.velocity.y, 0f);

            rb.velocity = (transform.forward).normalized * downWardSpeed + Up;
        }
        //Debug.Log("Velocity altered");
    }
}
