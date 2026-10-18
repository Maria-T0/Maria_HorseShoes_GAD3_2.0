using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private HorseShoe horseShoe;
    [SerializeField] private TextMeshPro scoreText;
    private float currentScore = 0f;

    public void AddScore()
    {
        currentScore += 1f;
        horseShoe.RewardScore = currentScore;
        UpdateScoreDisplay();
        Debug.Log("Score increased to: " + currentScore);
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
