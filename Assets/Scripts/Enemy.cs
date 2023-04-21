using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(float da�o)
    {
        life -= da�o;

        if (life < 0)
        {
            Death();
        }

    }

    private void Death()
    {
        animator.SetTrigger("Death");
    }
}
    