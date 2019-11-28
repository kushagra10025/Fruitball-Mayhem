


using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static int currentScore;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        currentScore = 0;
    }

    private void Update()
    {
        scoreText.text = currentScore.ToString("000");
    }
}
