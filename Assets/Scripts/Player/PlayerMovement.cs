using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //CONTADOR PARA LAS ESTRELLAS
    public Contador contador;

    //VARIABLES PARA LOS BOOSTS
    public bool doubleJump = false;
    public bool speedBoost = false;
    


    [SerializeField] private AudioClip recolectSound;
    [SerializeField] private AudioClip sprintSound;
    [SerializeField] private AudioClip jumpSound;

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
                    SoundManager.instance.playSoundClip(sprintSound, transform, 0.5f);
                    currentSpeed *= speedBonus;                 
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
        if (!speedBoost)
        {
            // UPDATE RIGIDBODY'S VELOCITY WITH PLAYER'S INPUT (HORIZONTAL AXIS)
            _rigidbody2D.velocity = new Vector2(input * currentSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            // INCREASE SPEED FOR PLAYER
            _rigidbody2D.velocity = new Vector2(input * (currentSpeed+5), _rigidbody2D.velocity.y);
        }

        _animator.SetFloat("yVelocity", Mathf.Abs(_rigidbody2D.velocity.x));
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
            SoundManager.instance.playSoundClip(jumpSound, transform, 1f);
            float jump = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight); // CALCULATE JUMP MAGNITUDE
            _rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse); // ADD FORCE TO THE RIGIDBODY
            
        }

        if(Input.GetKeyDown(KeyCode.W) && doubleJump && !grounded)
        {
            SoundManager.instance.playSoundClip(jumpSound, transform, 1f);
            _rigidbody2D.AddForce(new Vector2(0f, 5), ForceMode2D.Impulse); 
            doubleJump = false;
        }

        // _animator.SetBool("jump", !grounded);
    }

    private void flipCharacter()
    {
        _spriteRenderer.flipX = (input > 0);       

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
        if (other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("Creditos");
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            SoundManager.instance.playSoundClip(recolectSound, transform, 0.5f);

            Destroy(other.gameObject);
            contador.coinCount++;
        }

        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            StartCoroutine(ActiveBoost("speedBoost",5f));
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Star"))
        {
            StartCoroutine(ActiveBoost("estrella", 5f));
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("DoubleJump"))
        {
            doubleJump = true;
            Destroy (other.gameObject);
        }
    }

    IEnumerator ActiveBoost(string boost,float duration)
    {
        if(boost == "estrella")
        {
            doubleJump = true;
            speedBoost = true;
        }

        if (boost == "speedBoost") speedBoost = true;

        yield return new WaitForSeconds(duration);

        if (boost == "speedBoost") speedBoost = false;

        if (boost == "estrella")
        {
            doubleJump = false;
            speedBoost = false;
        }
    }
}
