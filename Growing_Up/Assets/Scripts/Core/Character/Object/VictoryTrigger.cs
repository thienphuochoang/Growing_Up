using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryWindow;
    private void OnTriggerEnter2D(Collider2D other)
    {
        victoryWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
