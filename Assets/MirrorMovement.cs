using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    public GameObject objectToMirror;

    public Vector3 rotFactors = Vector3.one;
    public Vector3 posFactors = Vector3.one;
    public bool mirrorPosition, mirrorRotation= true;

    public Vector3 debugOne, debugTwo;



    void Update(){
        if (mirrorRotation){
            Vector3 v = (objectToMirror.transform.localRotation.eulerAngles);
            transform.localRotation = Quaternion.Euler(v.x * rotFactors.x, v.y *rotFactors.y, v.z * rotFactors.z);
        }

        if (mirrorPosition){
            Vector3 newPos = objectToMirror.transform.localPosition;

            // debugOne = newPos;
            transform.localPosition = Vector3.Scale(newPos, posFactors);
            debugTwo = transform.localPosition;
            // transform.localPosition = newPos;
        }
    }
}
