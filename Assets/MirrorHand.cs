using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHand : MonoBehaviour
{
    public Transform originalHand;
    private List<Transform> originalTransforms;
    private List<Transform> cloneTransforms;

    void Start()
    {
        getImmediateChildren(gameObject.transform, cloneTransforms);
        getImmediateChildren(originalHand, originalTransforms);
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
        for (int i = 0; i < cloneTransforms.Count; i++) {
            cloneTransforms[i].localPosition = originalTransforms[i].localPosition;
            cloneTransforms[i].localRotation = originalTransforms[i].localRotation;
        }
    }
}
        