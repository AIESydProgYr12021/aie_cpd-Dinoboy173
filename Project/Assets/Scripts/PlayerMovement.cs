using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public ParticleSystem dustRun;
    public ParticleSystem dustLand;

    public float speed = 5.2f;
    public float speedBoost = 0.4f;
    public float defaultSpeed = 5.2f;

    public float gravity = -9.81f;

    public float jump1Height = 1.5f;
    public float jump2Height = 2f;
    public float jump3Height = 2.5f;

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

    float xAcc;
    float zAcc;

    public float jumpTimer = 0.0f;
    public float jumpTimerReset = 0.5f;

    int jumps = 0;
    int maxJumps = 3;

    Vector3 velocity;
    Vector3 move;

    bool isGrounded;
    bool isGroundedLastFrame;

    private void Start()
    {
        dustRun.Stop();
        dustLand.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && !isGroundedLastFrame)
        {
            dustLand.Play();

            FindObjectOfType<AudioManager>().Play(RandomFall());

            dustRun.Stop();
            dustRun.Play();
        }

        movingX = Input.GetAxis("Horizontal");
        movingZ = Input.GetAxis("Vertical");

        MovePlayer();

        if (movingZ != 1f && isGrounded)
        {
            dustRun.Play();
        }
        else if (!isGrounded)
        {
            dustRun.Stop();
        }

        isGroundedLastFrame = isGrounded;
    }

    string RandomFootStep()
    {
        string FootstepSound = "FootStep";
        int num = (int)Random.Range(1f, 8.9f);

        FootstepSound += num;

        return FootstepSound;
    }

    string RandomFall()
    {
        string fall = "Fall";
        int num = (int)Random.Range(1f, 2.9f);

        fall += num;

          return fall;
    }

    void MovePlayer()
    {
        // start horizontal movement ----------------------------------------------------------------------------------------------------
        // forward
        if (movingZ < 0)
        {
            if (zAcc <= maxAcceleration)
            {
                zAcc += acceleration * Time.deltaTime;

                PlayFootstep();
            }
            else
            {
                zAcc = maxAcceleration;
            }
        }
        else if (zAcc > 0)
        {
            if (isGrounded)
            {
                zAcc -= drag * Time.deltaTime;
            }
        }

        // backward
        if (movingZ > 0)
        {
            if (zAcc >= -maxAcceleration)
            {
                zAcc -= acceleration * Time.deltaTime;

                PlayFootstep();
            }
            else
            {
                zAcc = -maxAcceleration;
            }
        }
        else if (zAcc < 0)
        {
            if (isGrounded)
            {
                zAcc += drag * Time.deltaTime;
            }
        }

        // left
        if (movingX > 0)
        {
            if (xAcc >= -maxAcceleration)
            {
                xAcc -= acceleration * Time.deltaTime;

                PlayFootstep();
            }
            else
            {
                xAcc = -maxAcceleration;
            }
        }
        else if (xAcc < 0)
        {
            if (isGrounded)
            {
                xAcc += drag * Time.deltaTime;
            }
        }

        // right
        if (movingX < 0)
        {
            if (xAcc <= maxAcceleration)
            {
                xAcc += acceleration * Time.deltaTime;

                PlayFootstep();
            }
            else
            {
                xAcc = maxAcceleration;
            }
        }
        else if (xAcc > 0)
        {
            if (isGrounded)
            {
                xAcc -= drag * Time.deltaTime;
            }
        }

        if (isGrounded)
        {
            if (zAcc <= 0.1f && zAcc >= -0.1f)
                zAcc = 0;

            if (xAcc <= 0.1f && xAcc >= -0.1f)
                xAcc = 0;
        }

        x = movingX - xAcc;
        z = movingZ - zAcc;

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (footstepTimer > 0)
        {
            footstepTimer -= 0.1f * Time.deltaTime;
        }
        // end horizontal movement ----------------------------------------------------------------------------------------------------


        // start vertical movement ----------------------------------------------------------------------------------------------------

        if (isGrounded && jumpTimer > 0)
        {
            jumpTimer -= 1f * Time.deltaTime;
        }

        if (jumpTimer <= 0 || jumps >= maxJumps)
        {
            jumps = 0;

            speed = defaultSpeed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (jumps == 0 || jumps >= maxJumps)
            {
                velocity.y = Mathf.Sqrt(jump1Height * -2 * gravity);

                speed += speedBoost;
            }
            else if (jumps == 1)
            {
                velocity.y = Mathf.Sqrt(jump2Height * -2 * gravity);

                speed += speedBoost;
            }
            else if (jumps == 2)
            {
                velocity.y = Mathf.Sqrt(jump3Height * -2 * gravity);
            }

            jumps += 1;
            jumpTimer = jumpTimerReset;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        // end vertical movement ----------------------------------------------------------------------------------------------------
    }

    void PlayFootstep()
    {
        if (footstepTimer <= 0f && isGrounded)
        {
            FindObjectOfType<AudioManager>().Play(RandomFootStep());
            footstepTimer = footstepTimerReset;
        }

        if (!isGrounded)
        {
            FindObjectOfType<AudioManager>().Stop();
        }
    }
}