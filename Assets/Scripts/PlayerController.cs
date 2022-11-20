using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    void Update()
    {
        
       
        float xThrow = Input.GetAxis("Horizontal");
        
        float yThrow = Input.GetAxis("Vertical");
        
        float xOFFset = xThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float newXPost = transform.localPosition.x + xOFFset; // Contar no posição local e não posição global caso do gameObject root

        float yOOFset = yThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float newYPost = transform.localPosition.y + yOOFset; // Contar no posição local e não posição global caso do gameObject root

        transform.localPosition = new Vector3(newXPost, newYPost, transform.localPosition.z);
    }
}
