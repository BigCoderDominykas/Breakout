using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int hp;
    public int score = 100;
    public GameObject particles;

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.score += score;
        }
    }
}
