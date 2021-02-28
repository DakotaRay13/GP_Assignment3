using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public Text ScoreText;

    public void Start()
    {
        string diff = GetDifficulty();
        string playerName = PlayerPrefs.GetString("playerName");
        if (playerName == "") playerName = "Player";
        ScoreText.text = playerName + ": " + PlayerPrefs.GetInt("maxLives") + " Lives on " + diff + " - " + Score.CurrentScore.ToString();
    }

    public void Retry()
    {
        Score.CurrentScore = 0;
        SaveData.CurrentLives = PlayerPrefs.GetInt("maxLives");
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    string GetDifficulty()
    {
        float difficulty = PlayerPrefs.GetFloat("difficulty");
        //Change Difficulty Text
        if      (difficulty == 0) return "Easy";
        else if (difficulty == 1) return "Normal";
        else if (difficulty == 2) return "Hard";
        else if (difficulty == 3) return "Extreme";
        else return "Easy";
    }
}
