using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //here we will give movment to player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        transform.Rotate(Vector3.up,Time.deltaTime*turnSpeed*horizontalInput);
        
    }
}
