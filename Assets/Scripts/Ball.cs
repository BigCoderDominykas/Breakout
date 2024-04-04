using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed = 5;
    public Transform spawnPoint;
    public AudioClip bounceSound;

    Rigidbody2D rb;
    AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.PlayOneShot(bounceSound);
        var brick = collision.gameObject.GetComponent<Brick>();

        if (brick != null)
        {
            brick.Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = spawnPoint.position;
        GameManager.lives--;
    }
}
