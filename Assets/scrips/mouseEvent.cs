using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseEvent : MonoBehaviour
{
 
    public Color defaultcolor;
    public Color newcolor;
   public Renderer render;


    private void OnMouseOver()
    {

     render = GetComponent<Renderer>();
     render.material.color= newcolor; 
    
     }

  private void OnMouseExit(){

      render= GetComponent<Renderer>();
      render.material.color=defaultcolor;
  }


}
