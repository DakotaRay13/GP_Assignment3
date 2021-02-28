using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject GameOverText;

    public Vector2 frogBounds;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(Vector2.right + rb.position);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(Vector2.left + rb.position);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(Vector2.up + rb.position);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(Vector2.down + rb.position);
        }
        
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -frogBounds.x, frogBounds.x), Mathf.Clamp(transform.position.y, -frogBounds.y, frogBounds.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Car")
        {
            Debug.Log("We Lost");
            SaveData.CurrentLives -= 1;

            if(SaveData.CurrentLives > 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            else StartCoroutine(GameOver());
        }
    }

    public IEnumerator GameOver()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GameOverText.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("EndScene");
    }
}
