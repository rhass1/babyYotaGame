using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GamePause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    bool gamePaused = false;
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        mainMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
