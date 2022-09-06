using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airResistance : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        var p = 1.225f;
        var cd = 1f;
        var a = Mathf.PI * 0.5f * 0.5f;
        var v = rb.velocity.magnitude;

        var direction = -rb.velocity.normalized;
        var forceAmount = (p * v * v * cd * a) / 2;
        rb.AddForce(direction * forceAmount);
    }
}
