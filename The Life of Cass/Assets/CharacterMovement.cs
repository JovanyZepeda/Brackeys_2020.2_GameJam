//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variable Declaration
    private bool _canJump;
    private bool _hasJumped;
    public GameObject _character;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;

    //Serialized Field Variable Initialization
    [SerializeField] bool _doubleJumpEnabled = false;
    [SerializeField] float _jumpPower = 6.5f;
    [SerializeField] float _speed = 4.5f;

    //***************
    //Awake Function to run on creation of the object
    //***************
    private void Awake()
    {
        //initiallize all variables
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _canJump = false;
        _hasJumped = true;
    }

    //***************
    //Update Function to run once per frame
    //***************
    private void Update()
    {
        //***************
        //Control statements for character movement for moving left, right, and jumping
        //***************

        //Right Movement
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //move right with set speed
            _character.transform.position += Vector3.right * _speed * Time.deltaTime;

            //set walking animation
            anim.SetBool("isWalking", true);

            //Flip the character asset around the x axis
            sr.flipX = true;
        }

        //Left Movement
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //move left with set speed
            transform.position += Vector3.right * -_speed * Time.deltaTime;

            //set walking animation
            anim.SetBool("isWalking", true);

            //Set character asset around to the normal x axis
            sr.flipX = false;
        }
        else
        {
            //If not walking, then dont play the walking animation
            anim.SetBool("isWalking", false);
        }

        //Jumping Movement
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            //call jump function
            if(_canJump)
            {
                jump();
            }

            //If you already used all of your jumps, then you cannot jump again
            if(_hasJumped)
            {
                _canJump = false;
            }
        }
        //***************
        //Downward Force for smoother jump feel
        //***************
        if(rb.velocity.y < 0)
        {
            //add a slight downward force to the character
            rb.AddForce(Vector2.down, ForceMode2D.Force);
        }
    }

    //***************
    //Jump function to allow character to jump depending on their object state
    //***************
    private void jump()
    {
        //Play the jumping Sound effect
        FindObjectOfType<AudioManager>().PlaySound("Jump");

        //Set a new upward velocity to the character to simulate a jumping effect
        rb.velocity = new Vector2(0, _jumpPower);
    }

    //Call function if the player has interacted with another object such as the ground
    private void OnCollisionEnter2D(Collision2D collider)
    {
        //player will be able to jump again
        _canJump = true;
        _hasJumped = false;

        //stop playing the jump animation
        anim.SetBool("inAir", false);
    }

    //Call function if the player has left another object such as the ground
    private void OnCollisionExit2D(Collision2D collider)
    {
        //player is in the air and cannot jump
        _canJump = false;

        //Check if double jumping is allowed
        if(_doubleJumpEnabled && !_hasJumped)
        {
            //allow the player to jump a second time if they can
            _canJump = true;
            _hasJumped = true;
        }

        //Play the jumping animation 
        anim.SetBool("inAir", true);
    }
}
