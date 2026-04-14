using UnityEngine;

public class ScreenNaviagation : MonoBehaviour
{
    public float mouseSensitivity = 2f;

    private float xRotation = 0f;
    private float yRotation = 0f; 

    public Transform playerCamera;
    public Transform bow; 
    public StartGame startScript; 

    void Start()
    {
        playerCamera = Camera.main.transform; 
        startScript = GameObject.Find("GameManager").GetComponent<StartGame>();
    }

    void Update()
    {
        if (startScript.hasStarted)
        {
            LookAround();
        }
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

      
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

       
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f); 

     
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        bow.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}