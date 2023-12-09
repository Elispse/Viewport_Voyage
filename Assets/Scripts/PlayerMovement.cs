using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;                             // Player's Rigidbody2D component
    private BoxCollider2D coll;                         // Player's BoxCollider2D component
    private SpriteRenderer sprite;                      // Player's SpriteRenderer component
    private Animator anim;                              // Player's Animator component

    [SerializeField] private LayerMask jumpableGround;  // Allows Player to identify Ground
                                                        // [SerializeField] allows a value to be edited directly within Unity without making it public
    private float dirX = 0.0f;
    private float dirY = 0.0f;
    private float mayJump = 0.2f;                       // Player's Coyote Time
    [SerializeField] private float jumpForce = 14.0f;   // Player's Applied Vertical Velocity
    [SerializeField] private float moveSpeed = 7.0f;    // Player's Applied Horizontal Velocity
    public AudioSource audioSource;
    private bool canClimb = false;

    private enum MovementState 
    { 
        idle,          // 0
        running,       // 1
        jumping,       // 2
        falling,       // 3
        crouch         // 4
    }


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirY = Input.GetAxisRaw("Vertical");

        // Moves Player Left or Right when Horizontal keys are pressed
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (canClimb && dirY != 0)
        {
            rb.velocity = new Vector2(0, dirY * moveSpeed);
        }

        if (IsGrounded())
        {
            mayJump = 0.2f;
        }
        else if (!IsGrounded())
        {
            mayJump -= Time.deltaTime;
            if (mayJump < 0) mayJump = 0;
        }

        // Moves Player Up when Jump key is pressed
        if (Input.GetButtonDown("Jump") && mayJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            FindObjectOfType<AudioManager>().Play("Jump");
        }

        // Allows Player to perform a tiny jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.0f && mayJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        UpdateAnimationState();
    }

    // Updates Player sprite based on AnimationState
    private void UpdateAnimationState()
    {
        MovementState state = MovementState.idle;

        if (dirX > 0.0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0.0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (Input.GetButton("Crouch") && IsGrounded())
        {
            state = MovementState.crouch;
        }
        else
        {
            state = MovementState.idle;
        }


        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
        }
    }

    // Checks if Player is on ground using BoxCast
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0.0f, Vector2.down, 0.1f, jumpableGround);
    }
}
