using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TestScript : MonoBehaviour
{
    XRBaseInteractable xrbi;
    XRGrabInteractable xrgi;

    void Start(){
        xrgi = gameObject.GetComponent<XRGrabInteractable>();
        xrbi = gameObject.GetComponent<XRBaseInteractable>();
    }

    void Update()
    {
        xrbi.enabled=true;

        if (xrgi.isSelected)
        {
            xrbi.enabled=false;
        }

    }
}