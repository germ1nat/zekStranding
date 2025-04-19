using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float WalkingSpeed = 850;
    public float RunningSpeed = 1125;
    private float Speed;

    public bool isRunning = false;
    public bool isDashing = false;
    public float stamina = 100f;
    public float recoveryRate = 20f;
    public float recoverStamina;
    public float onDashStaminaLost = 2f;
    public float onRunStaminaLost = 0.8f;


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
        recoverStamina = recoveryRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Gets movement input
        GetMovementInput();

        StaminaRecovery();
        StaminaLoss();

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
        
        
        if (Input.GetKey(KeyCode.LeftShift) && stamina > onRunStaminaLost)
        {
            isRunning = true;
            Speed = RunningSpeed;
        }
        else
        {
            isRunning = false;
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
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && dashCounter <= 0 && stamina > onDashStaminaLost)
        {

            // Only dash if there's movement input (prevents dashing in place)
            
            
                if (movement.magnitude > 0.1f)
                {
                    isDashing = true;
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
                isDashing = false;
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
    void StaminaLoss()
    {
        if (isDashing)
        {
            stamina -= onDashStaminaLost;
            //recoverStamina = 0;

        }

        if (isRunning)
        {
            stamina -= onRunStaminaLost;
            recoverStamina = 0;

        }
        stamina = Mathf.Clamp(stamina, 0, 100);
        print(stamina);
    }
    void StaminaRecovery()
    {

        if (!isRunning && !isDashing && !Input.GetKey(KeyCode.LeftShift))
        {
            recoverStamina = recoveryRate;
            stamina += recoveryRate * Time.deltaTime;
        }
    }


    
    
}