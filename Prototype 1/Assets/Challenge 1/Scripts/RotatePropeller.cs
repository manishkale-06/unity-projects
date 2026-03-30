using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    private float propspeed = 1000.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward*propspeed*Time.deltaTime);
    }
}
