using System.Collections;
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
    public Collider2D _characterCollider;
    public Collider2D _groundCollider;

    //Serialized Field Variable Initialization
    [SerializeField] bool _doubleJumpEnabled = false;
    [SerializeField] float _jumpPower = 2.0f;
    [SerializeField] float _speed = 2.0f;

    //***************
    //Awake Function to run on creation of the object
    //***************
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _canJump = false;
        _hasJumped = true;
        _characterCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        _groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
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
            sr.flipX = false;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //move left
            transform.position += Vector3.right * -_speed * Time.deltaTime;
            sr.flipX = true;
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
    }

    //***************
    //Jump function to allow character to jump depending on their object state
    //***************
    private void jump()
    {
        Vector2 force = new Vector2(0, _jumpPower);
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        _canJump = true;
        _hasJumped = false;
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        _canJump = false;
        if(_doubleJumpEnabled && !_hasJumped)
        {
            _canJump = true;
            _hasJumped = true;
        }
    }
}
