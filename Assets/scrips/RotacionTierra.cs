using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;
using Unity.Mathematics; //libreria de matematicas

public class RotacionTierra : MonoBehaviour
{
  public Transform target;// el objeto al que vamos orbitar
  public float distance=3; // distancia
  public float speed=30; // velocidad a la que gira alrededor del sol
  public float angSpeed=40; //velocidad de rotacion sobre su propio eje

  double sinA, cosA; //aca almacenamos el sen y cos
  float3 pos;
  float t = 0.0f; //tiempo como parametro de la ecuacion


    void Update()
    {
        //con esto la tierra gira sobre si misma
        transform.rotation *= Quaternion.AngleAxis(angSpeed * Time.deltaTime, Vector3.up);
        t+= Time.deltaTime * speed * 0.1f;
        sincos(t, out sinA, out cosA);//la libreria nos permite calcular el sen y cos al mismo tiempo
        //calculamos la nueva posicion de la tierra y le asignamos sus componentes
        pos= float3(distance*(float)sinA, transform.position.y, distance * (float)cosA);

        transform.position = pos; //asignamos la nueva posicion
        transform.position += target.position; //le sumamos la posicion del sol
    }
}
