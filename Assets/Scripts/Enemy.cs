using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard; // Declarando mas vazio

    int ScoreEnemies = 10; 

    [SerializeField] int HitPoints = 10;
    
    int DemagePoints = 10;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Não use no Update! e atribuindo 
    }
    void OnParticleCollision(GameObject other)
    {
        KillTheEnemy();
        ProcessHit();
    }

    void ProcessHit()
    {
        HitPoints -= DemagePoints;
        if(HitPoints <= 0)
        {
            Destroy(this.gameObject); // Destroi o inimigo como o todo
        }
        
    }

    void KillTheEnemy()
    {
        scoreBoard.IncreseScore(ScoreEnemies); // chamando o script do método e acresentando a pontuação
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // instancia o VFX e declara variavel
        vfx.transform.parent = parent;  // pega variavel VFX e coloca numa parent (Children)
    }
}
