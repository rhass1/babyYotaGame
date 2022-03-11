using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Force force;
    Rigidbody2D rb;
    public float seconds = 5f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-7, 0);
        force = FindObjectOfType<Force>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y - 1, +screenBounds.y - 1));
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            force.StartForce();
        }
    }
}
