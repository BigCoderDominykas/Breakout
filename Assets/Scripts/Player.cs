using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DOLocalMove(transform.position, 0.5f).ChangeStartValue(new Vector2(0, -6)).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            var offset = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(offset.x, 1);
        }
    }
}