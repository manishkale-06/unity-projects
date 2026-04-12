using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
     void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;   
        rb.linearVelocity = Vector3.zero;

        transform.parent = collision.transform;
    }
}
