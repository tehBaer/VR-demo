using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TriggerScript2 : MonoBehaviour
{
    // private XRIDefaultInputActions mia;
    private InputAction triggerValAction;
    private float triggerVal;
    private bool hasBeenReset = true;
    private float distToGround;
    public AnimationCurve factor;
    private bool preparingjump = false;
    private float countdown = 0f;

    void Start()
    {
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }

    void Awake()
    {
        // mia = new XRIDefaultInputActions();
    }

    private void OnEnable()
    {
        // triggerValAction = mia.XRIRightHandInteraction.ActivateValue1;
        triggerValAction.Enable();

        triggerValAction.performed += triggerValActionIt;
    }
    private void OnDisable()
    {
        triggerValAction.Disable();
    }


     // hvis på ground
     

    void Update()
    {
        if (preparingjump){
            countdown -= Time.deltaTime;
            if (countdown <= 0){
                triggerVal = triggerValAction.ReadValue<float>();
                float newVal = factor.Evaluate(triggerVal);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, newVal * 1000, 0));
                preparingjump = false;
                Debug.Log("jumped");
            }
        }

        }

    private bool isGrounded(float dtg)
    {
        return Physics.Raycast(transform.position, -Vector3.up, dtg + 0.5f);
    }

    private void triggerValActionIt(InputAction.CallbackContext context)
    {
        triggerVal = triggerValAction.ReadValue<float>();

        if ((triggerVal > 0.05f) && isGrounded(distToGround = gameObject.GetComponent<Collider>().bounds.extents.y))
        {
            // if (hasBeenReset)
            // {
                preparingjump = true;
                countdown = 0.1f;
                
                // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, triggerVal * 10, 0));
                // Debug.Log(triggerVal);

                // hasBeenReset = false;
            // }
        }
    }
}

