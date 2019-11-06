using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Used to reference controller script
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Checks if user is trying to jump
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        /* //Sprint - not implemented correctly
        if(Input.GetKeyDown("left shift"))
        {
            runSpeed = 50f;
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }*/
    }

    void FixedUpdate()
    {
        //Moves player 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false; //Resets jump 
    }
}
