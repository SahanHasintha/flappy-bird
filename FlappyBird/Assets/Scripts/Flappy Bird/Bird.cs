using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float jumpForce;
    private Animator anim;

    public float rotationUp, rotationDown;
    public float Xspeed;

    [HideInInspector]
    public bool hasTheGameStarted, hasBirdDead;
    private int score;
    public AudioClip deathClip, flyClip, scoreClip;

    Vector3 birdRotation;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (hasTheGameStarted && !hasBirdDead)
        {
            FixedBirdRotation();
            XMovement();
        }

        if (hasBirdDead)
        {
            anim.speed = 0;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if(hasTheGameStarted && !hasBirdDead)
        {
            JumpMovement();
        }
        else
        {
            if(myBody.velocity.y<-1 && !hasBirdDead)
            {
                myBody.velocity = Vector2.up * jumpForce * .365f;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                hasTheGameStarted = true;
                if (!hasBirdDead)
                {
                    myBody.velocity = Vector2.up * jumpForce;
                }
            }
        }
       
        
    }

    void JumpMovement()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = Vector2.up * jumpForce;
            AudioSource.PlayClipAtPoint(flyClip, transform.position);
        }
    }

    void FixedBirdRotation()
    {
        float degreesToAdd = 0;

        if (myBody.velocity.y <= 0)
        {
            degreesToAdd = rotationDown;
        }

        if (myBody.velocity.y > 0)
        {
            degreesToAdd = rotationUp;
        }

        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + degreesToAdd, -90, 70));
        transform.eulerAngles = birdRotation;
    }

    void XMovement()
    {
        transform.position += new Vector3(Time.smoothDeltaTime * Xspeed, 0); 
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Pipe" )
        {
            if (!hasBirdDead)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
            hasBirdDead = true;
        }
        if (target.tag == "PipeScoe")
        {
            score++;
            PlayerPrefs.SetInt("Score", score);
            AudioSource.PlayClipAtPoint(scoreClip, transform.position);
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            if (!hasBirdDead)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
            hasBirdDead = true;
        }
    }
  
}
