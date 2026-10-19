using UnityEngine;
using TMPro;



public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshPro scoreText;  
    int score = 0;
    public int currentScore = 0;
    
    // Start is cal
    //led once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text += score.ToString();
        
      
    }

    public void AddPoint(int amount)
    {
        currentScore += amount;
        score += amount;
        if (scoreText != null)
        {
            score += 1;
            scoreText.text += "Score" + score.ToString();

        }
       
    }
}
