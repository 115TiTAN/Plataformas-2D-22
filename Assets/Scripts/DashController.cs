using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField]
    private float dashSpeed;
    
    [SerializeField]
    private float dashDuration = 0.1f;
    
    [SerializeField]
    private float dashCooldown = 0.5f;

    private bool canDash = true;
    private bool isDashing = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) {
            isDashing = true;
            canDash = false;
        }

        if (isDashing) {
            float direction = transform.localScale.x > 0 ? 1 : -1;
            transform.position += new Vector3(direction * dashSpeed * Time.deltaTime, 0, 0);
            dashDuration -= Time.deltaTime;
            if (dashDuration <= 0) {
                isDashing = false;
                dashDuration = 0.1f;
            }
        }

        if (!canDash) {
            dashCooldown -= Time.deltaTime;
            if (dashCooldown <= 0) {
                canDash = true;
                dashCooldown = 0.5f;
            }
        }
    }
}