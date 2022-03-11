using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairFollow : MonoBehaviour
{
    public Transform yota;
    void Start()
    {
        
    }

    void Update()
    {
            transform.position = new Vector2(8.44f, yota.position.y);
    }
}
