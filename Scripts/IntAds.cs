using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntAds : MonoBehaviour
{
    static int numLoads = 0;
    private void Awake()
    {
        Advertisements.Instance.Initialize();
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ShowInterstitial()
    {
        numLoads ++;
        Debug.Log("numLoads = " + numLoads);
        if (numLoads == 3)
        {
            Advertisements.Instance.ShowInterstitial();
            numLoads = 0;
            Debug.Log("numLoads reset" + numLoads);
        }
    }
}
