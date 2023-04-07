using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class triggerScript : MonoBehaviour
{
    // private XRIDefaultInputActions mia;
    private InputAction triggerValAction;
    private float triggerVal;
    private bool hasBeenReset = true;
    private float distToGround;
    public AnimationCurve factor;
    public AnimationCurve airtimeEffect;
    private bool activeAirTime = false;
    private float airTime = 0f;

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

    void Update()
    {
        if (activeAirTime)
        {
            triggerVal = triggerValAction.ReadValue<float>();
            // Debug.Log(triggerVal);

            airTime += Time.deltaTime;

            if (airTime > 0.5f)
            {
                activeAirTime = false;
                airTime = 0;
                // Debug.Log("airtime is over");
            }

            else
            {
                float newVal = triggerVal * airtimeEffect.Evaluate(airTime);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, newVal * 10, 0));
                Debug.Log(triggerVal + ", " + newVal);

            }

        }

        // if (triggerVal < 0.1f)
        // {
        //     hasBeenReset = true;
        // }
    }

    private bool isGrounded(float dtg)
    {
        return Physics.Raycast(transform.position, -Vector3.up, dtg + 0.5f);
    }

    private void triggerValActionIt(InputAction.CallbackContext context)
    {
        triggerVal = triggerValAction.ReadValue<float>();

        if ((triggerVal > 0.1f) && isGrounded(distToGround = gameObject.GetComponent<Collider>().bounds.extents.y))
        {
            // if (hasBeenReset)
            // {
                // Debug.Log("activeAirTime = true");
                activeAirTime = true;
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, triggerVal * 10, 0));
                Debug.Log(triggerVal);

                // hasBeenReset = false;
            // }
        }
    }
}

