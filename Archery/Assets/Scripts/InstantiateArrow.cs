using UnityEngine;

public class InstantiateArrow : MonoBehaviour
{
    public GameObject arrowPrefab;   
    public Transform shootPoint;
    public Transform bowString;     

    public float pullSpeed = 2f;
    public float maxPull = 1f;
    public float shootForce = 20f;
    public float torque;

    private Vector3 startPos;
    private float pullAmount = 0f;

    void Start()
    {
        startPos = bowString.localPosition;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pullAmount += pullSpeed * Time.deltaTime;
            pullAmount = Mathf.Clamp(pullAmount, 0f, maxPull);

            bowString.localPosition = startPos - new Vector3(0, pullAmount, 0);
        }

        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GameObject newArrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);

            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.up * pullAmount * shootForce, ForceMode.Impulse);
            rb.AddTorque(newArrow.transform.up * torque);

            
            bowString.localPosition = startPos;
            pullAmount = 0f;
        }
    }
}