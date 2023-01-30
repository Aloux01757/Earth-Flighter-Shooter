using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay = 1f;
    [SerializeField]ParticleSystem crashVFX;

    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }


    void StartCrashSequence()
    {
        crashVFX.Play();
        //GetComponent<MeshRenderer>().enabled = false; // era para funcionar, mas, sem querer eu remove o MeshRenderer pelo children prefab
        GetComponent<BoxCollider>().enabled =  false;
        GetComponent<PlayerController>().enabled = false;
        Invoke("RestartTheLevel",LoadDelay);
    }


    void RestartTheLevel()
    {
        SceneManager.LoadScene(0);
    }

}
