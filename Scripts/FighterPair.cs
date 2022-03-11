using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPair : MonoBehaviour
{
    public GameObject laser;
    public Transform firePoint;
    Rigidbody2D rb;
    public GameObject explosion;
    public AudioClip laserSFX;
    GameStatus score;
    AudioSource audio;
    PlaySound player;
    private void Start()
    {
        player = FindObjectOfType<PlaySound>();
        audio = GetComponent<AudioSource>();
        score = FindObjectOfType<GameStatus>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-6, 0);
        StartCoroutine(PrepareShoot());
    }
    IEnumerator PrepareShoot()
    {
        yield return new WaitForSeconds(4.5f);
        ShootLaser();
    }
    private void ShootLaser()
    {
        GameObject l = Instantiate(laser) as GameObject;
        l.transform.position = firePoint.position;
        audio.PlayOneShot(laserSFX);
        l.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        rb.velocity = new Vector2(4, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            rb.velocity = new Vector2(0, 0);
            gameObject.layer = 11;
        }
        if (collision.gameObject.tag == "enemy")
        {
            player.Explode();
            GameObject explosionAnim = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionAnim, 1f);
            Destroy(gameObject);
            score.scoore += 50;
        }
    }
}
