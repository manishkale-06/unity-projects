using Unity.XR.CoreUtils.Datums;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManger : MonoBehaviour
{
    public Transform head;
    public float spawnDirection = 2;
    public GameObject menu;
    public InputActionProperty showButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDirection;
        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}
