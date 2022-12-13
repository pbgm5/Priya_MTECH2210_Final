using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public float speed = 5;
    public float jumpSpeed = 1;
    float xMove;
    private Rigidbody2D rb;
    bool jumping;
    public float distanceCheckAmount = 0;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer > ();
    }

    void Update()
    {
        print("Velocity: " + rb.velocity.x);
        Debug.Log(GroundCheck());
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            jumping = true;
        }

        xMove = Input.GetAxisRaw("Horizontal");

        if (xMove != 0)
        {
            if (xMove < 0)
            {
                sr.flipX = false;
            }
            else if (xMove > 0)
            {
                sr.flipX = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }

        if (jumping == true)
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }

    }
    public bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceCheckAmount, ground);
    }
}
