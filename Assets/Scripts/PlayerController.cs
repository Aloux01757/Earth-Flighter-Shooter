using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    void Update()
    {
        
       
        float xThrow = Input.GetAxis("Horizontal");
            Debug.Log(xThrow);
        float yThrow = Input.GetAxis("Vertical");
            Debug.Log(yThrow);

    }
}
