using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayna : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 fark;
    Vector3 kuvvet;
    public float maxhiz;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(screenPoint);
        if(rb.velocity.magnitude >= 1)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxhiz);
        }
    }
    void OnMouseDown()
    {
        fark = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log("down" + fark);
        

    }
    void OnMouseDrag()
    {
        
        Vector3 kuvvet = Camera.main.ScreenToWorldPoint(Input.mousePosition - fark);
        rb.position = kuvvet;
        
        Debug.Log("drag" + fark);
    }
    
}
