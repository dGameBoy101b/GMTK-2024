using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityWarp : MonoBehaviour
{
    private Material mat;
    private Vector3 previousPosition;
    private Vector3 velocityWarp;
    [SerializeField] private float FPS;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        previousPosition = transform.position;
        velocityWarp = Vector3.zero;
        StartCoroutine(MaterialTimer());
    }
    
    void UpdateMaterialValues()
    {
        Vector3 velocity = transform.position - previousPosition;
        velocityWarp = Vector3.Lerp(velocityWarp, velocity, 2f*(1f/FPS));
        
        mat.SetVector("_VelocityWarp", velocityWarp);
        mat.SetVector("_Velocity", velocity);
        mat.SetVector("_WorldPosition", transform.position);
        mat.SetFloat("_GameTime", Time.time);
        previousPosition = transform.position;
    }

    IEnumerator MaterialTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f/FPS);
            UpdateMaterialValues();
        }
    }
}
