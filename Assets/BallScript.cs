using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 force;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
