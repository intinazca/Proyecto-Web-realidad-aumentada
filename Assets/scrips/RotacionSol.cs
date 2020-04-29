using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionSol : MonoBehaviour
{
  
  public float velocidad =15; //verlocidad angular
 

 
    void Update()
    {
        //combinamos  la rotacion del objeto con una nueva rotacion basada en la rotacion del eje vertical
        transform.rotation *= Quaternion.AngleAxis(velocidad * Time.deltaTime, Vector3.up);
        
    }
}
