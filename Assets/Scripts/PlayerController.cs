using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{


    void Update()
    {
        
       
        float xThrow = Input.GetAxis("Horizontal");
        
        float yThrow = Input.GetAxis("Vertical");
        
        float Xoffset = 0.1f; 
        float newxPost = transform.localPosition.x + Xoffset; // Contar no posição local e não posição global caso do gameObject root

        transform.localPosition = new Vector3(newxPost, transform.localPosition.y, transform.localPosition.z);
    }
}
