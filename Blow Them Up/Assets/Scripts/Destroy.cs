using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Projectile projectileScript;
    public GameObject range;
    

    void Start()
    {
        projectileScript = GetComponent<Projectile>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
           
            projectileScript.launched = false;

           
            Vector3 spawnPos = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(range, spawnPos, transform.rotation);
            
          
            Destroy(gameObject);
        }
    }

   
}
