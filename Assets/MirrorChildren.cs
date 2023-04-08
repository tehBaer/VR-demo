using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorChildren : MonoBehaviour
{

    public Transform originalParent; //make private
    public List<Transform> originalTransforms;
    public List<Transform> theseTransforms;
    private bool ok = false;
    public bool getAtStartup, mirrorThisTransform = false;

    public Vector3 rotFactors = Vector3.one;
    public Vector3 posFactors = Vector3.one;

    void Start(){
        if (getAtStartup){
            GetTransforms();
        }
    }


    public void GetTransforms()
    {
        if (mirrorThisTransform){
            originalTransforms.Add(originalParent);
            theseTransforms.Add(gameObject.transform);
        }
        // Debug.Log(transform + " OK");
        getImmediateChildren(originalParent, originalTransforms);
        getImmediateChildren(gameObject.transform, theseTransforms);
        ok = true;


        // add rigidbody and collider to each wrist


    }

    private void getImmediateChildren(Transform parent, List<Transform> outputList)
    {
        foreach (Transform child in parent)
        {
            outputList.Add(child);
            getImmediateChildren(child, outputList);
        }
    }

    void FixedUpdate()
    {
        if (ok){

        for (int i = 0; i < theseTransforms.Count; i++)
        {
            theseTransforms[i].localPosition = Vector3.Scale(originalTransforms[i].localPosition, posFactors);

            Vector3 v = (originalTransforms[i].localRotation.eulerAngles);

            transform.localRotation = Quaternion.Euler(v.x * rotFactors.x, v.y *rotFactors.y, v.z * rotFactors.z);



        }
        }
    }
}
