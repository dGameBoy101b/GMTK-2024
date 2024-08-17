using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityWarp : MonoBehaviour
{
    private Material mat;
    private Vector3 previousPosition;
    private Vector3 velocityWarp;
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        previousPosition = transform.position;
        velocityWarp = Vector3.zero;
    }
    
    void Update()
    {
        Vector3 velocity = transform.position - previousPosition;
        velocityWarp = Vector3.Lerp(velocityWarp, velocity, 0.01f);
        
        mat.SetVector("_VelocityWarp", velocityWarp);
        mat.SetVector("_Velocity", velocity);
        previousPosition = transform.position;
    }
}
