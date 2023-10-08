using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Quirell : MonoBehaviour
{
    //Components
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer rend;
    //Circle Wipe
    [SerializeField] private Animator circleWipeAnim;
    [SerializeField] private GameObject circle;
    //Other
    private float horizontal;
    [SerializeField] private float speed = 7;
    private bool isGlorb;
    private bool canMove;
    //Key and Door
    [HideInInspector] public Transform keyFollowPoint;
    [HideInInspector] public Key followingKey;
    private float transparency;
    //Sounds
    [SerializeField] private AudioSource flipGravSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource portalSound;
    
    private void Start()
    {
        circle.SetActive(true);
        canMove = true;
        rb.gravityScale = 0.75f;
    }

    void Awake()
    {
        StartCoroutine(AwakeCoroutine());
        canMove = true;
    }
    
    

    private void FixedUpdate()
    {
        
        //Glorb
        if(isGlorb == true)
        {
            rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
        }
        else if (isGlorb == false)
        {
            //Make it Move
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
     
        //swap sprite direction
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1,transform.localScale.y,1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1,transform.localScale.y,1);
        } 
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (isGlorb == false)
        {
            if (canMove == true)
            {
                horizontal = context.ReadValue<Vector2>().x;
            }
            
        }   

        //Set horizontal for Glorb
        else if (isGlorb == true)
        {
            if (horizontal > 0)
            {
                horizontal = 1;
            }

            if (horizontal < 0)
            {
                horizontal = -1;
            }
        }
    }

    public void FlipGravity(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.timeScale > 0)
            {
                //FlipGravity
                rb.gravityScale *= -1;
                //FlipSprite
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
                flipGravSound.Play();
            }
            
        }

    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Glorb")
        {
            isGlorb = true;
            canMove = false;
        }
        else if (other.tag == "Missile")
        {
            StartCoroutine(DeathCoroutine());
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Glorb")
        {   
            canMove = true;
            isGlorb = false;
            horizontal = horizontal/99999;
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            StartCoroutine(DeathCoroutine());
        }
        else if (collision.gameObject.tag == "Portal")
        {
            StartCoroutine(PortalCoroutine());
        }
    }


    IEnumerator DeathCoroutine()
    {   
        bc.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        deathSound.Play();
        yield return new WaitForSeconds(.2f);
        circleWipeAnim.SetTrigger("start");
	    for (int i = 0; i < 10; i++)
        {
	        rend.color = new Color(1,1,1,rend.color.a - .1f);
            yield return  new WaitForSeconds(.02f);
        }
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PortalCoroutine()
    {   
        bc.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        portalSound.Play();
        yield return new WaitForSeconds(.2f);
        circleWipeAnim.SetTrigger("start");
	    for (int i = 0; i < 10; i++)
        {
	        rend.color = new Color(1,1,1,rend.color.a - .1f);
            yield return  new WaitForSeconds(.02f);
        }
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator AwakeCoroutine()
    {
        rend.color = new Color(1,1,1,0);
        for (int i = 0; i < 10; i++)
        {
	        rend.color = new Color(1,1,1,rend.color.a + .1f);
            yield return  new WaitForSeconds(.05f);
        }       
    }      
}