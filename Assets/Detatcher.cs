using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Detatcher : MonoBehaviour
{    
    XRBaseInteractor xrbiR;
    XRBaseInteractable xrbiE;
    private bool measure = false;
    public float cutoffDistance = 1;

    public void startMeassure(){
        xrbiR = gameObject.GetComponent<XRGrabInteractable>().interactorsSelecting[0] as XRBaseInteractor;
        xrbiE = gameObject.GetComponent<XRBaseInteractable>();
        measure = true;
    }

    public void stopMeasure(){
        measure = false;
        xrbiE.enabled = true;
    }

    void Update(){
        if (measure){

            if (Vector3.Distance(gameObject.transform.position, xrbiR.transform.position)>cutoffDistance){
                
            xrbiE.enabled=false; // TODO: end select / invoke deselect instead of this
            stopMeasure();
            }
        }

    }
}
