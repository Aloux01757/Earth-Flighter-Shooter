using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
        int score;
        TMP_Text scoreText;

        void Start() 
        {
            scoreText = GetComponent<TMP_Text>();
            scoreText.text = "Start";
        }

        void Update() 
        {
           
        }
        public void IncreseScore(int amoutToIncrease) // criar um método para ser usado em outro script
        {
            score += amoutToIncrease;
            scoreText.text = score.ToString();
        }
}
