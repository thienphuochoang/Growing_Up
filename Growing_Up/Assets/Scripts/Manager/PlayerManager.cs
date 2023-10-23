using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Player player;
    protected override void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
}