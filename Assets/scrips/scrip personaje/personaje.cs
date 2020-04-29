using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    float velocidadMovimiento= 20f; //nos indica la velocidad del personaje
    float velocidadRotacion=  200.0f;//nos indica la velocidad del giro de las teclas
    private Animator anim;  //esto nos permite llamar a las animaciones
    public float x,y; // variabless para saber el sestado del movimiento 
    public GameObject referencia; 
    void Start()
    {
        //definimos una variable de tipo anim que toma las variables del Animator
        anim= GetComponent<Animator>();
    }

    
    void Update()
    {
        //condiciones para que el personaje se mueva
        x= Input.GetAxis("Horizontal");
        y= Input.GetAxis("Vertical");

        //para mover al personaje
        transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0); //con esto rota
        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);//con esto se mueve
        
        anim.SetFloat("velX",x);
        anim.SetFloat("velY",y);
        
    }
}
