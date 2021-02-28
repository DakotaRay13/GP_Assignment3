using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject HowToPlayPanel;
    public GameObject OptionsPanel;

    //Options
    public Text playerName;
    public Text difficultyText;
    public Slider difficulty;
    public Toggle soundSetting;
    public Dropdown startingLives;

    public void StartGameWithNewSettings()
    {
        ChangeName();
        ChangeDifficulty();
        ChangeMaxLives();
        ChangeSoundSetting();
        StartGame();
    }

    // MAIN MENU BUTTONS
    public void StartGame()
    {
        Score.CurrentScore = 0;
        SaveData.CurrentLives = PlayerPrefs.GetInt("maxLives");
        SaveData.SaveToJson();
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void SetUpGame()
    {
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    //BACK TO MAIN MENU
    public void BackToMainMenu()
    {
        HowToPlayPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //SETUP GAME DATA
    public void ChangeName()
    {
        SaveData.SaveName(playerName.text);
        Debug.Log("Name changed to " + PlayerPrefs.GetString("playerName"));
    }

    public void ChangeDifficulty()
    {
        SaveData.SaveDifficulty(difficulty.value);
        Debug.Log("Difficulty changed to " + PlayerPrefs.GetFloat("difficulty").ToString());

        //Change Difficulty Text
        if      (difficulty.value == 0) difficultyText.text = "Easy";
        else if (difficulty.value == 1) difficultyText.text = "Normal";
        else if (difficulty.value == 2) difficultyText.text = "Hard";
        else if (difficulty.value == 3) difficultyText.text = "Extreme";
    }

    public void ChangeMaxLives()
    {
        SaveData.SaveMaxLives(startingLives.value + 1);
        Debug.Log("Max Lives changed to " + PlayerPrefs.GetInt("maxLives").ToString());
    }

    public void ChangeSoundSetting()
    {
        SaveData.SaveSoundSetting(soundSetting.isOn);
        Debug.Log("Sound Setting changed to " + PlayerPrefs.GetInt("soundSetting").ToString());
    }
}
