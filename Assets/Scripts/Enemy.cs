using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject HitVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard; // Declarando mas vazio

    int ScoreEnemies = 10; 

    [SerializeField] int HitPoints = 4;
    


    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Não use no Update! e atribuindo 
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(HitPoints <= 0)
        {
                KillTheEnemy();
        }
       
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(HitVFX, transform.position, Quaternion.identity); // instancia o VFX e declara variavel
        vfx.transform.parent = parent;  // pega variavel VFX e coloca numa parent (Children)
        HitPoints--;
        scoreBoard.IncreseScore(ScoreEnemies); // chamando o script do método e acresentando a pontuação
    }

    void KillTheEnemy()
    {
        Destroy(this.gameObject); // Destroi o inimigo como o todo 
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // instancia o VFX e declara variavel
        vfx.transform.parent = parent;  // pega variavel VFX e coloca numa parent (Children)
    }
}
