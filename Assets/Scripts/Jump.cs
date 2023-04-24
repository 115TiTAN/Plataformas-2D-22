using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool canDobleJump = false;
    public float force = 10;
    Rigidbody2D rb;
    GroundDetector ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformEffector2D efector = null;
        try
        {
            efector = ground.plataforma_actual.GetComponent<PlatformEffector2D>();
        }
        catch
        {

        }
        if (ground.grounded)
        {
            canDobleJump = true;
        }
        if((ground.grounded || canDobleJump) && Input.GetButtonDown("Jump") && StaminaBar.instance.GetCurrentStamina() >=15)
        {
            if (efector != null && Input.GetAxis("Vertical") < 0)
            {
                StartCoroutine(desactivar_plataforma(ground.plataforma_actual));
                StaminaBar.instance.UseStamina(0);
            }
            else
            {
                rb.AddForce(new Vector2(0, force));
                StaminaBar.instance.UseStamina(15);
                if (!ground.grounded)
                {
                    canDobleJump = false;
                }
            }
        }
    }
    IEnumerator desactivar_plataforma(GameObject plataforma)
    {
        plataforma.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        plataforma.GetComponent<Collider2D>().enabled = true;
    }
}