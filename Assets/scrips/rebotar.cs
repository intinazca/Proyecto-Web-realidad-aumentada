using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebotar : MonoBehaviour
{
   Rigidbody rb;
   Vector3 direccion;
   Vector3 reflejado_aux;
   bool pega=false;
    void Start()
    {
        rb = GetComponent<Rigidbody>  ();
         rb.velocity = new Vector3 (1, -1) * 40;
        
    }

  
    void Update()
    {

      
        //Almacenamos la velocidad que lleva antes de la colision
    if (!pega) {
    direccion = rb.velocity;
    }

    void OnCollisionEnter2D(Collision coll){
    pega = true;
    //coll.contacts nos devuelve una matriz con los contactos de la colision
    Vector3 reflejado=Vector2.Reflect (direccion, coll.contacts [0].normal);
    rb.velocity = reflejado;
    }

    void OnCollisionExit2D(Collision coll){
    pega = false;
    }
   }

}
