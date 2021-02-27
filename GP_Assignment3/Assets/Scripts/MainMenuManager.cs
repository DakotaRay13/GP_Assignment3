using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject HowToPlayPanel;
    public GameObject OptionsPanel;

    // MAIN MENU BUTTONS
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void Options()
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
}
