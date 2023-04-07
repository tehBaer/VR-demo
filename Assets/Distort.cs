using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distort : MonoBehaviour
{

    private Renderer renderer;
    private Material material;
    private bool parametersOK;
    public AnimationCurve curve1;
    public AnimationCurve curve2;
    public float opacitySpeed = 0.25f;
    public float effectSpeed = .5f;
    public float spacing = .5f;
    private float opacityTimer, strengthTimer, factorTimer;
    public int minFactor, maxFactor, minStrength, maxStrength, opacityFactor;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        parametersOK = ParametersExist();
    }

    private bool ParametersExist(){
        return material.HasProperty("_Factor") & material.HasProperty("_Opacity") & material.HasProperty("_Strength");
    }

    void Update()
    {
        opacityTimer = (opacityTimer * opacitySpeed < 1 + spacing) ? (opacityTimer += Time.deltaTime) : 0;
        strengthTimer = (strengthTimer * effectSpeed < 1) ? (strengthTimer += Time.deltaTime) : 0;
        factorTimer = (factorTimer * effectSpeed < 1) ? (factorTimer += Time.deltaTime) : 0;
        
        if (parametersOK){
            material.SetFloat("_Opacity", curve1.Evaluate(opacityTimer * opacitySpeed) * opacityFactor);
            material.SetFloat("_Strength", minStrength + curve2.Evaluate(strengthTimer * effectSpeed) * maxStrength);
            material.SetFloat("_Factor", minFactor + curve2.Evaluate(factorTimer * effectSpeed) * maxFactor);
        }
    }
}



