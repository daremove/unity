using UnityEngine;

public class Planet : MonoBehaviour
{
    private const float G = 9.8f;
    
    public Transform attractionSource;
    public Vector3 startSpeed = new Vector3(1, 1, 1);

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = startSpeed;
        Debug.Log(_rigidbody);
    }

    private void Update()
    {
        Vector3 attraction = (attractionSource.position - transform.position).normalized;
        
        attraction = G * attraction / attraction.sqrMagnitude;
        _rigidbody.AddForce(attraction);
    }
}
