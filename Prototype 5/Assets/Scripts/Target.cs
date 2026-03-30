using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public int pointValue;
    private float minForce = 14;
    private float maxForce = 18;
    private float maxtTorq = 3;
    private float xSpawnPos = 4;
    private float ySpawnPos = -6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorq(), RandomTorq(), RandomTorq(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {

            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameeOver();
            }
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    float RandomTorq()
    {
        return Random.Range(-maxtTorq, maxtTorq);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnPos, xSpawnPos), ySpawnPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameeOver();

        }
    }
    
}
