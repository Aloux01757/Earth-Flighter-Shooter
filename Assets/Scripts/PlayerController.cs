using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 4f;
  
    [SerializeField] float positionPitchFactor = -2f; // Orientação da nave e controle, Eixo Y
    [SerializeField] float controlPitchFactor = -15f; // multiplicar a entrada de dados, Eixo Y

    [SerializeField] float positionYawFactor = 2f;  // Orientação da nave e controle, Eixo X

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
            Debug.Log("Shooting");
        }
        else
        {
            return;
        }
    }
}

