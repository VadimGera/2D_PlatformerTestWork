using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 10f;
    public float wallCheckDistance = 0.5f;
    public LayerMask walllayer;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isTouchingWall;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (!isTouchingWall)
        {
            rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
        }


        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        isTouchingWall = Physics2D.Raycast(transform.position, spriteRenderer.flipX ? Vector2.left : Vector2.right,
            wallCheckDistance, walllayer);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) &&
            (isGrounded || isTouchingWall))
        {
            if (isTouchingWall)
            {
                WallJump();
            }
            else
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }



        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
    }

    void WallJump()
    {
        Vector2 wallJumpDirection = spriteRenderer.flipX ? Vector2.right : Vector2.left;
        rb2d.velocity = new Vector2(wallJumpDirection.x * moveSpeed, wallJumpForce);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
    