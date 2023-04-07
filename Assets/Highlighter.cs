using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
   public Material highlightMaterial;
   private Material originalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = gameObject.GetComponent<Renderer>().material;
    }

    public void StartHighlight(){
        gameObject.GetComponent<Renderer>().material =  highlightMaterial;
    }

    public void StopHighlight(){
        gameObject.GetComponent<Renderer>().material =  originalMaterial;
    }


}
