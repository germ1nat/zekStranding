using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayermOVEMENT : MonoBehaviour
{

    public Rigidbody2D rb;
    public float WalkingSpeed = 850;
    public float RunningSpeed = 1125;
    private float Speed;

    private float activeSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        else
        {
            Running();
        }
            
    }

    void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = RunningSpeed;
            activeSpeed = Speed;
            playerMover();
        }
        else
        {
            Speed = WalkingSpeed;
            activeSpeed = Speed;
            playerMover();
        }
    }
    void playerMover()
    {

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = new Vector2(movement.x * activeSpeed, movement.y * activeSpeed) * Time.deltaTime;
    }
    void Dash()
    {
        
        
        if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                dashCounter = dashLength;
                activeSpeed = dashSpeed;
                
            }
        
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeSpeed = Speed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }


    
}