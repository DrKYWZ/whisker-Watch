using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ParticleControl : MonoBehaviour
{

    public GameObject particle;
    public Vector2 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        particle.SetActive(true);
        particle.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
       }

       if (Input.GetMouseButtonUp(0))
       {
        particle.SetActive(false);
       }
    }
}
