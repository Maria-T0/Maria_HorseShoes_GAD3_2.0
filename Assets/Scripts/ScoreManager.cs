using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;    
    public TextMeshPro scoreText;

    private void Awake()
    {
        instance = this;    
    }

    int currentScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();   
    }

    public void AddScore()
    {
        currentScore = currentScore + 1;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
