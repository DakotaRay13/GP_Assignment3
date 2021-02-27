using UnityEngine;

public class CarDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Car")
        {
            Destroy(collision.gameObject);
        }
    }
}
