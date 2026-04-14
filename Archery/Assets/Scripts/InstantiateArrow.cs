using UnityEngine;

public class InstantiateArrow : MonoBehaviour
{
    public GameObject arrowPrefab;   
    public Animator bowAnimator;
    public Transform shootPoint;
    public Transform bowString; 
    public Transform playerCamera; 
    public StartGame startScript;   

    public float pullSpeed = 2f;
    public float maxPull = 1f;
    public float shootForce = 20f;
    public float torque;

    private Vector3 startPos;
    private float pullAmount = 0f;

    void Start()
    {
        startPos = bowString.localPosition;
        startScript = GameObject.Find("GameManager").GetComponent<StartGame>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse1) && startScript.hasStarted)
        {
            pullAmount += pullSpeed * Time.deltaTime;
            pullAmount = Mathf.Clamp(pullAmount, 0f, maxPull);

            bowString.localPosition = startPos - new Vector3(0, pullAmount, 0);
            
            bowAnimator.SetFloat("Pull", pullAmount);
        }

        
        if (Input.GetKeyUp(KeyCode.Mouse1) && startScript.hasStarted)
        {
            GameObject newArrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.LookRotation(playerCamera.forward)* Quaternion.Euler(90f, 0f, 0f));

            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.AddForce(playerCamera.forward * pullAmount * shootForce, ForceMode.Impulse);
            rb.AddTorque(newArrow.transform.up * torque);

            
            bowString.localPosition = startPos;
            pullAmount = 0f;
            bowAnimator.SetFloat("Pull", 0f);
        }
    }
}