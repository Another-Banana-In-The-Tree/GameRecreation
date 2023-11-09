using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{

    //_-_-_-ANIMATION-_-_-_
    public Animator animator;
    //_-_-_-_-_-_-_-_-_-_-_


    //Vars for speed and jumping
    [Header("Movement and Jumping Force")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 Movement; //checks movement for animations
    SpriteRenderer sprite;
    
    //Vars for checking grounded
    private bool _isGrounded;
    private Rigidbody2D _rb;
    private float _depth;
    
    [Header("Ground Layer for Collision")]
    [SerializeField] private LayerMask groundLayers;

    //Vars for movement direction
    private Vector2 _moveDir;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Start()
    {
        InputManager.Init(this);
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();
        _rb = GetComponent<Rigidbody2D>();
        _depth = GetComponent<BoxCollider2D>().bounds.size.y;


        //_-_-_-_-_-JANK ANIMATION MATH :)-_-_-_-_-_
        Movement = speed * Time.deltaTime * _moveDir;
        float Movef = (float)Movement.x;
        animator.SetFloat("Speed", Mathf.Abs(Movef));

        if (Movement.x > 0) 
        {
            sprite.flipX = false;
        }

        else if (Movement.x < 0) 
        {
            sprite.flipX = true;
        }

        if (_isGrounded == true)  
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

    }
    
    public void SetMovementDirection(Vector2 newDirection)
    {
        _moveDir = newDirection;
    }
    
    public void Jump() {
        
        if(_isGrounded)
        {
            Debug.Log("Jump called");
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

    }
    
    private void CheckGround()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _depth, groundLayers);
        
        Debug.DrawRay(transform.position, Vector2.down * _depth, Color.red, 0, false);
    }
    
}
