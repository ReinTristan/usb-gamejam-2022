using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;

    public float RunSpeed = 40f;

    float HorizontalMove = 0f;
    bool bJump = false;


    // Update is called once per frame
    void Update()
    {
         HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            bJump = true;
        }

    }

    void FixedUpdate()
    {
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, false, bJump);
        bJump = false;
    }
}
