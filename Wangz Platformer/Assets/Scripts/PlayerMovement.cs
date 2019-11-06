using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Used to reference controller script
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Checks if user is trying to jump
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if(Input.GetButtonDown("Crouch") || Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch") || Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //Moves player 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; //Resets jump 
    }
}
