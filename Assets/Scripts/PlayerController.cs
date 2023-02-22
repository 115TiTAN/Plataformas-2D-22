using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad_grounded;
    public float velocidad_air;
    public float fuerza_salto;
    public float dashSpeed;
    public float dashTime;
    public float distanceBetweenImages;
    public float dashCooldown;

    private bool grounded;
    private bool canDoubleJump;
    private bool isDashing;

    private float dashTimeLeft;
    private float lastImageXpos;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject dashEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        anim.SetBool("Grounded", grounded);
        anim.SetBool("Moving", horizontal != 0);

        if (grounded)
        {
            canDoubleJump = true;
            rb.gravityScale = 1f;
            horizontal = horizontal * velocidad_grounded;
        }
        else
        {
            rb.gravityScale = 3f;
            horizontal = horizontal * velocidad_air;
        }

        if (horizontal > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerza_salto);
            }
            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, fuerza_salto);
                    canDoubleJump = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        float dashTimeLeft = dashTime;

        rb.velocity = new Vector2(rb.velocity.x, 0f);

        Instantiate(dashEffect, transform.position, Quaternion.identity);

        float lastImageXpos = transform.position.x;

        while (dashTimeLeft > 0)
        {
            float dashSpeedThisFrame = dashSpeed * (dashTimeLeft / dashTime);
            rb.velocity = new Vector2(transform.localScale.x * dashSpeedThisFrame, 0f);

            if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                lastImageXpos = transform.position.x;
            }

            dashTimeLeft -= Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
    }
}