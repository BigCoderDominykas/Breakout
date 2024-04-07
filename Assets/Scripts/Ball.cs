using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed = 5;
    public float startDelay = 1;
    public Transform spawnPoint;
    public AudioClip bounceSound;
    public GameObject dieParticles;

    public Color normalColor;
    public Color glowColor;

    Rigidbody2D rb;
    AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        startDelay -= Time.deltaTime;
        if (startDelay <= 0)
        {
            rb.isKinematic = false;
        }
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

        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.DOColor(glowColor, 0.15f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(normalColor);
        transform.DOScale(Vector3.one * 1.2f, 0.15f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(Vector3.one);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(dieParticles, transform.position, Quaternion.identity);
        transform.position = spawnPoint.position;
        GameManager.lives--;
    }
}
