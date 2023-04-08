using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject objectToMirror;

    private Vector3 otherStartRot, otherStartPos;
    private Vector3 thisStartRot, thisStartPos;
    public Vector3 rotFactors = Vector3.one;
    public Vector3 posFactors = Vector3.one;
    public bool mirrorPosition, mirrorRotation= true;
    private bool hasStarted = false;
    public Vector3 debug1;
    public Vector3 debug2;

    void Start(){
        otherStartRot = objectToMirror.transform.localRotation.eulerAngles;
        thisStartRot = transform.localRotation.eulerAngles;

        StartCoroutine(DelayedGetPos());
        // GetStartPositions();
        // Debug.Log(gameObject.ToString() + transform.localPosition.ToString());
        // Debug.Log(objectToMirror.ToString() + objectToMirror.transform.localPosition.ToString());

    }

    IEnumerator DelayedGetPos(){
        yield return new WaitForSeconds(.5f);
        GetStartPositions();
    }


    public void GetStartPositions(){
        otherStartPos = objectToMirror.transform.localPosition;
        hasStarted = true;
        // transform.position = otherStartPos;
    }

    void Update(){
        if (mirrorRotation){
            Vector3 v = (objectToMirror.transform.localRotation.eulerAngles - otherStartRot + thisStartRot);
            transform.localRotation = Quaternion.Euler(v.x * rotFactors.x, v.y *rotFactors.y, v.z * rotFactors.z);
        }

        if (mirrorPosition & hasStarted){
            Vector3 deltaPos = objectToMirror.transform.localPosition;
            debug1 = deltaPos;

            transform.localPosition = Vector3.Scale(deltaPos, posFactors);

            debug2 = transform.localPosition;
            // transform.localPosition = deltaPos;
        }
    }
}
