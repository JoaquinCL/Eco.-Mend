using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;
    public Text VidaText;
    public int Vida = 20;
    public float speed = 10f;
    public float startDelay = 3f;
    private bool isActive = false;
    public Text metaText;
    public int Meta = 20;
    public AudioSource _audioSource;
    public PauseMenu pauseMenu;
    public Rigidbody2D rb;
    public ParticleSystem particleSystem; // Nuevo: Sistema de partículas

    void Start()
    {
        VidaText.text = "" + Vida;
        metaText.text = "" + Meta;
        Invoke("ActivatePlayer", startDelay);
        rb = this.GetComponent<Rigidbody2D>();

        // Nuevo: Posiciona el sistema de partículas en la parte inferior del jugador
        particleSystem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - player.GetComponent<Collider2D>().bounds.extents.y, player.transform.position.z);
    }

    void Update()
    {
        // Nuevo: Mueve el sistema de partículas con el jugador
        particleSystem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - player.GetComponent<Collider2D>().bounds.extents.y, player.transform.position.z);

        if (isActive)
        {
            movement();
            fireProjectile();
            VidaText.text = "" + Vida;

            if (Vida <= 0)
            {
                pauseMenu.GameOver();
            }

            if (PlayerControl.instance.points >= Meta)
            {
                pauseMenu.PlayerWin();
            }
        }
    }

    void ActivatePlayer()
    {
        isActive = true;
    }

    void movement()
    {
        Vector2 moveInput = new Vector2();
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                moveInput.y = 1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveInput.x = -1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                moveInput.y = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveInput.x = 1;
        }

        if (Gamepad.current != null)
        {
            moveInput += Gamepad.current.leftStick.ReadValue();
        }

        Vector2 moveVelocity = moveInput * speed;
        rb.velocity = moveVelocity;
    }

    void fireProjectile()
    {
        if ((Keyboard.current != null && Keyboard.current.jKey.wasPressedThisFrame)
            || (Gamepad.current != null && (Gamepad.current.rightTrigger.wasPressedThisFrame || Gamepad.current.buttonSouth.wasPressedThisFrame))
            && projectileClone == null)
        {
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.9f, 0), player.transform.rotation) as GameObject;
            projectileClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            _audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Roca"))
        {
            Vida -= 5;
            Destroy(collision.gameObject);
        }
    }
}