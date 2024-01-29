using UnityEngine;

public class Roca : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robot") || collision.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}