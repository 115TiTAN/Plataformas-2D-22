using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    public string target_tag = "Player";
    public int damage = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == target_tag)
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
