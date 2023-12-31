using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
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

    private float _currentVelocity= 0;

    //Vars for checking grounded
    private bool _isGrounded;
    public Rigidbody2D _rb;
    private float _depth;
    
    [Header("Ground Layer for Collision")]
    [SerializeField] private LayerMask groundLayers;

    //Vars for movement direction
    private Vector2 _moveDir;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    //Cave Parallax
    [SerializeField] private GameObject CaveBG;
    [SerializeField] private GameObject OutsideBG;

    //Vars for FireFlower, Powerstar and Invinciblity
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float starPowerLength;
    public bool HasFireFlower;
    public bool HasStarPower;
    private bool StartCountdown = false;
    private float StarPowerRemaining = 6;

    public GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        InputManager.Init(this, gm);
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       _rb = gameObject.GetComponent<Rigidbody2D>();

        if(_rb == null)
        {
            gameObject.GetComponent<Rigidbody2D>();
        }
        _depth = gameObject.GetComponentInChildren<BoxCollider2D>().bounds.size.y;
        Debug.Log(_rb);
    }
    private void Start()
    {
        HasStarPower = false;
        HasFireFlower = false;
    }

    private void Update()
    {
        animator.playbackTime = Time.deltaTime;
        transform.position += transform.rotation * (_currentVelocity * Time.deltaTime * _moveDir);
        CheckGround();

        //Star Power Calculations
        if (StartCountdown)
        {
            StarPowerRemaining = -Time.deltaTime;
            if (StarPowerRemaining < 0)
            {
                HasStarPower = false;
                StartCountdown = false;
                StarPowerRemaining = 6;
            }
        }

        //cave parallax

        if (transform.position.y < -13 && transform.position.x > 0)
        {
            CaveBG.SetActive(true);
            OutsideBG.SetActive(false);
        }
        if (transform.position.y >= -13)
        {
            CaveBG.SetActive(false);
            OutsideBG.SetActive(true);
        }


    }

    public void FixedUpdate()
    {

        Movement = speed * Time.deltaTime * _moveDir;
        if (_currentVelocity < speed && Movement.x != 0)
        {
            _currentVelocity += 0.4f;
        }
        if (_currentVelocity > 0 && Movement.x == 0)
        {
            _currentVelocity -= 0.4f;
        }
        //_-_-_-_-_-JANK ANIMATION MATH :)-_-_-_-_-_
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
        if (_rb == null) return;
        if(_isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            //Debug.Log("Jump called");
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

    }
    
    private void CheckGround()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _depth, groundLayers);
        Debug.DrawRay(transform.position, Vector2.down * _depth, Color.red, 0, false);
    }
    

    public void Death(GameObject killer)
    {
        if (killer.tag == "DeathBox")
        {
            FindObjectOfType<AudioManager>().Play("Pipe");
            GameManager.instance.LoseLife();
        }
        if (HasStarPower)
        {
            if (killer.gameObject.GetComponent<DeathBarrier>() == null) Destroy(killer);
            return;
        }
        else
        {
            if (killer != null)
            {
                //Debug.Log("die");
                FindObjectOfType<AudioManager>().Play("Pipe");
                GameManager.instance.LoseLife();
            }
        }
    }

    /**
     * This is the only part of my code I feel is necessary to comment. The powerups will call this method whenever they
     * are collected, and from here mario will correctly act and choose the powerup from the index they have provided
     * Index of 0: Fire Flower; Mario tosses out fireballs when in this state
     * Index of 1: Power Star; Mario becomes invincible and can kill enemies as if he jumped on them
     * Case Default: Do nothing; Should never be called because that's not how this works
     */
    public void PowerUpObtained(int PowerUpIndex)
    {
        switch (PowerUpIndex)
        {
            case 0:
                HasFireFlower = true;
                FindObjectOfType<AudioManager>().Play("PowerUp");
                animator.SetBool("isFire", true);
                break;
            case 1:
                StartCoroutine("StarCountdownRoutine");
                HasStarPower = true;
                break;
        }
    }

    public void AttackStart()
    {
        if (HasFireFlower)
        {
            FindObjectOfType<AudioManager>().Play("Fireball");
            GameObject ourFireBall = Instantiate(fireBall, transform.position, Quaternion.identity);
            Rigidbody2D ourFireRB = ourFireBall.GetComponent<Rigidbody2D>();

            int fixedMovement = 4;
            Vector2 fix = new Vector2(1, 0);

            if(_moveDir.x < 0)
            {
                fixedMovement = 5;
                fix = new Vector2(-1, 0);
            } else if (sprite.flipX)
            {
                fixedMovement = 5;
                fix = new Vector2(-1, 0);
            }

            ourFireRB.AddForce( fixedMovement * (_moveDir + fix) , ForceMode2D.Impulse);
            Destroy(ourFireBall,1.7f);

        }
        else
        {
            Debug.Log("No Powers?");
        }
    }
    
    private IEnumerator StarCountdownRoutine()
    {
        animator.SetBool("isStar", true);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("StarSong");
        yield return new WaitForSeconds(starPowerLength);
        HasStarPower = false;
        FindObjectOfType<AudioManager>().Stop("StarSong");
        FindObjectOfType<AudioManager>().Play("Theme");
        animator.SetBool("isStar", false);
    }
}
