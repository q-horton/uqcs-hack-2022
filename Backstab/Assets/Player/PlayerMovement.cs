using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public PlayerStats stats;


    public float speed = Globals.baseSpeed;
    public float jumpHeight = Globals.baseJumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        speed = Globals.baseSpeed * stats.speed;
        jumpHeight = Globals.baseJumpHeight * stats.jump;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (!Globals.isDead) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Globals.gravity);
            }
        }

        velocity.y += Globals.gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
