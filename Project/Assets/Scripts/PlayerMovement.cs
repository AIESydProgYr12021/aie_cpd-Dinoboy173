using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public ParticleSystem dustRun;
    public ParticleSystem dustLand;

    public VirtualJoystick joystick;

    public float speed = 5.2f;
    public float speedBoost = 0.4f;
    public float defaultSpeed = 5.2f;

    float gravity = -9.81f;

    Dictionary<int, float> jumpHeight = new Dictionary<int, float>();

    public float maxAcceleration = 0.8f;
    public float acceleration = 0.6f;
    public float drag = 0.9f;

    public float footstepTimer = 1.0f;
    public float footstepTimerReset = 0.3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float x;
    float z;

    float movingX;
    float movingZ;
    bool movingY;

    float xAcc;
    float zAcc;

    public float jumpTimer = 0.0f;
    public float jumpTimerReset = 0.7f;

    int jumps = 0;
    int maxJumps = 3;

    Vector3 velocity;
    Vector3 move;

    bool isGrounded;
    bool isGroundedLastFrame;

    bool virtualJump;

    bool isMK;
    bool isTouch;
    bool isController;

    private void Start()
    {
        dustRun.Stop();
        dustLand.Stop(); // safety check if particales are running

        virtualJump = FindObjectOfType<JumpScript>().jump;

        isMK = FindObjectOfType<InputType>().MK;
        isTouch = FindObjectOfType<InputType>().touch; // gets bool from another script
        isController = FindObjectOfType<InputType>().controller;

        jumpHeight.Add(0, 1.5f);
        jumpHeight.Add(1, 2f);
        jumpHeight.Add(2, 2.5f); // different jump heights
    }

    void Update()
    {
        isMK = FindObjectOfType<InputType>().MK;
        isTouch = FindObjectOfType<InputType>().touch; // gets bools from another script
        isController = FindObjectOfType<InputType>().controller;

        var GUI = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // if player is on ground

        if (isGrounded && !isGroundedLastFrame) // Things to play when hit the ground
        {
            dustLand.Play();

            FindObjectOfType<AudioManager>().Play(RandomFall());

            dustRun.Stop();
            dustRun.Play();
        }

        if (isMK || isController && GUI.enabled)
        {
            movingX = Input.GetAxis("Horizontal");
            movingZ = Input.GetAxis("Vertical"); // keyboard x and z input
            movingY = Input.GetButtonDown("Jump"); // keyboard y input
        }

        if (isTouch)
        {
            virtualJump = FindObjectOfType<JumpScript>().jump;

            movingX = joystick.Direction.x;
            movingZ = joystick.Direction.z; // touch x and z input
            movingY = virtualJump;
        }

        MovePlayer();

        if (movingZ != 1f && isGrounded)
        {
            dustRun.Play(); // play dust particles when on the ground and moving forward
        }
        else if (!isGrounded)
        {
            dustRun.Stop(); // if not on ground and moving forward stop dust particles
        }

        isGroundedLastFrame = isGrounded; // stores weather or not is on ground this frame to be used next frame
    }

    string RandomFootStep()
    {
        string FootstepSound = "FootStep"; // the worded name of the footstep sound without its number - needs to change if naming convention changes
        int num = (int)Random.Range(1f, 8.9f); // chooses a random footstep sound from 8

        FootstepSound += num; // adds the number to the string to get a footstep sound

        return FootstepSound;
    }

    string RandomFall()
    {
        string landing = "Landing"; // the worded name of the laning sound without its number - needs to change if naming convention changes
        int num = (int)Random.Range(1f, 2.9f); // chooses random hit ground sound from 2

        landing += num; // adds the number to the string to get a landin sound

        return landing;
    }

    void MovePlayer()
    {
        // start horizontal movement ----------------------------------------------------------------------------------------------------
        // forward
        if (movingZ > 0) // is being moved forward by player?
        {
            if (zAcc <= maxAcceleration) // is z acceleration less than max acceleration?
            {
                zAcc -= acceleration * Time.deltaTime;

                PlayFootstep();
            }
            if (zAcc < -maxAcceleration) // is z acceleration greater than max acceleration?
            {
                zAcc = -maxAcceleration;
            }
        }
        else if (zAcc < 0) // is being moved forward by acceleration?
        {
            if (isGrounded) // is on ground?
            {
                zAcc += drag * Time.deltaTime; // slow down
            }
        }

        // backward
        if (movingZ < 0) // is being moved backward by player?
        {
            if (zAcc >= -maxAcceleration)// is z acceleration less than max acceleration?
            {
                zAcc += acceleration * Time.deltaTime;

                PlayFootstep();
            }
            if (zAcc > maxAcceleration) // is z acceleration greater than max acceleration?
            {
                zAcc = maxAcceleration;
            }
        }
        else if (zAcc > 0) // is being moved backward by acceleration?
        {
            if (isGrounded) // is on ground?
            {
                zAcc -= drag * Time.deltaTime; // slow down
            }
        }

        // left
        if (movingX < 0) // is being moved left be player?
        {
            if (xAcc >= -maxAcceleration) // is x acceleration less than max acceleration?
            {
                xAcc += acceleration * Time.deltaTime;

                PlayFootstep();
            }
            if (xAcc > maxAcceleration) // is x acceleration less than max acceleration?
            {
                xAcc = maxAcceleration;
            }
        }
        else if (xAcc > 0) // is being moved left by acceleration?
        {
            if (isGrounded) // is on ground?
            {
                xAcc -= drag * Time.deltaTime; // slow down
            }
        }

        // right
        if (movingX > 0) // is being moved right by player?
        {
            if (xAcc <= maxAcceleration) // is x acceleration less than max acceleration?
            {
                xAcc -= acceleration * Time.deltaTime;

                PlayFootstep();
            }
            if (xAcc < -maxAcceleration) // is x acceleration greater than max acceleration?
            {
                xAcc = -maxAcceleration;
            }
        }
        else if (xAcc < 0) // is being moved by acceleration?
        {
            if (isGrounded) // is on ground?
            {
                xAcc += drag * Time.deltaTime; // slow down
            }
        }

        if (isGrounded) // set to 0 if in small enough range and if on ground
        {
            if (zAcc <= 0.01f && zAcc >= -0.01f)
                zAcc = 0;
        
            if (xAcc <= 0.01f && xAcc >= -0.01f) 
                xAcc = 0;
        }

        x = movingX - xAcc;
        z = movingZ - zAcc; // adds acceleration to the x and z

        move = transform.right * x + transform.forward * z; // adds x and z into movement vector

        controller.Move(move * speed * Time.deltaTime); // moves player on x and z

        if (footstepTimer > 0) // time between footsteps
        {
            footstepTimer -= 0.1f * Time.deltaTime;
        }
        // end horizontal movement ----------------------------------------------------------------------------------------------------


        // start vertical movement ----------------------------------------------------------------------------------------------------
        if (isGrounded && jumpTimer > 0 && jumps > 0) // time before jumps resets
        {
            jumpTimer -= 1f * Time.deltaTime;
        }

        if (jumpTimer <= 0 || jumps >= maxJumps) // resets jumps and speed
        {
            jumps = 0;

            speed = defaultSpeed;
        }

        if (movingY && isGrounded) // is jump and is grounded?
        {
            velocity.y = Mathf.Sqrt(jumpHeight[jumps] * -2 * gravity); // math for jump

            speed += speedBoost;

            jumps += 1;
            jumpTimer = jumpTimerReset;
        }

        if (!isGrounded) // give the player gravity when in the air
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (isGrounded && velocity.y < 0) // stops gravity accumulating when on ground
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime); // moves player on the y axis
        // end vertical movement ----------------------------------------------------------------------------------------------------
    }

    void PlayFootstep()
    {
        if (footstepTimer <= 0f && isGrounded) // play sound if timer is done and is on ground
        {
            FindObjectOfType<AudioManager>().Play(RandomFootStep()); // play footstep sound
            footstepTimer = footstepTimerReset; // reset timer
        }

        if (movingY) // stop playing if in air
        {
            FindObjectOfType<AudioManager>().Stop();
        }
    }
}