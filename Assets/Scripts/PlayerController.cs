using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 4f;

    void Update()
    {
        
       
        float xThrow = Input.GetAxis("Horizontal");
        
        float yThrow = Input.GetAxis("Vertical");
        
        float xOFFSet = xThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float rawXPos = transform.localPosition.x + xOFFSet; // Contar no posição local e não posição global caso do gameObject root
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Pegar o eixo X e limitar para esse valor 

        float yOFFSet = yThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float rawYPos = transform.localPosition.y + yOFFSet; // Contar no posição local e não posição global caso do gameObject root
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); // Pegar o eixo Y e limitar para esse valor 


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
