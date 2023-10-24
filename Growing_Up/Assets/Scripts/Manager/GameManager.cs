using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float maxSizeAllowed = 6f;
    public bool canBreakObjects = false;
    public bool suddenDeath = false;
}
