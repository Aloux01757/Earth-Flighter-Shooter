using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    
    [SerializeField] float timeTillDestroy = 3f;
    void Start() 
    {
        Destroy(gameObject, timeTillDestroy); // coloca num prefab e depois é destruído (Junto com VFX)
    } 
}
