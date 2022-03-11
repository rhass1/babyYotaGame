using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    bool hasStarted = false;
    public TextMeshProUGUI scoreText;
    int specialNum = 8;

    private Vector2 screenBounds;
    public GameObject power;
    public GameObject fighter;
    public GameObject Yota;
    public GameObject fighters;
    [SerializeField] GameObject[] astroids;
    public float respawnTime = 1.1f;
    int randomNum;

    public int scoore;
    private void Start()
    {
        hasStarted = false;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        if (hasStarted == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                StartCoroutine(AsteroidWave());
                StartCoroutine(PowerWave());
                StartCoroutine(FighterWave());
            }
        }
        else
        {
            scoreText.text = scoore.ToString();
            respawnTime = setDif();
        }
    }
    private float SpawnEnemy()
    {
        randomNum = Random.Range(1, 4);
        GameObject a = Instantiate(astroids[randomNum-1]) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, +screenBounds.y));
        return a.transform.position.y;
    }

    private void SpawnPower()
    {
        GameObject p = Instantiate(power) as GameObject;
        p.transform.position = new Vector2((screenBounds.x * 2), Random.Range(-screenBounds.y + 1, +screenBounds.y - 1));
    }

    private void SpawnFighter()
    {
        GameObject f = Instantiate(fighter) as GameObject;
        f.transform.position = new Vector2(screenBounds.x * 2, Yota.transform.position.y);
        Destroy(f, 7f);
        if(specialNum >= 2)
        {
            specialNum = specialNum - 1;
        }
        float randNum = Mathf.Round(Random.Range(1, specialNum));
        if (randNum == 1)
        {
            GameObject r = Instantiate(fighters) as GameObject;
            r.transform.position = new Vector2(screenBounds.x * 2, 4.4f);
            GameObject t = Instantiate(fighters) as GameObject;
            t.transform.position = new Vector2(screenBounds.x * 2, -4.4f);
            Destroy(t, 7f);
            Destroy(r, 7f);
        }
    }
    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    IEnumerator PowerWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(12, 30));
            SpawnPower();
        }
    }

    IEnumerator FighterWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 20));
            SpawnFighter();
        }
    }
    private float setDif()
    {
        if (scoore < 100)
        {
            return 1.1f;
        }
        else if (scoore < 200)
        {
            return 1;
        }
        else if (scoore < 300)
        {
            return .9f;
        }
        else if (scoore < 400)
        {
            return .8f;
        }
        else if (scoore < 500)
        {
            return .7f;
        }
        else if (scoore < 700)
        {
            return .6f;
        }
        else if (scoore < 800)
        {
            return .5f;
        }
        else if (scoore < 1000)
        {
            return .4f;
        }
        else
        {
            return .3f;
        }
    }
}
