using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // instancia o VFX e declara variavel
        vfx.transform.parent = parent;  // pega variavel VFX e coloca numa parent (Children)
        Destroy(this.gameObject); // Destroi o inimigo como o todo
    }
}
