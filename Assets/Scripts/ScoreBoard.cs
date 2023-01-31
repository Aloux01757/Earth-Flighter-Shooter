using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
        int score;

        public void IncreseScore(int amoutToIncrease) // criar um método para ser usado em outro script
        {
            score += amoutToIncrease;
            Debug.Log("Score: " + score);
        }
}
