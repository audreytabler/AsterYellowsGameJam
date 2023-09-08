using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    Vector2 clampedMovement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // it gives us a value between -1 and 1
        movement.y = Input.GetAxisRaw("Vertical");

        clampedMovement = Vector2.ClampMagnitude(movement, 1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (clampedMovement * moveSpeed * Time.fixedDeltaTime));
    }
}
