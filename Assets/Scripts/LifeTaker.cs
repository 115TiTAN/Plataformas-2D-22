using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    public string target_tag = "Player";
    public int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == target_tag)
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            GameManager.Instance.follower.GetComponent<FollowCamera>().ShakeCam(1, 1);
        }
    }
}
