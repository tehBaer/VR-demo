using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHand : MonoBehaviour
{

    public Transform originalHand; //make private
    public List<Transform> originalTransforms;
    public List<Transform> theseTransforms;
    private bool ok = false;


    public void GetTransforms()
    {
        // Debug.Log(transform + " OK");
        getImmediateChildren(gameObject.transform, theseTransforms);
        getImmediateChildren(originalHand, originalTransforms);
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
            theseTransforms[i].localPosition = originalTransforms[i].localPosition;
            theseTransforms[i].localRotation = originalTransforms[i].localRotation;
        }
        }
    }
}
