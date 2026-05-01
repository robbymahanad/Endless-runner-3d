using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        
    }

    public void AddScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
    public void ShowScore()
    {
        finalScoreText.text = score.ToString();
    }
}
