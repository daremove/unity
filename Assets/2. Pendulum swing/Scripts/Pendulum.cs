using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private const float G = 9.8f;
    
    private float l;
    private float offsetBall;
    private float amplitude;
    private float cyclicFrequency;
    
    private void Start()
    {
        GameObject ceil = GameObject.FindGameObjectWithTag("PendulumCeil");
        GameObject ball = GameObject.FindGameObjectWithTag("PendulumBall");

        l = ceil.transform.position.y - (offsetBall = ball.transform.position.y);
        cyclicFrequency = Mathf.Sqrt(G / l);
        amplitude = Mathf.PI / 2f;
    }

    private void Update()
    {
        float alpha = amplitude * Mathf.Cos(Time.realtimeSinceStartup * cyclicFrequency);
        float x = l * Mathf.Sin(alpha);
        float y = -l * Mathf.Cos(alpha) + offsetBall + l;
        
        transform.position =
            new Vector3(
                x,
                y,
                0f
            );
    }
}
