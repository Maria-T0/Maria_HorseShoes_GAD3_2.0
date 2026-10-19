using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshPro scoreText;
    public TextMeshPro highScoreText;

    int score = 0;
    int highScore = 0;
    // Start is cal
    //led once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text += score.ToString();
        highScoreText.text += highScore.ToString();
    }

    public void AddPoint(int amount)
    {
        score += amount;
        if (scoreText != null)
        {
            score += 1;
            scoreText.text += "Score" + score.ToString();

        }
       
    }
}
