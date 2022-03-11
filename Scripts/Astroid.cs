using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    float rotation = 1;
    private Vector2 screenBounds;
    GameStatus gameStatus;
    public bool hit = false;
    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.scoore += 3;
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SetVelocity();
    }  
    void Update()
    {
        if (transform.position.x < screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }

        rb.MoveRotation(rotation);
        rotation++;
    }

    public void SetVelocity()
    {
        rb.velocity = new Vector2(-speed, 0);
    }


}
