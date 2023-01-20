 using System.Collections;
using System.Collections.Generic;
 using System.Runtime.CompilerServices;
 using Cinemachine;
 using DG.Tweening;
 using UnityEngine;
 using UnityEngine.UI;

 public class PlayerController : MonoBehaviour
{
    public struct Stats
    {
        
    }

    private Rigidbody rb;
    public float speedIncrease = 0;
    public float rotationSpeed =20;
    public float turnAcceleration;
    public float turnDecceleration;
    public float minSpeed = 0;
    public float maxSpeed = 20;
    public float downWardSpeed;
    private float speedBoost =1;
    public float boostAmount;
    public float speedBoostTimer;
    bool hasBoosted = false;
    public Animator anim;
    private bool isGrounded = true;
    public Transform groundCheck;
    public LayerMask groundLayer;

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

        GroundCheck();
    }

    private void RightTurn()
    {
        if (transform.eulerAngles.y > 91)
        {
            transform.Rotate(new Vector3(0, -rotationSpeed, 0) * Time.deltaTime, Space.Self);
        }
    }


    private void LeftTurn()
    {
        // rotates the player, limiting them after reaching a certain angle
        if (transform.eulerAngles.y < 269)
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime, Space.Self);
        }

    }

    void FixedUpdate()
    {            
        SpeedCheck();
        MoveForward();

        if(Input.GetKeyDown(KeyCode.Space) && !hasBoosted)
        {
            SpeedBoost();
        }
        if (isGrounded)
        {


            if (Input.GetKey(KeyCode.A))
            {
                LeftTurn();
                Debug.Log("A pressed");
            }

            if (Input.GetKey(KeyCode.D))
            {
                RightTurn();
                Debug.Log("D pressed");
            }
        }
    }

    private void SpeedBoost()
    {
        hasBoosted = true;
        speedBoost = boostAmount;
        Invoke("BoostChange", speedBoostTimer);
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





    }

    public void GroundCheck()
    {
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);
        // could also use a raycast cast to achieve ^ 

        //is sending a line between ground check and player, checks for a layer -> ground
        isGrounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);

        //setting animator bool
        anim.SetBool("grounded", isGrounded);


    }

    public void BoostChange()
    {
        hasBoosted = false;
        speedBoost = 1;
    }


    void MoveForward()
    {

        // increase or decrease speed depending on how much they are facing downhill
        float turnAngle = Mathf.Abs(180 - transform.eulerAngles.y);
        downWardSpeed += Remap(0, 90, turnAcceleration, -turnDecceleration, turnAngle);



        Vector3 velocity = transform.forward * downWardSpeed * speedBoost * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        //Debug.Log("Velocity altered");
    }

    private void SpeedCheck()
    {
        // float move_x = Input.GetAxis("Horizontal");
        // Replace this with something else - a counter that has a clamp maybe
        // use Time.deltaTime
        // float move_z = Input.GetAxis("Vertical");
        downWardSpeed += Time.deltaTime * speedIncrease;
        downWardSpeed = Mathf.Clamp(downWardSpeed, minSpeed, maxSpeed);

        anim.SetFloat("playerSpeed", downWardSpeed);
    }

    private float Remap(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
        return (NewValue);
    }
}
