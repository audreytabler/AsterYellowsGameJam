using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    Vector2 clampedMovement;
    public Animator animator;
    public AudioSource footsteps;

    private bool FacingRight = true;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontalMovespeed", Math.Abs(movement.x));
        if(Math.Abs(movement.y) > 0)
        {
            animator.SetFloat("horizontalMovespeed", Math.Abs(movement.y));
        }
        if((Math.Abs(movement.x) > 0) || (Math.Abs(movement.y) > 0))
        {
            footsteps.mute= false;
        }
        else
            footsteps.mute= true;

        movement.x = Input.GetAxisRaw("Horizontal"); // it gives us a value between -1 and 1
        movement.y = Input.GetAxisRaw("Vertical");

        clampedMovement = Vector2.ClampMagnitude(movement, 1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (clampedMovement * moveSpeed * Time.fixedDeltaTime));
        if (movement.x > 0 && FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && !FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
