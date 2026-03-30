using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{


    public Vector3 currPos;
    private SpawnManager spawnManagerScript;
    
   
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        StartCoroutine(DestroyRange());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
    IEnumerator DestroyRange()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Target"))
        {

            Instantiate(explosionParticle, transform.position, transform.rotation);

            spawnManagerScript.Counter(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            
            Instantiate(explosionParticle, transform.position, transform.rotation);

        }
    }

}


