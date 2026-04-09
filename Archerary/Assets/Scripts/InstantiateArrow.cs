using UnityEngine;

public class InstantiateArrow : MonoBehaviour
{
    public GameObject arrow;
    public Transform shootPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
    {
        Instantiate(arrow, shootPoint.position, shootPoint.rotation);
    }
    }
}
