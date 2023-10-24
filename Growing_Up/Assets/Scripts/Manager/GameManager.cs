using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int enemyKillCount;

    public int EnemyKillCount
    {
        get
        {
            return enemyKillCount;
        }
        set
        {
            if (enemyKillCount != value)
            {
                enemyKillCount = value;
                OnEnemyKill?.Invoke();
            }
        }
    }
    public float maxSizeAllowed = 6f;
    public bool canBreakObjects = false;
    public bool suddenDeath = false;
    public System.Action OnEnemyKill;
    protected override void Start()
    {
        base.Start();
        enemyKillCount = FindObjectsOfType<Enemy>().Length;
    }
}
