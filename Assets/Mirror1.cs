using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror1 : MonoBehaviour
{
    public GameObject objectToMirror;

    private Vector3 otherStartRot, otherStartPos;
    private Vector3 thisStartRot, thisStartPos;
    public Vector3 rotFactors = Vector3.one;
    public Vector3 posFactors = Vector3.one;
    public bool mirrorPosition = true;
    private bool hasStarted = false;

    void Start(){
        otherStartRot = objectToMirror.transform.localRotation.eulerAngles;
        thisStartRot = transform.localRotation.eulerAngles;
        StartCoroutine(DelayedGetPos());
    }

    IEnumerator DelayedGetPos(){
        yield return new WaitForSeconds(.5f);
        GetStartPositions();
    }


    public void GetStartPositions(){
        otherStartPos = objectToMirror.transform.localPosition;
        thisStartPos = transform.localPosition;
        hasStarted = true;
    }

    void Update(){
        Vector3 v = (objectToMirror.transform.localRotation.eulerAngles - otherStartRot + thisStartRot);
        transform.localRotation = Quaternion.Euler(v.x * rotFactors.x, v.y *rotFactors.y, v.z * rotFactors.z);

        if (mirrorPosition & hasStarted){
            Vector3 deltaPos = objectToMirror.transform.localPosition - otherStartPos;
            transform.localPosition = thisStartPos + Vector3.Scale(deltaPos, posFactors);
        }
    }
}
