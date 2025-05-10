using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS
    public float speed = 4.0f; // Player's speed
    public float jumpHeight = 6.0f; // Player's jump height
    public float speedBonus = 1.5f; // Player's speed bonus when pressing shift 

    private float input; // Player's keyboard input
    public float currentSpeed; // Player's current speed 
    public bool grounded;

    // COMPONENTS
    private Rigidbody2D _rigidbody2D;
    private GameObject _absorbArea;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public Contador contador;

    private void Awake()
    {
        // INITIALIZE COMPONENTS
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _absorbArea = transform.GetChild(0).gameObject;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        // SET INITIAL CURRENT SPEED 
        currentSpeed = speed;

        GameObject auxCont = GameObject.Find("ObjectManager");
        contador = auxCont.GetComponent<Contador>();
    }

    private void Update()
    {
        // JUMP DETECTION
        jump();

        // FLIP SPRITE TO THE LEFT
            // GET PLAYER'S INPUT
            input = Input.GetAxis("Horizontal");
        
            if (input != 0) {
                flipCharacter(); 
            }

        // SHIFT KEY BONUS SPEED
            // INCREASE SPEED WHEN PRESSING SHIFT
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (currentSpeed < (speed * speedBonus))
                {
                    currentSpeed *= speedBonus;
                    _animator.SetFloat("yVelocity", Mathf.Abs(currentSpeed));
            }
            }

            // RESET SPEED WHEN SHIFT IS RELEASED
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currentSpeed = speed;
            }

    }

    private void FixedUpdate()
    {
        // UPDATE RIGIDBODY'S VELOCITY WITH PLAYER'S INPUT (HORIZONTAL AXIS)
        _rigidbody2D.velocity = new Vector2(input * currentSpeed, _rigidbody2D.velocity.y);
    }

    private void jump()
    {
        // UPDATE OF COLLIDER'S POSITION
        Vector2 colliderPosition = new Vector2(transform.position.x, transform.position.y - 0.5f);

        // CHECK IF GROUNDED
        grounded = Physics2D.OverlapCircle(colliderPosition, 0.01f, LayerMask.GetMask("Floor"));
       

        // ADD JUMP FORCE IF GROUNDED
        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            
            float jump = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight); // CALCULATE JUMP MAGNITUDE
            _rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse); // ADD FORCE TO THE RIGIDBODY
        }
    }

    private void flipCharacter()
    {
        _spriteRenderer.flipX = (input > 0);       

        // UPDATE ANIMATOR PARAMETERS
        _animator.SetFloat("yVelocity", Mathf.Abs(currentSpeed));
        _animator.SetBool("grounded", grounded);


        Vector3 scale = _absorbArea.transform.localScale;

        if (input < 0)
        {
      
            scale.x = -1.0f;           
        }
        else{
            scale.x = 1.0f;
        }
        _absorbArea.transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            contador.coinCount++;
        }
    }
}
