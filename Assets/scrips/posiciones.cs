using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posiciones : MonoBehaviour
{
    public GameObject[] piramides;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float SpawnLeastWait; 
    public int startWait;
    public bool stop;

    int randPiramide;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait= Random.Range(SpawnLeastWait, spawnMostWait);

    }
    
    IEnumerator waitSpawner()
    {
      yield return new WaitForSeconds(startWait);
    //  //para elegir un parametrode cuantos aparecen
     // for(int i=0; i<2; i++)
     // {
        //  randPiramide = Random.Range(0,2);
        //  Vector3 spawnPosition= new Vector3(Random.Range(-spawnValues.x,spawnValues.x),1, Random.Range (-spawnValues.z,spawnValues.z));
        //  Instantiate (piramides[randPiramide], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
        //  yield return new WaitForSeconds(spawnWait);
        //  if(randPiramide>2)
         // {
          //   stop=true;
         // }

          //spawm infinito
        
      //}

        while (!stop)
          {
               randPiramide = Random.Range(0,2);
          Vector3 spawnPosition= new Vector3(Random.Range(-spawnValues.x,spawnValues.x),1, Random.Range (-spawnValues.z,spawnValues.z));
          Instantiate (piramides[randPiramide], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
          yield return new WaitForSeconds(spawnWait);
          }
    }
}
