using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int lives = 3;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    public GameObject winScreen;
    public GameObject loseScreen;

    Brick[] bricks;

    private void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        bricks = GetComponentsInChildren<Brick>();

        if (lives <= 0)
        {
            loseScreen.SetActive(true);
        }

        if (bricks.Length == 0)
        {
            winScreen.SetActive(true);
            print("win");
        }
    }
}
