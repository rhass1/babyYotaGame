using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public GameObject laser;
    public Transform firePoint;
    Rigidbody2D rb;
    int direction = 1; //int direction where 0 is stay, 1 up, -1 down    
    int top = 3;
    int bottom = -3;
    float speed = 5;
    GameStatus score;
    public AudioClip laserSFX;
    AudioSource audio;
    PlaySound player;

    public GameObject explosion;
    private void Start()
    {
        player = FindObjectOfType<PlaySound>();
        audio = GetComponent<AudioSource>();
        score = FindObjectOfType<GameStatus>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PrepareShoot());
        rb.velocity = new Vector2(-6, 0);
    }
    void Update()
    {
            if (transform.position.y >= top)
                direction = -1;

            if (transform.position.y <= bottom)
                direction = 1;

            transform.Translate(0, speed * direction * Time.deltaTime, 0);
    }
    IEnumerator PrepareShoot()
    {
        yield return new WaitForSeconds(Random.Range(4.5f, 6f));
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