using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MassScript : MonoBehaviour
{
    private XRIDefaultInputActions mia;
    private InputAction triggerValAction;
    public AnimationCurve massFactor;
    public AnimationCurve speedFactor;
    private float mass = 1f;
    private float speed;
    private float triggerVal;
    private bool activeObject = false;
    public XRBaseController throwController;
    private float frequency;
    private float orgSpeed;

    void Start(){
        throwController = GameObject.Find("RightHand (Teleport Locomotion)").GetComponent<XRBaseController>();
        orgSpeed = gameObject.GetComponent<XRGrabInteractable>().throwVelocityScale;
    }

    void Awake()
    {
        mia = new XRIDefaultInputActions();
    }

    private void OnEnable()
    {
        triggerValAction = mia.XRILeftHandInteraction.ActivateValueMass;
        triggerValAction.Enable();
        triggerValAction.performed += triggerValActionIt;
    }
    private void OnDisable()
    {
        triggerValAction.Disable();
    }

    public void ActivateGameObject(){
        activeObject = true;
    }

    public void SetMass(){
        if (activeObject){
            triggerVal = triggerValAction.ReadValue<float>();
            mass = massFactor.Evaluate(triggerVal);
            gameObject.GetComponent<Rigidbody>().mass=mass;
            Debug.Log(gameObject + mass.ToString());
            gameObject.GetComponent<XRGrabInteractable>().throwVelocityScale = 1.5f;
            activeObject = false;
        }
    }

    private void triggerValActionIt(InputAction.CallbackContext context){
        triggerVal = triggerValAction.ReadValue<float>();
        speed = orgSpeed * speedFactor.Evaluate(triggerVal);
        if (activeObject){
            gameObject.GetComponent<XRGrabInteractable>().throwVelocityScale = speed;
        }
    }

    void Update(){
        if (activeObject){
            triggerVal = triggerValAction.ReadValue<float>();
            throwController.SendHapticImpulse(triggerVal*0.7f, 0.001f);
        }

    }
}
