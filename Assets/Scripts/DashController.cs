using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 0.5f;
    public float dashGravityScale = 0f;
    public float normalGravityScale = 2f;

    private bool canDash = true;
    private bool isDashing = false;
    private float lastDash = -10f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && StaminaBar.instance.GetCurrentStamina() >= 20)
        {
            isDashing = true;
            lastDash = Time.time;
            canDash = false;
            rb.gravityScale = dashGravityScale;
            StaminaBar.instance.UseStamina(25);
        }

        if (isDashing)
        {
            float direction = transform.localScale.x > 0 ? 1 : -1;
            Vector2 horizontalMovement = new Vector2(direction * dashSpeed * Time.deltaTime, 0f);
            transform.position += (Vector3)horizontalMovement;
            dashDuration -= Time.deltaTime;
            if (dashDuration <= 0)
            {
                isDashing = false;
                dashDuration = 0.1f;
                rb.gravityScale = normalGravityScale;
            }
        }

        if (!canDash)
        {
            float timeSinceDash = Time.time - lastDash;
            if (timeSinceDash > dashCooldown)
            {
                canDash = true;
            }
        }
    }
}