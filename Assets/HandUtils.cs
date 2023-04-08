using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandUtils : MonoBehaviour
{

    public MirrorHand LeftMirrorHand, RightMirrorHand;
    private GameObject leftHand, rightHand;
    public VRRig vrRig;
    private bool cont = true;

    void Update()
    {
        if (cont && transform.childCount > 0){
            rightHand = transform.Find("RightHand(Clone)").gameObject;
            leftHand = transform.Find("LeftHand(Clone)").gameObject;

            LeftMirrorHand.originalHand = rightHand.transform;
            RightMirrorHand.originalHand = leftHand.transform;

            vrRig.rightHand.vrTarget = rightHand.transform.Find("R_Wrist");
            vrRig.leftHand.vrTarget = leftHand.transform.Find("L_Wrist");

            RightMirrorHand.GetTransforms();
            LeftMirrorHand.GetTransforms();

            cont = false;
            Debug.Log("OK");
            {
                
            }
        }
    }
}
