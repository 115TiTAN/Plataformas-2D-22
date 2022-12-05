using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;
    public string tagPlatform = "ElementoMovil";
    public GameObject plataforma_actual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagPlatform)
        {
            transform.SetParent(collision.transform, true);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        plataforma_actual = collision.gameObject;
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        plataforma_actual = null;
        grounded = false;
        if (collision.tag == tagPlatform)
        {
            transform.SetParent(null, true);
            
        }
    }
}
