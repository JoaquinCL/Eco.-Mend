using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 10f;
    public float gravity = -9.8f;
    private Vector2 velocity;

    void Start()
    {
        velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (projectile != null)
        {
            velocity.y += gravity * Time.deltaTime;
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Botella"))
        {
            PlayerControl.instance.IncreaseScore();
            Destroy(collision.gameObject);
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }
        else if (collision.gameObject.CompareTag("Roca"))
        {
            Destroy(collision.gameObject);
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }
    }
}