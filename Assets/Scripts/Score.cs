using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private int pointsPerBlock = 10;
    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        int scoreGameObjectCount = FindObjectsOfType<Score>().Length;
        if (scoreGameObjectCount > 1)
        {  
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }    
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ScoreReset()
    {
        Destroy(gameObject);
    }
}

