using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 pos = new Vector3(-3, -1, 5);
    
    public float rotateSpeedX = 6f;
    public float rotateSpeedY = 9f;
    public float rotateSpeedZ = 12f;
    public float changeDelay = 1f;


    void Start()
    {
        float xSize = Random.Range(1f, 10f);
        transform.position = pos;
        transform.localScale = Vector3.one * xSize;
        StartCoroutine(colorChangeDelay());
    }

    IEnumerator colorChangeDelay()
    {
        while (true)
        {
            Color color = Random.ColorHSV();
            color.a = Random.Range(0f, 1f);
            Material material = Renderer.material;
            material.color = color;

            yield return new WaitForSeconds(changeDelay);
        }
    }
    
    void Update()
    {
        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
    }
}
