using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float PlSpeed = 10;

    public LayerMask groundLayer;

    private SpriteRenderer mySpriteRenderer;
    Animator anim;

    private Rigidbody2D rigidbody2d;

    // This function checks if the player is on the ground
    bool IsGrounded()
    {
        // Sets up raycast info to relate to the players location
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        // Creates a line that angles downward
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            //If the raycast hits the ground
            return true;
        }
        //If the raycast does not hit a ground layer
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calls to the players sprite renderer
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        //Calls to the players animator
        anim = GetComponent<Animator>();

        //Calls to the players rigidbody
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Everything relating to left and right movement
        PlMovement();

        // Is the player on the ground
        GroundCheck();

        //If the player is on the ground while pressing the w key
        if ((Input.GetKeyDown(KeyCode.W)) && (IsGrounded() == true))
        {
            //Then the player can jump
            PlJump();
        }
        
    }

    //Players basic movement Options
    void PlMovement()
    {
        //If the player holds right...
        if (Input.GetKey(KeyCode.D))
        {
            //They move right
            transform.Translate(Vector2.right * PlSpeed * Time.deltaTime);
            //Change to run Animation
            anim.SetBool("IsMoving", true);
            //Find Sprite Renderer...
            if (mySpriteRenderer != null)
            {
                // flip the sprite right
                mySpriteRenderer.flipX = false;
            }
            //Megaman X esque dash
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                float DashSpeed = 7f;
                // Basic jump
                rigidbody2d.velocity = Vector2.right * DashSpeed;
            }
        }
        //If the player holds left...
        else if (Input.GetKey(KeyCode.A))
        {
            //They move left
            transform.Translate(Vector2.left * PlSpeed * Time.deltaTime);
            //Change to run Animation
            anim.SetBool("IsMoving", true);
            //Find Sprite Renderer...
            if (mySpriteRenderer != null)
            {
                // flip the sprite left
                mySpriteRenderer.flipX = true;
            }
            //Megaman X esque dash
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                float DashSpeed1 = 7f;
                // Basic jump
                rigidbody2d.velocity = Vector2.left * DashSpeed1;
            }
        }

        //If the player is not holding any direction...
        else
        {
            //Return to the idle animation
            anim.SetBool("IsMoving", false);
        }
    }

    void GroundCheck()
    {
        // If the player is on the ground, mirror that in the animator
        if (IsGrounded() == true)
        {
            anim.SetBool("OnGround", true);
        }
        // If the player is not on the ground, mirror that in the animator
        else
        {
            anim.SetBool("OnGround", false);
        }
    }

    void PlJump()
    {
        // Jump Height
        float jumpVelocity = 15f;
        // Basic jump
        rigidbody2d.velocity = Vector2.up * jumpVelocity;
    }

    //If the player comes into contact with something...
    void OnCollisionEnter2D(Collision2D collision)
    {
        // And it is tagged as an Enemy...
        if (collision.gameObject.tag == "Enemy")
        {
            //Go to Game Over
            SceneManager.LoadScene("GameOver");

        }
    }
}
