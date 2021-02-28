using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;

    float speed;

    private void Start()
    {
        speed = GetSpeedVariables();
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.deltaTime * speed);
    }

    float GetSpeedVariables()
    {
        float minSpeed;
        float maxSpeed;

        float Difficulty = PlayerPrefs.GetFloat("difficulty");

        if(Difficulty == 0f)
        {
            minSpeed = 8f;
            maxSpeed = 12f;
        }
        else if (Difficulty == 1f)
        {
            minSpeed = 16f;
            maxSpeed = 20f;
        }
        else if (Difficulty == 2f)
        {
            minSpeed = 24f;
            maxSpeed = 28f;
        }
        else if (Difficulty == 3f)
        {
            minSpeed = 32f;
            maxSpeed = 36f;
        }
        else //Default
        {
            minSpeed = 8f;
            maxSpeed = 12f;
        }

        return Random.Range(minSpeed, maxSpeed);
    }
}
