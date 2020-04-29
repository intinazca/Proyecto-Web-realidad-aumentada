using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferasP : MonoBehaviour
{
    List<Vector3> vertices;
    List<int> triangles;
    Mesh mesh;     
    MeshFilter meshFilter;   
    MeshRenderer meshRenderer;

    public Material material;

    public int segments = 16;
    int x,y;

    public float radius= 5.0f;
    Vector3 pos; //vector de posicion
    float angle;
    float angle2;
    float angleAmount; //cantidad de angulos
    
    void Start()
    {
        //creamos el filtro
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material= material; // cpn esto asignamos material
        
        mesh= new Mesh(); //creamos la maya
        meshFilter.mesh= mesh; // le asignamos la maya al filtro

        vertices= new List<Vector3>(); //inicializamos una lista 

        pos= new Vector3(0,4,0); //iniciamos la posicion
        angleAmount = 2* Mathf.PI / segments; // la cantidad de incremento del angulo
        
        angle = 0.0f;
        angle2 = 0.0f;
             
             for(y =0; y< segments/2 + 1; y++)
             {
                 for(x=0; x< segments; x++)
                 {
                     //aqui empezamos a trorcer los vertices
                     pos.x = radius * Mathf.Sin(angle2)*Mathf.Cos(angle);
                     pos.y = radius * Mathf.Cos(angle2);
                     pos.z = radius * Mathf.Sin(angle2)*Mathf.Sin(angle);
                     
                     //vertices.Add(new Vector3(x * width, y * height,0));
                     vertices.Add(new Vector3(pos.x, pos.y, pos.z));
                     angle += angleAmount; //aumentamos el angulo
                 }
                 //implementamos el segundo angulo
                 angle2-= angleAmount;
             }
        mesh.vertices= vertices.ToArray(); // agregamos los vertices a ala maya
      //creamos lista de triangulos
        triangles= new List<int>();
     
        int ceil;
        int floor;
        

        for (int k = 0; k < segments/2; k++)
        {
            ceil= segments* (k+1);
            floor= segments*k;

            for(int i=0; i< segments-1; i++)
            {
                triangles.Add(floor);
                triangles.Add(ceil);  
                triangles.Add(floor + 1);

                triangles.Add(ceil);
                triangles.Add(ceil + 1);  
                triangles.Add(floor + 1);

                ceil++;
                floor++;
            }

            //cerramos el cilindro
            triangles.Add(floor + 0);
            triangles.Add(ceil + 0);
            triangles.Add(segments * k);

            triangles.Add(ceil + 0);
            triangles.Add(segments * (k + 1));
            triangles.Add(segments * k);
        }


        //agregamos la lista de triangulos a la maya
        mesh.triangles= triangles.ToArray();

    }

  
}
