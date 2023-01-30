using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How fast the player ship upon up and down based in the input system of the player")] [SerializeField] float controlSpeed = 10f;
    [Tooltip("How limited is X value the Player ship")] [SerializeField] float xRange = 5f;
    [Tooltip("How limited is Y value the Player ship")]   [SerializeField] float yRange = 4f;
  
  [Header("Lasers Array")]

  [Tooltip("Added all the lasers Player here")]
    [SerializeField] GameObject[] lasers; // array

    [Header("Based screen of the player shooting")]

    [SerializeField] float positionPitchFactor = -2f; // Orientação da nave e controle, Eixo Y

    [SerializeField] float positionYawFactor = 2f;  // Orientação da nave e controle, Eixo X

[Header("Based screen of the player shooting")]

    [SerializeField] float controlPitchFactor = -15f; // multiplicar a entrada de dados, Eixo Y


    [SerializeField] float controlRollFactor = -20f; // multiplicar a entrada de dados, Eixo X




    float xThrow, yThrow; // Criado variaveis

    
    void Update()
    {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; // Controle da nave no eixo Y (Position)
        float pitchDueToControlThrow = yThrow * controlPitchFactor; // Entrada de dados Eixo Y multiplicado por fator 


       


        float pitch =  pitchDueToPosition + pitchDueToControlThrow; // Posição + Fator
        float yaw = transform.localPosition.x * positionYawFactor; // Controle da nave no eixo X (Position)
        float roll = xThrow * controlRollFactor; // Entrada de dados Eixo X multiplicado por fator 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {

        
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOFFSet = xThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float rawXPos = transform.localPosition.x + xOFFSet; // Contar no posição local e não posição global caso do gameObject root
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Pegar o eixo X e limitar para esse valor 

        float yOFFSet = yThrow * Time.deltaTime * controlSpeed; // entrada de dados 
        float rawYPos = transform.localPosition.y + yOFFSet; // Contar no posição local e não posição global caso do gameObject root
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); // Pegar o eixo Y e limitar para esse valor 


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        

    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }
    void SetLasersActive(bool IsActive)
    {
        foreach(GameObject laser in lasers) // O foreach, compoem, o tipo de objeto, o nome você pode dar, in, lasers (array) e abrir as chaves
        {
            var emission = laser.GetComponent<ParticleSystem>().emission; // Importante lembre de colocar o Array para achar o emission! (No ParticleSystem)
            emission.enabled = IsActive;
        }
    }

    
}

