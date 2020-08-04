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
    public Collider2D _characterCollider;
    //public Collider2D _groundCollider;

    //Serialized Field Variable Initialization
    [SerializeField] bool _doubleJumpEnabled = false;
    [SerializeField] float _jumpPower = 6.5f;
    [SerializeField] float _speed = 4.5f;

    //***************
    //Awake Function to run on creation of the object
    //***************
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _canJump = false;
        _hasJumped = true;
        //_characterCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        //_groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
    }

    //***************
    //Update Function to run once per frame
    //***************
    private void Update()
    {
        //***************
        //Control statements for character movement for moving left, right, and jumping
        //***************
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //move right
            _character.transform.position += Vector3.right * _speed * Time.deltaTime;
            anim.SetBool("isWalking", true);
            sr.flipX = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //move left
            transform.position += Vector3.right * -_speed * Time.deltaTime;
            anim.SetBool("isWalking", true);
            sr.flipX = false;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            //call jump function
            if(_canJump)
            {
                jump();
            }
            if(_hasJumped)
            {
                _canJump = false;
            }
        }
        if(rb.velocity.y < 0)
        {
            Vector2 pushDown = new Vector2(0, -1);
            rb.AddForce(pushDown, ForceMode2D.Force);
        }
    }

    //***************
    //Jump function to allow character to jump depending on their object state
    //***************
    private void jump()
    {
        rb.velocity = new Vector2(0, _jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        _canJump = true;
        _hasJumped = false;
        anim.SetBool("inAir", false);
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        _canJump = false;
        anim.SetBool("inAir", true);
        if(_doubleJumpEnabled && !_hasJumped)
        {
            _canJump = true;
            _hasJumped = true;
        }
    }
}
