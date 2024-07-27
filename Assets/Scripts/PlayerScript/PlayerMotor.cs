using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5F;
    public float gravity = -9.8F;
    public float jumpHeight = 1F;
    /*public bool crouching = false;
    public float crouchTimer = 1;
    public bool lerpCrouch = false;*/
    public bool sprinting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        /*if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(-controller.height, 2, p);

            if (p > 1)
                lerpCrouch = false;
                crouchTimer = 0F;
        }*/
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0F * gravity);
        }
    }

    /*public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }*/

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 10;
        else
            speed = 4;
    }
}
