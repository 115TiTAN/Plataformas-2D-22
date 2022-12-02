using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float distance;
    public float speed;
    public int dash_max = 1;
    public float recoverySpeed = 1;
    float dash_current;
    GroundDetector ground;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.grounded)
        {
            dash_current = dash_current + Time.deltaTime / recoverySpeed;
            if (dash_current > dash_max)
            {
                dash_current = dash_max;
            }
        }
        if (Input.GetButtonDown("Dash") && dash_current >= 1)
        {
            dash_current = dash_current - 1;
            float vertical = transform.position.y;
            //transform.position = transform.position + new Vector3(distance * transform.localScale.x, 0);
            if(transform.localScale.x > 0)
            {
                rb.AddForce(new Vector2(distance * speed, vertical));
            }
            else
            {
                rb.AddForce(new Vector2(-distance * speed, vertical));
            }
            
        }
    }
}