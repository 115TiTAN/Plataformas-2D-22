using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_volador : MonoBehaviour 
{
    public Transform objetivo;
    public float speed;

    public bool debePerseguir;

    public float distancia; // que tan lejos estemos del objetivo

    public float distanciaAbsoluta;



    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = objetivo.position.x - transform.position.x;

        distanciaAbsoluta =Mathf.Abs(distancia);


        if(debePerseguir == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, speed*Time.deltaTime);
        }
        

        if(distancia > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (distancia < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (distancia < 5) 
        {
            debePerseguir = true;
        }
        else
        {
            debePerseguir = false;
        }


    }
}
