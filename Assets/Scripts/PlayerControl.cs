using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public int points;
    public Text scoreText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        points = 0;
        scoreText.text = "" + points;
    }

    public void IncreaseScore()
    {
        points += 1;
        scoreText.text = "" + points;
    }

    public static PlayerControl operator +(PlayerControl player, int value)
    {
        player.points += value;
        player.scoreText.text = "" + player.points;
        return player;
    }
}