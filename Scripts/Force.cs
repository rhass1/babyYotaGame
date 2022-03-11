using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    private Vector2 screenBounds;

    public SpriteRenderer sprite;
    public Sprite newSprite;
    public Sprite hold;
    public Slider slider;
    public AudioClip clip;
    AudioSource audio;
    Astroid astroid;

    CircleCollider2D collider;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        slider.value = 0;
        collider = gameObject.GetComponent<CircleCollider2D>();
        collider.enabled = false;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 0);
            if (collision.gameObject.transform.position.y == (screenBounds.y / 4))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 0);
            }
            else if (collision.gameObject.transform.position.y < (screenBounds.y / 4))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(7, -1.5f);
            }
            else if (collision.gameObject.transform.position.y > (screenBounds.y / 4))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 1.5f);
            }
            Destroy(collision.gameObject, 2f);
            collision.gameObject.layer = 10;
        }
    }

    public void StartForce()
    {
        audio.Play();
        collider.enabled = true;
        sprite.sprite = newSprite;
        slider.value = 10;
        StartCoroutine(WaitForS());
        StartCoroutine(AnimateSliderOverTime());
    }

    IEnumerator AnimateSliderOverTime()
    {
        float animationTime = 0f;
        while (animationTime < 10)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / 10;
            slider.value = Mathf.Lerp(10f, 0f, lerpValue);
            yield return null;
        }
    }

    IEnumerator WaitForS()
    {
        yield return new WaitForSeconds(10f);
        collider.enabled = false;
        sprite.sprite = hold;
        slider.value = 0;
    }
}
