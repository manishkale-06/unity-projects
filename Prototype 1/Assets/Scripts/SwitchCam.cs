using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject tppCam;   
    public GameObject fppCam;   
    private bool isFpp = false; 

    void Start()
    {
        
        tppCam.SetActive(true);
        fppCam.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFpp = !isFpp; 
            tppCam.SetActive(!isFpp);
            fppCam.SetActive(isFpp);
        }
    }
}
