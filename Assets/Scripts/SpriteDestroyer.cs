using UnityEngine;

public class SpriteDestroyer : MonoBehaviour
{
    public float timeToDestruction;  

    void Start()
    {
        Destroy(gameObject, timeToDestruction);
    }
}