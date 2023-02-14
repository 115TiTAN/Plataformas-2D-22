using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dodgeSpeed = 10.0f;
    public float dodgeDistance = 2.0f;
    public LayerMask groundLayers; // The layers that are considered ground
    public AnimationClip Roll; // The animation to play when the player dodges

    private Rigidbody2D rb;
    private Collider2D collider;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.IsTouchingLayers(collider, groundLayers);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            Dodge();
        }
    }

    void Dodge()
    {
        // Play the dodge animation
        animator.Play(Roll.name);

        // Determine the direction of the dodge
        Vector2 dodgeDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        dodgeDirection = dodgeDirection.normalized;

        // Apply the force in the direction of the dodge
        rb.AddForce(dodgeDirection * dodgeSpeed * dodgeDistance * Time.deltaTime, ForceMode2D.Impulse);
    }
}