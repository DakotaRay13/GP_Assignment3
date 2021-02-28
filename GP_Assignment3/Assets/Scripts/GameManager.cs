using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text playerNameText;
    public Text currentLivesText;

    public GameObject PauseMenu;

    public bool paused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        string PlayerName = PlayerPrefs.GetString("playerName");
        if (PlayerName == "") PlayerName = "Player";
        playerNameText.text = PlayerName;
        currentLivesText.text = "Lives: " + SaveData.CurrentLives.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        paused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        paused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
