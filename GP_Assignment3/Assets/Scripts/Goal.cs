using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You Win!");
        Score.CurrentScore += 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
