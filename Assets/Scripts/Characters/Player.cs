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
    private Rigidbody _rb;
    private float _depth;
    
    [Header("Ground Layer for Collision")]
    [SerializeField] private LayerMask groundLayers;

    //Vars for movement direction
    private Vector3 _moveDir;

    private void Start()
    {
        InputManager.Init(this);
    }

    private void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();
    }
    
    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }
    
    public void Jump() {
        Debug.Log("Jump called");
        if(_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void CheckGround()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _depth, groundLayers);

        Debug.DrawRay(transform.position, Vector3.down * _depth, Color.red, 0, false);
    }
    
}
