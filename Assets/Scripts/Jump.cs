using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
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
        if(ground.grounded == true && Input.GetButtonDown("Jump"))
        {
            if (efector != null && Input.GetAxis("Vertical") < 0)
            {
                StartCoroutine(desactivar_plataforma(ground.plataforma_actual));
            }
            else
            {
                rb.AddForce(new Vector2(0, force));
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