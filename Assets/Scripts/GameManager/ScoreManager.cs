using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText();
    }

    private void ScoreText()
    {
        scoreText.text = "SCORE : " + score;
    }

    public void IncreaseScore(int iScore)
    {
        score += iScore;
    }
}
