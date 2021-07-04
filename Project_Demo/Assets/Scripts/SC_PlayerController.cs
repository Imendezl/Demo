using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : MonoBehaviour
{

    public float speed, multDashSpeed, startDashTime, betweenDashTime, health, damage;
    public Transform respawn;


    private Rigidbody2D rb;
    private Vector2 moveVelocity, moveInput, respawnLocation;
    private float dashTime, dashCountdown;
    private bool dashing, startDashCountdown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashing = false;
        dashCountdown = betweenDashTime;
        respawnLocation = new Vector2 (respawn.transform.position.x, respawn.transform.position.y);
    }


    void Update()
    {
        PlayerMove();

        if (Input.GetButton("Jump") && dashCountdown >= betweenDashTime)
        {
            if (!dashing)
            {
                DashMove();
                startDashCountdown = true;
            }

        }
        else
        {
            //Dash time
            if (dashTime <= 0)
            {
                dashing = false;
                dashTime = startDashTime;

            }
            else
            {
                dashTime -= Time.deltaTime;

            }
        }

    }

    void FixedUpdate()
    {
        
        //Dash and Movement 
        if (dashing)
        {
            rb.MovePosition(rb.position + (moveVelocity * multDashSpeed) * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }

        //Countdown to do dash again
        if (startDashCountdown)
        {
            dashCountdown -= Time.fixedDeltaTime;
            if (dashCountdown <= 0)
            {
                dashCountdown = betweenDashTime;
                startDashCountdown = false;
            }
        }

    }

//Preparing Dash
    void DashMove()
    {
        dashing = true;
        dashTime = startDashTime;
    }

//Movement direction
    void PlayerMove()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

}
