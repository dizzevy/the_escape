using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGround;
    Vector3 velocity;

    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float groundCheckScale = 0.4f;
    [SerializeField] private float jumpHeigh = 3f;


    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundCheckScale, groundMask);

        if (isGround && velocity.y < 0)
            velocity.y = -2f;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime); ;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        else
        {
            speed = 3f;
        }
    }
}
