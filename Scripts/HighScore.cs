using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {
        if (PlayerPrefs.GetFloat("HighScore") == null)
        {
            float highScore = PlayerPrefs.GetFloat("Score");
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        
        else
        {
            if(PlayerPrefs.GetFloat("Score") >= PlayerPrefs.GetFloat("HighScore"))
            {
                float highScore = PlayerPrefs.GetFloat("Score");
                PlayerPrefs.SetFloat("HighScore", highScore);
                scoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
            }
            else if(PlayerPrefs.GetFloat("HighScore") > PlayerPrefs.GetFloat("Score"))
            {
                scoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
            }
        }
    }
}
