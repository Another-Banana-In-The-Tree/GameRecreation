using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Vars for speed and jumping
    [Header("Movement and Jumping Force")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
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
    }

    private void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();
        _rb = GetComponent<Rigidbody2D>();
        _depth = GetComponent<BoxCollider2D>().bounds.size.y;
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
