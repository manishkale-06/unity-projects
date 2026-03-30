using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePosition;
    public float fireSpeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable grabable = GetComponent<XRGrabInteractable>();
        grabable.activated.AddListener(FiringBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FiringBullet(ActivateEventArgs activate)
    {
        GameObject spawanedBullet = Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation);
        spawanedBullet.GetComponent<Rigidbody>().linearVelocity = firePosition.transform.forward * fireSpeed;
        Destroy(bullet, 5);
    }
}
