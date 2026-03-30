using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SpawnManager spawnManagerScript;
    private AimController aimScript;
    private Rigidbody ballRb;
    private GameObject aim;
    private GameObject cannon;
    public bool launched = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        ballRb = GetComponent<Rigidbody>();
        aimScript = GameObject.Find("Aim").GetComponent<AimController>();
        aim = GameObject.Find("Aim");
        cannon = GameObject.Find("Cannon");
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !launched)
        {
            
            launched = true;
            spawnManagerScript.Spawned = false;
            Vector3 start = cannon.transform.position;
            Vector3 end = aim.transform.position;


            Vector3 planarTarget = new Vector3(end.x, 0, end.z);
            Vector3 planarStart = new Vector3(start.x, 0, start.z);

            float d = Vector3.Distance(planarTarget, planarStart);
            float h = end.y - start.y;

            float angle = 60f * Mathf.Deg2Rad;
            float g = -Physics.gravity.y;


            float v2 = (g * d * d) / (2f * (d * Mathf.Tan(angle) - h));
            if (v2 <= 0f) return;
            float v = Mathf.Sqrt(v2) / Mathf.Cos(angle);

            Vector3 dir = (planarTarget - planarStart).normalized;

            Vector3 velocity = dir * v * Mathf.Cos(angle);
            velocity.y = v * Mathf.Sin(angle);

            ballRb.linearVelocity = velocity; 

    }


    }
}
