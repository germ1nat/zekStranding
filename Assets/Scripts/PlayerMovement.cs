using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float WalkingSpeed = 850;
    public float RunningSpeed = 1125;
    private float Speed;

    private float activeSpeed;
    public float dashSpeed = 2000; // Default value for dash speed

    public float dashLength = 0.5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        Speed = WalkingSpeed; // Initializessssss ssssssssspeed
        activeSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets movement input
        GetMovementInput();
        
        // Handles running / walking
        HandleRunning();
        
        // Handles dashing
        HandleDashing();
        
        // Applies movement
        MovePlayer();
    }

    void GetMovementInput()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, vertical).normalized;
    }

    void HandleRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = RunningSpeed;
        }
        else
        {
            Speed = WalkingSpeed;
        }
        
        // Only update activeSpeed if the player isnt dashing
        if (dashCounter <= 0)
        {
            activeSpeed = Speed;
        }
    }
    
    void HandleDashing()
    {
        // Starts dash
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && dashCounter <= 0)
        {
            // Only dash if there's movement input (prevents dashing in place)
            if (movement.magnitude > 0.1f)
            {
                dashCounter = dashLength;
                activeSpeed = dashSpeed;
            }
        }
        
        // Updates dash timer
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeSpeed = Speed;
                dashCoolCounter = dashCooldown;
            }
        }
        
        // Updates dash cooldown
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
    
    void MovePlayer()
    {
        // Applies movement
        rb.linearVelocity = movement * activeSpeed * Time.deltaTime;
    }
}