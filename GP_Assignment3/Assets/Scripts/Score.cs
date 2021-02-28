using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int CurrentScore = 0;

    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + CurrentScore.ToString();
    }
}
