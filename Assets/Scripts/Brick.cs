using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int hp;
    public int score = 100;
    public GameObject particles;
    public AudioClip destroySound;

    private void Start()
    {
        transform.DOScale(Vector3.one, 1f).SetDelay(Random.Range(0f, 1f)).SetEase(Ease.OutBounce).ChangeStartValue(Vector3.zero);
    }

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(destroySound);
            Destroy(gameObject);
            GameManager.score += score;
        }
    }
}
