using UnityEngine;

public class InstantiateArrow : MonoBehaviour
{
    public Transform arrow;      
    public Transform shootPoint;

    public float pullSpeed = 2f;
    public float maxPull = 1f;

    private Vector3 startPos;
    private float pullAmount = 0f;

    void Start()
    {
        startPos = arrow.localPosition;
    }

    void Update()
    {
       
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pullAmount += pullSpeed * Time.deltaTime;
            pullAmount = Mathf.Clamp(pullAmount, 0f, maxPull);

            arrow.localPosition = startPos - new Vector3(0, pullAmount, 0);
        }

       
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            arrow.localPosition = startPos;
            pullAmount = 0f;
        }
    }
}