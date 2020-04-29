using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piramides : MonoBehaviour
 {   //malla
   Mesh mesh;
   MeshRenderer meshRenderer;

   //Vector3[] vertices;
  // int[] triangles;


   //vertices de los triangulos
   List<Vector3> vertices;
   List<int> triangles;
  
   public Material material;
   //parametros piramide
   public float height = 5.0f;
   public float radius=  5.0f;
   public int segments= 4; 
   Vector3 pos;  // vector posicion
   float angle = 0.0f;
   float angleAmount =0.0f;

   
    void Start()
    {
        // iniciamos la maya con el material
        gameObject.AddComponent<MeshFilter>();
        meshRenderer= gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material= material;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh=mesh;

        //inicializamos los vertices
        vertices= new List<Vector3>();
        pos = new Vector3();

        angleAmount = 2*Mathf.PI /segments;
        angle= 0.0f;

      //centro  anlto  
      pos.x=0.0f;
      pos.y=height;
      pos.z=0.0f;
      vertices.Add(new Vector3(pos.x, pos.y, pos.z));

      //centro  base  
      pos.y=0.0f;
      vertices.Add(new Vector3(pos.x, pos.y, pos.z));
        
        for (int i=0; i< segments; i++)
        {
            //agregamos vlos vertices
            pos.x = radius* Mathf.Sin(angle);
            pos.z = radius* Mathf.Cos(angle);

            vertices.Add(new Vector3(pos.x, pos.y, pos.z));
            angle-= angleAmount;
        }
         
         //asignamos vertices a las mayas
         mesh.vertices=vertices.ToArray();

         //iniciamos la lista de triangulos
         triangles =new List<int>();

         
         for( int i=2; i< segments +1; i++)
         {
            triangles.Add(0);
            triangles.Add(i+1);
            triangles.Add(i);

         }
        //cerramos
        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(segments+1);

        //para agregar la base  a la piramide
        for(int i =2; i<segments +1; i++)
        {
            triangles.Add(1);
            triangles.Add(i);
            triangles.Add(i+1);
        }

        //cerramos la tapa
        triangles.Add(1);
        triangles.Add(segments +1);
        triangles.Add(2);

        mesh.triangles=triangles.ToArray(); //agregamos los triangulos a la maya

    }


}
