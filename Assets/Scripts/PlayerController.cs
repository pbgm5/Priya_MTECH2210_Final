using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public float speed = 5;
    public float jumpSpeed = 1;
    private Rigidbody2D rb;
    bool jumping;
    public float distanceCheckAmount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(GroundCheck());
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            jumping = true;
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
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }

    }
    public bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceCheckAmount, ground);
    }
}
