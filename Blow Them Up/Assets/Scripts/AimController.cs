

using UnityEngine;

public class AimController : MonoBehaviour
{
    public float sensi;
    public GameObject boundry;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * sensi, Space.World);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * sensi, Space.World);
        Vector3 pos = transform.position;
        if (pos.z < boundry.transform.position.z)
        {
            pos.z = boundry.transform.position.z;
        }
        transform.position = pos;
    }
}
