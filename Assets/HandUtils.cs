using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandUtils : MonoBehaviour
{

    public MirrorHand LeftMirrorHand, RightMirrorHand;
    public GameObject leftHand, rightHand;
    public VRRig vrRig;
    private bool cont = true;

    void Update()
    {
        if (cont && transform.childCount > 0){
            rightHand = transform.Find("RightHand(Clone)").gameObject;
            leftHand = transform.Find("LeftHand(Clone)").gameObject;
            vrRig.rightHand.vrTarget = rightHand.transform.Find("R_Wrist");
            vrRig.leftHand.vrTarget = leftHand.transform.Find("L_Wrist");
            // attach collider


            LeftMirrorHand.originalParent = rightHand.transform;
            RightMirrorHand.originalParent = leftHand.transform;
            RightMirrorHand.GetTransforms();
            LeftMirrorHand.GetTransforms();

            cont = false;
            Debug.Log("OK");
            {
                
            }
        }
    }
}
