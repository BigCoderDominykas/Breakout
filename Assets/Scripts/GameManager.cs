using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int lives = 3;

    //public float restartDelay = 1f;
    public TMP_Text scoreText;
    public TMP_Text livesText;

    public GameObject winScreen;
    public GameObject loseScreen;
    public AudioClip winSound;
    public AudioClip loseSound;

    //public float timer = 2f;

    private void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            loseScreen.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(loseSound);
            FullReset();
            enabled = false;
        }

        if (transform.childCount < 1)
        {
            winScreen.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(winSound);
            FullReset();
            enabled = false;
        }
    }

    void FullReset()
    {
        //SceneManager.LoadScene("SampleScene");
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}
