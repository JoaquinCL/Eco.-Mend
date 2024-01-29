using UnityEngine;

public class Botella : MonoBehaviour
{
    public PauseMenu pauseMenu;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            Destroy(gameObject);
            pauseMenu.GameOver();
        }
        else if (collision.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            pauseMenu.GameOver();
        }
    }
}