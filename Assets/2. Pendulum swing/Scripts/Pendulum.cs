using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private const float G = 9.8f;
    
    private float l;
    private float offsetBall;
    private float alpha;
    private float amplitude;
    private float cyclicFrequency;
    
    public float startPosition = 2;
    public float startSpeed = 2;
    
    private void Start()
    {
        GameObject ceil = GameObject.FindGameObjectWithTag("PendulumCeil");
        GameObject ball = GameObject.FindGameObjectWithTag("PendulumBall");

        startSpeed = startSpeed == 0 ? 1 : startSpeed;
        startPosition = startPosition == 0 ? 1 : startPosition;
        
        l = ceil.transform.position.y - (offsetBall = ball.transform.position.y);
        
        cyclicFrequency = Mathf.Sqrt(G / l);
        alpha = Mathf.Atan(cyclicFrequency * startPosition / startSpeed);
        amplitude = startPosition / Mathf.Sin(alpha);
    }

    private void Update()
    {
        transform.position =
            new Vector3(
                l * Mathf.Sin(amplitude * Mathf.Sin(Time.realtimeSinceStartup * cyclicFrequency + alpha)),
                -l * Mathf.Cos(amplitude * Mathf.Sin(Time.realtimeSinceStartup * cyclicFrequency + alpha)) + l + offsetBall,
                0f
            );
    }
}
