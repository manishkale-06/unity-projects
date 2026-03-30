using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerUpStrength = 15.0f;
    public GameObject powerUpIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdownRoutine());
            powerUpIndicator.SetActive(true);
        }
    }
    IEnumerator powerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.SetActive(false);
        hasPowerup = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            Debug.Log("Collided with " + collision.gameObject.name + "  with power up set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
