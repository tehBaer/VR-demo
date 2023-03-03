using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity;

public class RumbleScript : MonoBehaviour
{
    public XRBaseController controller;
    private bool sendImpuse = false;
    public float intensity;
    private float duration = 0.01f;
    public void startImpulse(){
        sendImpuse=true;
    }
    public void stopImpulse(){
        sendImpuse=false;
    }
    void Update(){
        if (sendImpuse){
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}