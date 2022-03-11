using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] float yPush = 0f;
    Rigidbody2D myRigidBody;
    bool hasStarted;
    SceneLoader sceneLoader;
    GameStatus gameStatus;
    private Vector2 screenBounds;
    IntAds ads;
    AudioSource audio;
    public AudioClip baby;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        ads = FindObjectOfType<IntAds>();
        hasStarted = false;
        gameStatus = FindObjectOfType<GameStatus>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        myRigidBody = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        if (hasStarted == false)
        {
            myRigidBody.gravityScale = 0;
        }

        if (hasStarted == true)
        {
            myRigidBody.gravityScale = 3.6f;
            HoldToMove();
        }
            StartMovement();
    }

    private void StartMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
    }

    private void HoldToMove()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, (screenBounds.y * -1) + .3f, screenBounds.y - 1.2f), transform.position.z);
        if (Input.GetMouseButton(0))
        {
            myRigidBody.velocity = new Vector2(0, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            float score;
            sceneLoader.LoadNextScene();
            score = gameStatus.scoore;
            PlayerPrefs.SetFloat("Score", score);
        }
    }
}
