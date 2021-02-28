using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBodies : MonoBehaviour
{
    private const float G = 6.6f;
    private const int CountObjects = 10;

    private List<Rigidbody> _objects = new List<Rigidbody>();
    private Rigidbody _attractionSource;
    
    private void Start()
    {
        GameObject src = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        src.transform.position = new Vector3(0, 0, 0);
        src.AddComponent<Rigidbody>();

        Rigidbody srcRb = src.GetComponent<Rigidbody>();

        srcRb.mass = 90;
        srcRb.useGravity = false;
        srcRb.isKinematic = true;
        _attractionSource = srcRb;
        
        for (int i = 0; i < CountObjects; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            obj.transform.position = new Vector3(1 + Random.value * 40, 0, 1 + Random.value * 40);
            obj.AddComponent<Rigidbody>();
            
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.AddForce(5, 2, 0, ForceMode.Impulse);
            rb.mass = 1 + Random.value * 10;
            _objects.Add(rb);
        }
    }

    private void Update()
    {
        foreach (Rigidbody obj in _objects)
        {
            Vector3 attraction = -obj.transform.position;
            
            attraction = obj.mass * _attractionSource.mass * G * attraction.normalized / attraction.sqrMagnitude;
            obj.AddForce(attraction);
        }
    }
}
