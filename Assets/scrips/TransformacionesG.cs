using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// los dos puntos significa extender
public class TransformacionesG : MonoBehaviour
{
    float i;
    float j;
    float k;
    // Start is called before the first frame update
    void Start()
    {
        i = 1f;
        j = 1f;
        k = 0f;
    }

    // Update is called once per frame
    void Update()
    {      
     i += 1*2;   
     j = 0.1f; 
     k += 1*(0.01f); 
 
      if(gameObject.name.Equals("rotar"))
     {//para rotar
                                             //(angulo, eje)
       transform.rotation= Quaternion.AngleAxis(i,new Vector3(0,1,0));

       }

     if(gameObject.name.Equals("transladar"))
       {
     //paradesplazar en un eje        multiplica el tiempo por los valores del vector           
        
        transform.Translate(x:0,y:0,z:j);
       }

       if(gameObject.name.Equals("Sphere"))
       { // para escalar
      if((k>=0f)&&(k<=5f)){
        transform.localScale = new Vector3(x: k, y: k, z: k );
      }
       }
    }
}
