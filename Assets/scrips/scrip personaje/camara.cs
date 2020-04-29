using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public GameObject jugador; //personaje al que se le pega la camara
    public GameObject referencia; //manejador de camara
    private Vector3 distancia; // es el rayo

    void Start()
    {//calcula la distancia de la camara al jugador y la mantiene siempre
         distancia = transform.position- jugador.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {// lee el moouse y lo rota
        distancia= Quaternion.AngleAxis(Input.GetAxis("Mouse X")*2, Vector3.up)*distancia;
        transform.position= jugador.transform.position + distancia; //mueve la camara con respecto al jugador respetando la distancia
        transform.LookAt(jugador.transform.position); // esto centra el jugador hacia la camara

        //para rotar bien los controles y no los alter
                                          //x lo deja igual, x transforma el angulo y z queda igual;
        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y,0);
        referencia.transform.eulerAngles= copiaRotacion;
      

    
    }
}
