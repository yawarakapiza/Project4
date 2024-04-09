using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Player‚ÌˆÚ“®
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        var movement = new Vector3(dx, 0, dz);
        rb.AddForce(movement * 3.0f);
    }
}
